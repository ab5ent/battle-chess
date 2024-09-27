using BattleChess.Team;
using System;
using UnityEngine;

namespace BattleChess.LevelStructure
{
    [Serializable]
    public class LevelReferences
    {
        [field: SerializeField]
        public TeamController UserTeamController { get; private set; }

        [field: SerializeField]
        public TeamController AITeamController { get; private set; }

        [field: SerializeField]
        public Grid UnityGrid { get; private set; }
    }
}