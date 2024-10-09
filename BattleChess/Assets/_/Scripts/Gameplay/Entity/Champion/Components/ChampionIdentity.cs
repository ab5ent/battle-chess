using BattleChess.Managers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleChess.Entity
{
    public class ChampionIdentity : ChampionComponent
    {
        private readonly static System.Random random = new System.Random();

        public static ChampionId GetRandomChampionId()
        {
            Type type = typeof(ChampionId);
            Array values = Enum.GetValues(type);
            lock (random)
            {
                object value = values.GetValue(random.Next(values.Length));
                return (ChampionId)Convert.ChangeType(value, type);
            }
        }

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