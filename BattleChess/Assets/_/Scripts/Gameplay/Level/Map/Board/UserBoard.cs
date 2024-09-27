using BattleChess.Team;
using UnityEngine;

namespace BattleChess.LevelStructure
{
    public class UserBoard : Board
    {
        public override void ProcessPrepareState()
        {

        }

        public override void Initialize(TeamController teamController)
        {
            base.Initialize(teamController);
            SetStructure(controller.CurrentLevel.Variables.InformationOfBoard.UserBoardStructure);
            SetCells();
        }

        protected override void OnDrawGizmosSelected()
        {
            //Gizmos.color = Color.green;

            //base.OnDrawGizmosSelected();

            //if (draw)
            //{
            //    Gizmos.color = Color.cyan;
            //    Gizmos.DrawWireCube(selectedGridPosition + (Vector3.up / 2), Vector3.one);
            //}
        }
    }
}