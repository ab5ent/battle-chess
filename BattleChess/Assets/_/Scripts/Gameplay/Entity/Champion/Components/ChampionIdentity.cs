using BattleChess.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleChess.Entity
{
    public class ChampionIdentity : ChampionComponent
    {
        [field: SerializeField]
        public ChampionId Id { get; private set; }

        private void Awake()
        {
        }

        public void SetChampionIdentity(ChampionId id)
        {
            Id = id;
            GetChampionComponent<ChampionModel>().SetModel(Id);
        }

        private void Update()
        {
        }
    }
}