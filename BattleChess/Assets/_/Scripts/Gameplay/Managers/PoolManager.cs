using BattleChess.ObjectPooling;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace BattleChess.Managers
{
    public class PoolManager : BaseManager
    {
        [SerializeField]
        private PooledData data;

        private Dictionary<PooledObjectId, PooledObjectControl> poolDictionary;

        public override void Initialize(GameManager gameManager)
        {
            base.Initialize(gameManager);

            poolDictionary = new Dictionary<PooledObjectId, PooledObjectControl>();
            PooledObjectId[] ids = (PooledObjectId[])Enum.GetValues(typeof(PooledObjectId));

            for (int i = 0; i < ids.Length; i++)
            {
                GameObject holder = new GameObject($"(Holder)_{ids[i]}");
                holder.transform.SetParent(transform);
                holder.transform.SetAsLastSibling();
                PooledObjectControl control = holder.AddComponent<PooledObjectControl>();
                control.Initialize(data.GetObjectInfo(ids[i]));
                poolDictionary.Add(ids[i], control);
            }
        }

        public T GetPooledObject<T>(PooledObjectId id) where T : Component
        {
            poolDictionary.TryGetValue(id, out PooledObjectControl pooledObjectControl);
            PooledObject pooledObject = pooledObjectControl.GetPooledObject();
            return pooledObject ? pooledObject.GetComponent<T>() : null;
        }
    }
}