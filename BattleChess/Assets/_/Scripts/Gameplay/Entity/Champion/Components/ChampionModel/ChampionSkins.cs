using System.Collections.Generic;
using System;
using UnityEngine;
using System.Linq;

namespace BattleChess.Entity
{
    public class ChampionSkins : ChampionComponent
    {
        [field: SerializeField]
        public Material OriginalMaterial { get; protected set; }

        [SerializeField]
        private ChampionSkinInfo[] info;

        public ChampionSkinInfo GetChampionSkinInfo(ChampionId id)
        {
            for (int i = 0; i < info.Length; i++)
            {
                if (info[i].Id == id)
                {
                    return info[i];
                }
            }

            return null;
        }


        [ContextMenu("Get Champion Skins")]
        private void GenerateListChampionTextureInfo()
        {
            List<ChampionId> listChampionIds = Enum.GetValues(typeof(ChampionId)).Cast<ChampionId>().ToList();
            info = new ChampionSkinInfo[listChampionIds.Count];

            for (int i = 0; i < info.Length; i++)
            {
                info[i] = new ChampionSkinInfo(listChampionIds[i]);
            }
        }
    }
}