using BattleChess.Common;
using UnityEngine;

namespace BattleChess.Entity
{
    public class ChampionDragCollider : DraggableObject
    {
        private Champion champion;

        public void SetChampion(Champion newChampion)
        {
            champion = newChampion;
        }

        private Vector3 GetChampionPositionToScreenPoint()
        {
            return Camera.main.WorldToScreenPoint(champion.transform.position);
        }

        public override void SetSelected(bool value)
        {
            base.SetSelected(value);
            mousePosition = Input.mousePosition - GetChampionPositionToScreenPoint();
        }

        protected override void MouseDragOnObject()
        {
            var newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition);
            if ((newPosition - lastPosition).magnitude >= Mathf.Epsilon)
            {
                champion.GetChampionComponent<ChampionBoardLocation>().SetToBoardCellCenter(newPosition);
            }
            lastPosition = newPosition;
        }

        protected override void MouseDownOnObject()
        {
            mousePosition = Input.mousePosition - GetChampionPositionToScreenPoint();
        }

        protected override void MouseUpOnObject()
        {
            champion.GetChampionComponent<ChampionBoardLocation>().PlaceToBoardCellCenter(lastPosition);
        }
    }
}