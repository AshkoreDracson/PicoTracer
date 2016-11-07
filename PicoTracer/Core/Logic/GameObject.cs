using System.Collections.Generic;
namespace PicoTracer
{
    public class GameObject
    {
        private static uint curID = 0;

        private static List<GameObject> _gameObjects = new List<GameObject>();
        private List<Component> _components = new List<Component>();

        public uint ID { get; private set; }
        public string Name { get; set; }

        public Transform transform { get; private set; }

        public GameObject(string name)
        {
            ID = curID++;
            Name = name;

            transform = AddComponent<Transform>();
        }

        public T AddComponent<T>() where T : Component, new()
        {
            T newComp = new T();
            newComp.gameObject = this;
            _components.Add(newComp);
            newComp.Start();
            return newComp;
        }

        public T GetComponent<T>() where T : Component
        {
            foreach (Component comp in _components)
            {
                if (comp is T)
                {
                    return (T)comp;
                }
            }
            return null;
        }

        public Component[] GetAllComponents()
        {
            return _components.ToArray();
        }

        public void RemoveComponent<T>() where T : Component
        {
            foreach (Component comp in _components)
            {
                if (comp.GetType() == typeof(T))
                {
                    _components.Remove(comp);
                }
            }
        }

        // STATIC METHODS & FUNCTIONS

        public static GameObject[] GetAllGameObjects()
        {
            return _gameObjects.ToArray();
        }

        public static T[] GetAllComponentsByType<T>() where T : Component
        {
            List<T> components = new List<T>();
            GameObject[] gameObjects = GetAllGameObjects();
            foreach (GameObject go in gameObjects)
            {
                foreach (Component comp in go.GetAllComponents())
                {
                    if (comp is T)
                    {
                        components.Add((T)comp);
                    }
                }
            }
            return components.ToArray();
        }
    }
}