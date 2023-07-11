﻿using AspectEditor.Components;
using AspectEditor.Utilities;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Windows.Input;

namespace AspectEditor.GameProject;

[DataContract]
public class Scene : ViewModelBase {
    private string _name;

    [DataMember]
    public string Name {
        get => _name;
        set {
            if (_name != value) {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
    }

    [DataMember]
    public Project Project { get; private set; }

    private bool _isActive;

    [DataMember]
    public bool IsActive {
        get => _isActive;
        set {
            if (_isActive != value) {
                _isActive = value;
                OnPropertyChanged(nameof(IsActive));
            }
        }
    }

    [DataMember(Name = nameof(GameEntities))]
    private readonly ObservableCollection<GameEntity> _gameEntities = new();

    public ReadOnlyObservableCollection<GameEntity> GameEntities { get; private set; }

    public ICommand AddEntityCommand { get; private set; }
    public ICommand RemoveEntityCommand { get; private set; }

    public Scene(Project project, string name) {
        Debug.Assert(project != null);
        Project = project;
        Name = name;
        OnDeserialized(new());
    }

    [OnDeserialized]
    private void OnDeserialized(StreamingContext context) {
        if (_gameEntities != null) {
            GameEntities = new(_gameEntities);
            OnPropertyChanged(nameof(GameEntities));
        }

        foreach (var entity in _gameEntities) {
            entity.IsActive = IsActive;
        }

        AddEntityCommand = new RelayCommand<GameEntity>(x => {
            AddGameEntity(x);
            var entityIndex = _gameEntities.Count - 1;

            Project.UndoRedo.Add(new UndoRedoAction(
                    () => RemoveGameEntity(x),
                    () => AddGameEntity(x, entityIndex),
                    $"Add {x.Name} to {Name}"
                ));
        });

        RemoveEntityCommand = new RelayCommand<GameEntity>(x => {
            var entityIndex = _gameEntities.IndexOf(x);
            RemoveGameEntity(x);
            Project.UndoRedo.Add(new UndoRedoAction(
                    () => AddGameEntity(x, entityIndex),
                    () => RemoveGameEntity(x),
                    $"Removed {x.Name} from {Name}"
                ));
        });
    }

    private void AddGameEntity(GameEntity gameEntity, int index = -1) {
        Debug.Assert(!_gameEntities.Contains(gameEntity));

        gameEntity.IsActive = IsActive;
        if (index == -1) {
            _gameEntities.Add(gameEntity);
        } else {
            _gameEntities.Insert(index, gameEntity);
        }
    }

    private void RemoveGameEntity(GameEntity gameEntity) {
        Debug.Assert(_gameEntities.Contains(gameEntity));
        gameEntity.IsActive = false;
        _gameEntities.Remove(gameEntity);
    }
}