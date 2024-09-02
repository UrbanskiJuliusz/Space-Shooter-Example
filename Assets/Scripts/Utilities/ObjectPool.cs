using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter.Utilities
{
    public class ObjectPool<T> where T : Component
    {
        private readonly GameObject prefab;
        private readonly Queue<T> pool = new Queue<T>();
        private readonly Transform parentTransform;

        public ObjectPool(GameObject prefab, int initialSize, Transform parent = null)
        {
            this.prefab = prefab;
            this.parentTransform = parent;

            for (int i = 0; i < initialSize; i++)
            {
                GameObject obj = Object.Instantiate(prefab, parentTransform);
                obj.SetActive(false);
                pool.Enqueue(obj.GetComponent<T>());
            }
        }

        public T GetObject(Vector3 position, Quaternion rotation)
        {
            T objComponent;
            if (pool.Count > 0)
            {
                objComponent = pool.Dequeue();
            }
            else
            {
                GameObject obj = Object.Instantiate(prefab, parentTransform);
                objComponent = obj.GetComponent<T>();
            }

            objComponent.transform.position = position;
            objComponent.transform.rotation = rotation;
            objComponent.gameObject.SetActive(true);

            return objComponent;
        }

        public void ReturnObject(T objComponent)
        {
            objComponent.gameObject.SetActive(false);
            pool.Enqueue(objComponent);
        }
    }
}