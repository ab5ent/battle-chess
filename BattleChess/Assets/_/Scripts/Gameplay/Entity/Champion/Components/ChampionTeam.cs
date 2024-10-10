using BattleChess.Managers;
using BattleChess.Team;

namespace BattleChess.Entity
{
    public class ChampionTeam : ChampionComponent
    {
        private TeamController teamController;

        public void AssignToTeam(TeamId id)
        {
            teamController = GameManager.Instance.TeamManager.GetTeamController(id);
            champion.SetParent(teamController.transform);
        }
    }
}