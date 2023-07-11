using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using static AspectEditor.Components.GameEntity;

namespace AspectEditor.Components;

public interface IMSComponent { }

[DataContract]
public abstract class Component : ViewModelBase {

    [DataMember]
    public GameEntity Owner { get; set; }

    public abstract IMSComponent GetMultiselectionComponent(MSEntity msEntity);

    public abstract void WriteToBinary(BinaryWriter bw);

    public Component(GameEntity owner) {
        Debug.Assert(owner != null);
        Owner = owner;
    }
}

public abstract class MSComponent<T> : ViewModelBase, IMSComponent where T : Component {
    private bool _enableUpdates = true;

    public List<T> SelectedComponents { get; }

    public MSComponent(MSEntity msEntity) {
        Debug.Assert(msEntity?.SelectedEntities?.Any() == true);
        SelectedComponents = msEntity.SelectedEntities.Select(entity => entity.GetComponent<T>()).ToList();
        PropertyChanged += (s, e) => { if (_enableUpdates) UpdateComponents(e.PropertyName); };
    }

    public void Refresh() {
        _enableUpdates = false;
        UpdateMSComponent();
        _enableUpdates = true;
    }

    protected abstract bool UpdateComponents(string propertyName);

    protected abstract bool UpdateMSComponent();
}