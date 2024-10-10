using System;
using UnityEngine;

namespace BattleChess.LevelStructure
{
    [Serializable]
    public class LevelReferences
    {
        [field: SerializeField]
        public Grid UnityGrid { get; private set; }
    }
}