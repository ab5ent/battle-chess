using UnityEngine;

namespace BattleChess.ObjectPooling
{
    public class PooledObject : MonoBehaviour
    {
        [field: SerializeField]
        public PooledObjectId Id { get; private set; }

        private PooledObjectControl pooledObjectControl;

        public void SetPoolObjectControl(PooledObjectControl newPooledObjectControl)
        {
            pooledObjectControl = newPooledObjectControl;
        }

        public void ReturnToPool()
        {
            pooledObjectControl.Pool.Release(this);
        }

        public void SetActive(bool value)
        {
            gameObject.SetActive(value);
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}