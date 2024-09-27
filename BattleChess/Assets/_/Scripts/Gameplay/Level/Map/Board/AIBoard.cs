using BattleChess.Team;

namespace BattleChess.LevelStructure
{
    public class AIBoard : Board
    {
        public override void Initialize(TeamController teamController)
        {
            base.Initialize(teamController);
            SetStructure(teamController.CurrentLevel.Variables.InformationOfBoard.AIBoardStructure);
        }

        public override void ProcessPrepareState()
        {
        }
    }
}