using AspectEditor.Components;
using AspectEditor.EngineAPIStructs;
using AspectEditor.GameProject;
using AspectEditor.Utilities;
using System;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;

namespace AspectEditor.EngineAPIStructs {

    [StructLayout(LayoutKind.Sequential)]
    internal class TransformComponent {
        public Vector3 Position;
        public Vector3 Rotation;
        public Vector3 Scale = new Vector3(1, 1, 1);
    }

    [StructLayout(LayoutKind.Sequential)]
    internal class ScriptComponent {
        public IntPtr ScriptCreator;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal class GameEntityDescriptor {
        public TransformComponent Transform = new();
        public ScriptComponent Script = new();
    }
}

namespace AspectEditor.DLLWrappers {

    public static class EngineAPI {
        private const string _engineDll = "EngineDll.dll";

        [DllImport(_engineDll, CharSet = CharSet.Ansi)]
        public static extern int LoadGameCodeDll(string dllPath);

        [DllImport(_engineDll)]
        public static extern int UnloadGameCodeDll();

        [DllImport(_engineDll)]
        public static extern IntPtr GetScriptCreator(string name);

        [DllImport(_engineDll)]
        [return: MarshalAs(UnmanagedType.SafeArray)]
        public static extern string[] GetScriptNames();

        [DllImport(_engineDll)]
        public static extern int CreateRenderSurface(IntPtr host, int width, int height);

        [DllImport(_engineDll)]
        public static extern int RemoveRenderSurface(int surfaceId);

        [DllImport(_engineDll)]
        public static extern IntPtr GetWindowHandle(int surfaceId);

        [DllImport(_engineDll)]
        public static extern int ResizeRenderSurface(int surfaceId);

        public static class EntityAPI {

            [DllImport(_engineDll)]
            private static extern int CreateGameEntity(GameEntityDescriptor desc);

            public static int CreateGameEntity(GameEntity entity) {
                GameEntityDescriptor desc = new GameEntityDescriptor();

                //transform component
                {
                    var c = entity.GetComponent<Transform>();
                    desc.Transform.Position = c.Position;
                    desc.Transform.Rotation = c.Rotation;
                    desc.Transform.Scale = c.Scale;
                }

                //script component
                {
                    //Check that the current project is not null so we can tell if the gamecode DLL has been loaded. This way creation is deffered until the dll has been loaded.
                    var c = entity.GetComponent<Script>();
                    if (c != null && Project.Current != null) {
                        if (Project.Current.AvailableScripts.Contains(c.Name)) {
                            desc.Script.ScriptCreator = GetScriptCreator(c.Name);
                        } else {
                            Logger.Log(MessageType.Error, $"Unable to find script with name {c.Name}. Game Entity will be created without script component.");
                        }
                    }
                }

                return CreateGameEntity(desc);
            }

            [DllImport(_engineDll)]
            private static extern void RemoveGameEntity(int id);

            public static void RemoveGameEntity(GameEntity entity) {
                RemoveGameEntity(entity.EntityId);
            }
        }
    }
}