using BattleChess.AreaStructure;
using System;
using UnityEngine;

namespace BattleChess.LevelStructure
{
    [Serializable]
    public class LevelReferences
    {
        [field: SerializeField]
        public Area[] Areas { get; private set; }
    }
}