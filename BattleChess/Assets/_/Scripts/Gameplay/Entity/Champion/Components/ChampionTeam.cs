using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleChess.Entity
{
    public class ChampionTeam : ChampionComponent
    {
        [field: SerializeField]
        public Team team { get; private set; }

    }
}