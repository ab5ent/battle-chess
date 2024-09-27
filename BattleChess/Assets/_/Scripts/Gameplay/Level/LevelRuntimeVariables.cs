using System;
using UnityEngine;

namespace BattleChess.LevelStructure
{
    [Serializable]
    public class LevelRuntimeVariables
    {
        [field: SerializeField]
        public LevelState State { get; set; }

        [field: SerializeField]
        public BoardInformation InformationOfBoard { get; set; }
    }
}