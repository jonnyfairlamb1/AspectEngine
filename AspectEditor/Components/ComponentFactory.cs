using System;
using System.Diagnostics;

namespace AspectEditor.Components {

    public enum ComponentType {
        Transform,
        Script,
    }

    public static class ComponentFactory {

        private static readonly Func<GameEntity, object, Component>[] _function = new Func<GameEntity, object, Component>[] {
            (entity, data) => new Transform(entity),
            (entity, data) => new Script(entity){Name = (string)data},
        };

        public static Func<GameEntity, object, Component> GetCreateFuntion(ComponentType componentType) {
            Debug.Assert((int)componentType < _function.Length);
            return _function[(int)componentType];
        }

        public static ComponentType ToEnumType(this Component component) {
            return component switch {
                Transform _ => ComponentType.Transform,
                Script _ => ComponentType.Script,
                _ => throw new ArgumentException("Uknown component type"),
            };
        }
    }
}