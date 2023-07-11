using System.Diagnostics;

namespace AspectEditor.Content {

    public enum AssetType {
        Unknown,
        Animation,
        Audio,
        Material,
        Mesh,
        Skeleton,
        Texture
    }

    public abstract class Asset : ViewModelBase {
        public AssetType Type { get; private set; }

        public Asset(AssetType type) {
            Debug.Assert(type != AssetType.Unknown);
            Type = type;
        }
    }
}