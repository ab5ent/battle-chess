using UnityEngine;
using UnityEngine.Pool;

namespace BattleChess.ObjectPooling
{
    public class PooledObjectControl : MonoBehaviour
    {
        [field: SerializeField]
        public PooledObjectInfo Info { get; private set; }

        public IObjectPool<PooledObject> Pool { get; private set; }

        public void Initialize(PooledObjectInfo info)
        {
            Info = info;
        }

        public PooledObject GetPooledObject()
        {
            Pool ??= new ObjectPool<PooledObject>(
                OnCreatedPooledItem,
                OnTakeFromPool,
                OnReturnedToPool,
                OnDestroyPooledObject,
                Info.CollectionCheck,
                Info.DefaultCapacity,
                Info.MaxCapacity
            );

            return Pool.Get();
        }

        private PooledObject OnCreatedPooledItem()
        {
            PooledObject pooledObject = Instantiate(Info.Prefab, transform);
            pooledObject.SetPoolObjectControl(this);
            return pooledObject;
        }

        private void OnTakeFromPool(PooledObject pooledObject)
        {

        }

        private void OnReturnedToPool(PooledObject pooledObject)
        {
            pooledObject.Deactivate();
        }

        private void OnDestroyPooledObject(PooledObject pooledObject)
        {
            pooledObject.Destroy();
        }
    }
}