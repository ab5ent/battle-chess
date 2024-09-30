using System;
using UnityEngine;

namespace BattleChess.Common
{
    [Serializable]
    public class DraggableObjectInfo
    {
        [field: SerializeField]
        public DraggableObjectId Id { get; private set; }

        [field: SerializeField]
        public LayerMask DraggableLayerMask { get; private set; }
    }
}