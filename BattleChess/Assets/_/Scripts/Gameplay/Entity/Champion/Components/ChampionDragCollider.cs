using BattleChess.Common;

namespace BattleChess.Entity
{
    public class ChampionDragCollider : DraggableObject
    {
        private Champion champion;

        public void SetChampion(Champion newChampion)
        {
            champion = newChampion;
        }
    }
}