using AspectEditor.Content;

namespace AspectEditor.Editors {

    public interface IAssetEditor {
        Asset Asset { get; }

        void SetAsset(Asset asset);
    }
}