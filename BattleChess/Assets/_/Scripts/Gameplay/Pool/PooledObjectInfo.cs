using System;
using UnityEngine;

namespace BattleChess.ObjectPooling
{
    [Serializable]
    public class PooledObjectInfo
    {
        [field: SerializeField]
        public PooledObjectId Id { get; private set; }

        [field: SerializeField]
        public PooledObject Prefab { get; private set; }

        [field: SerializeField]
        public bool CollectionCheck { get; private set; } = false;

        [field: SerializeField]
        public int DefaultCapacity { get; private set; }

        [field: SerializeField]
        public int MaxCapacity { get; private set; }
    }
}