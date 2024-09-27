using System;
using UnityEngine;

namespace BattleChess.LevelStructure
{
    [Serializable]
    public class BoardInformation
    {
        [field: SerializeField]
        public BoardForm Form { get; private set; }

        [field: SerializeField]
        public int TotalRows { get; private set; }

        [field: SerializeField]
        public int TotalColumns { get; private set; }

        [field: SerializeField]
        public BoardStructure UserBoardStructure { get; private set; }

        [field: SerializeField]
        public BoardStructure AIBoardStructure { get; private set; }
    }
}