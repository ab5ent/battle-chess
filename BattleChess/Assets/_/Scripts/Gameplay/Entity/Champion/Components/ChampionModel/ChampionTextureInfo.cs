using BattleChess.Entity;
using System;
using UnityEngine;

namespace BattleChess.SharedData
{
    [Serializable]
    public class ChampionTextureInfo
    {
        [SerializeField]
        private string name;

        [field: SerializeField]
        public ChampionId Id { get; private set; }

        [field: SerializeField]
        public Texture2D Texture { get; private set; }

        public ChampionTextureInfo(ChampionId id)
        {
            Id = id;
            name = Id.ToString();
        }
    }
}