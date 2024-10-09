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
    }
}