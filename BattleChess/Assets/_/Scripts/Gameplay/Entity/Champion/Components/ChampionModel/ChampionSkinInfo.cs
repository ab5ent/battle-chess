using BattleChess.Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace BattleChess.Entity
{
    [Serializable]
    public class ChampionSkinInfo
    {
        [field: SerializeField]
        public ChampionId Id { get; private set; }

        [field: SerializeField, FormerlySerializedAs("skinnedMeshRenderer")]
        public SkinnedMeshRenderer Skin { get; private set; }

        public ChampionSkinInfo(ChampionId id)
        {
            Id = id;
        }
    }
}