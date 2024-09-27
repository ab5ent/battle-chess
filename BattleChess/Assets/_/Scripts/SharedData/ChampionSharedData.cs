using BattleChess.Entity;
using BattleChess.SharedData;
using BattleChess.Team;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BattleChess
{
    [CreateAssetMenu(fileName = "ChampionSharedData", menuName = "Data/ChampionSharedData")]
    public class ChampionSharedData : ScriptableObject
    {
        [SerializeField]
        private ChampionTextureInfo[] textureData;

        [ContextMenu("Generate Champion Texture Info")]
        private void GenerateListChampionTextureInfo()
        {
            List<ChampionId> listChampionIds = Enum.GetValues(typeof(ChampionId)).Cast<ChampionId>().ToList();
            textureData = new ChampionTextureInfo[listChampionIds.Count];

            for (int i = 0; i < textureData.Length; i++)
            {
                textureData[i] = new ChampionTextureInfo(listChampionIds[i]);
            }
        }

        public Texture GetChampionTexture(ChampionId id)
        {
            for (int i = 0; i < textureData.Length; i++)
            {
                if (textureData[i].Id == id)
                {
                    return textureData[i].Texture;
                }
            }

            return null;
        }
    }
}