using UnityEngine;

namespace BattleChess.Entity
{
    public class ChampionComponent : MonoBehaviour
    {
        protected Champion champion;

        public virtual void SetChampion(Champion newChampion)
        {
            champion = newChampion;
        }

        public virtual void Initialize()
        {

        }

        protected T GetChampionComponent<T>() where T : ChampionComponent
        {
            return champion.GetChampionComponent<T>();
        }
    }
}