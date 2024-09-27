using System;
using UnityEngine;

namespace BattleChess.LevelStructure
{
    [Serializable]
    public class LevelConfigures
    {
        [field: SerializeField]
        public BoardForm FormOfBoard { get; private set; }
    }
}