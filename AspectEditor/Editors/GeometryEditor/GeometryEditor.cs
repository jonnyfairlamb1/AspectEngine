﻿using AspectEditor.Content;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace AspectEditor.Editors {

    public class MeshRendererVertexData : ViewModelBase {
        private Brush _specular = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff111111"));
        public Brush Specular {
            get => _specular;
            set {
                if (_specular != value) {
                    _specular = value;
                    OnPropertyChanged(nameof(Specular));
                }
            }
        }

        private Brush _diffuse = Brushes.White;
        public Brush Diffuse {
            get => _diffuse;
            set {
                if (_diffuse != value) {
                    _diffuse = value;
                    OnPropertyChanged(nameof(Diffuse));
                }
            }
        }

        public Point3DCollection Positions { get; } = new Point3DCollection();
        public Vector3DCollection Normals { get; } = new Vector3DCollection();
        public PointCollection UVs { get; } = new PointCollection();
        public Int32Collection Indices { get; } = new Int32Collection();
    }

    public class MeshRenderer : ViewModelBase {
        public ObservableCollection<MeshRendererVertexData> Meshes { get; } = new();

        private Vector3D _cameraDirection = new(0, 0, -10);
        public Vector3D CameraDirection {
            get => _cameraDirection;
            set {
                if (_cameraDirection != value) {
                    _cameraDirection = value;
                    OnPropertyChanged(nameof(CameraDirection));
                }
            }
        }

        private Point3D _cameraPosition = new(0, 0, 10);
        public Point3D CameraPosition {
            get => _cameraPosition;
            set {
                if (_cameraPosition != value) {
                    _cameraPosition = value;
                    OnPropertyChanged(nameof(OffsetCameraPosition));
                    OnPropertyChanged(nameof(CameraPosition));
                }
            }
        }

        private Point3D _cameraTarget = new(0, 0, 0);
        public Point3D CameraTarget {
            get => _cameraTarget;
            set {
                if (_cameraTarget != value) {
                    _cameraTarget = value;
                    OnPropertyChanged(nameof(OffsetCameraPosition));
                    OnPropertyChanged(nameof(CameraTarget));
                }
            }
        }

        public Point3D OffsetCameraPosition => new(CameraPosition.X + CameraTarget.X, CameraPosition.Y + CameraTarget.Y, CameraPosition.Z + CameraTarget.Z);

        private Color _keyLight = (Color)ColorConverter.ConvertFromString("#ffaeaeae");
        public Color KeyLight {
            get => _keyLight;
            set {
                if (_keyLight != value) {
                    _keyLight = value;
                    OnPropertyChanged(nameof(KeyLight));
                }
            }
        }

        private Color _skyLight = (Color)ColorConverter.ConvertFromString("#ff111b30");
        public Color SkyLight {
            get => _skyLight;
            set {
                if (_skyLight != value) {
                    _skyLight = value;
                    OnPropertyChanged(nameof(SkyLight));
                }
            }
        }

        private Color _groundLight = (Color)ColorConverter.ConvertFromString("#ff3f2f1e");
        public Color GroundLight {
            get => _groundLight;
            set {
                if (_groundLight != value) {
                    _groundLight = value;
                    OnPropertyChanged(nameof(GroundLight));
                }
            }
        }

        private Color _ambientLight = (Color)ColorConverter.ConvertFromString("#ff3b3b3b");
        public Color AmbientLight {
            get => _ambientLight;
            set {
                if (_ambientLight != value) {
                    _ambientLight = value;
                    OnPropertyChanged(nameof(AmbientLight));
                }
            }
        }

        public MeshRenderer(MeshLOD lod, MeshRenderer old) {
            Debug.Assert(lod?.meshes.Any() == true);
            //calculate vertex size minus the position and normal vectors
            var offset = lod.meshes[0].VertexSize - 3 * sizeof(float) - sizeof(int) - 2 * sizeof(short);

            //in order to set up the position and target properly, need to figure out how big this object is thats being rendered.
            double minX, minY, minZ; minX = minY = minZ = double.MaxValue;
            double maxX, maxY, maxZ; maxX = maxY = maxZ = double.MinValue;

            Vector3D avgNormal = new Vector3D();
            // this is to unpack the packed normals.
            var intervals = 2.0f / ((1 << 16) - 1);
            foreach (var mesh in lod.meshes) {
                var vertexData = new MeshRendererVertexData();
                //unpack all vertices
                using (var reader = new BinaryReader(new MemoryStream(mesh.Vertices)))
                    for (int i = 0; i < mesh.VertexCount; i++) {
                        var posX = reader.ReadSingle();
                        var posY = reader.ReadSingle();
                        var posZ = reader.ReadSingle();
                        var signs = (reader.ReadUInt32() >> 24) & 0x000000ff;
                        vertexData.Positions.Add(new(posX, posY, posZ));

                        //adjust the bounding box
                        minX = Math.Min(minX, posX); maxX = Math.Max(maxX, posX);
                        minY = Math.Min(minY, posY); maxY = Math.Max(maxY, posY);
                        minZ = Math.Min(minZ, posZ); maxZ = Math.Max(maxZ, posZ);

                        // read the normals
                        var nrmX = reader.ReadInt16() * intervals - 1.0f;
                        var nrmY = reader.ReadInt16() * intervals - 1.0f;
                        var nrmZ = Math.Sqrt(Math.Clamp(1f - (nrmX * nrmX + nrmY * nrmY), 0.0f, 1.0f)) * ((signs & 0x2) - 1f);

                        var normal = new Vector3D(nrmX, nrmY, nrmZ);
                        normal.Normalize();
                        vertexData.Normals.Add(normal);
                        avgNormal += normal;

                        //read uvs
                        reader.BaseStream.Position += (offset - sizeof(float) * 2);
                        var u = reader.ReadSingle();
                        var v = reader.ReadSingle();
                        vertexData.UVs.Add(new(u, v));
                    }

                using (var reader = new BinaryReader(new MemoryStream(mesh.Indices)))
                    if (mesh.IndexSize == sizeof(short)) {
                        for (int i = 0; i < mesh.IndexCount; i++) vertexData.Indices.Add(reader.ReadUInt16());
                    } else {
                        for (int i = 0; i < mesh.IndexCount; i++) vertexData.Indices.Add(reader.ReadInt32());
                    }

                vertexData.Positions.Freeze();
                vertexData.Normals.Freeze();
                vertexData.UVs.Freeze();
                vertexData.Indices.Freeze();
                Meshes.Add(vertexData);
            }

            if (old != null) {
                CameraTarget = old.CameraTarget;
                CameraPosition = old.CameraPosition;
            } else {
                var width = maxX - minX;
                var height = maxY - minY;
                var depth = maxZ - minZ;
                var radius = new Vector3D(height, width, depth).Length * 1.2f;
                if (avgNormal.Length > 0.8) {
                    avgNormal.Normalize();
                    avgNormal *= radius;
                    CameraPosition = new Point3D(avgNormal.X, avgNormal.Y, avgNormal.Z);
                } else {
                    CameraPosition = new Point3D(width, height * 0.5, radius);
                }

                CameraTarget = new Point3D(minX + width * 0.5, minY + height * 0.5, minZ + depth * 0.5);
            }
        }
    }

    public class GeometryEditor : ViewModelBase, IAssetEditor {
        public Content.Asset Asset => Geometry;

        private Content.Geometry _geometry;
        public Content.Geometry Geometry {
            get => _geometry;
            set {
                if (_geometry != value) {
                    _geometry = value;
                    OnPropertyChanged(nameof(Geometry));
                }
            }
        }

        private MeshRenderer _meshRenderer;
        public MeshRenderer MeshRenderer {
            get => _meshRenderer;
            set {
                if (_meshRenderer != value) {
                    _meshRenderer = value;
                    OnPropertyChanged(nameof(MeshRenderer));
                }
            }
        }

        public void SetAsset(Content.Asset asset) {
            Debug.Assert(asset is Content.Geometry);

            if (asset is Content.Geometry geometry) {
                Geometry = geometry;
                MeshRenderer = new(Geometry.GetLodGroup().LODs[0], MeshRenderer);
            }
        }
    }
}