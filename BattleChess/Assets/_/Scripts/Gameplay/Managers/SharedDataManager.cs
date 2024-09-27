using BattleChess.Entity;
using UnityEngine;

namespace BattleChess.Managers
{
    public class SharedDataManager : BaseManager
    {
        [SerializeField]
        private ChampionSharedData championSharedData;

        public Texture GetChampionTexture(ChampionId id)
        {
            return championSharedData.GetChampionTexture(id);
        }
    }
}