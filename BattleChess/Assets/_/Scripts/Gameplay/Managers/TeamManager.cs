using BattleChess.Team;
using System.Collections.Generic;

namespace BattleChess.Managers
{
    public class TeamManager : BaseManager
    {
        private Dictionary<TeamId, TeamController> teamControllers;

        public override void Initialize(GameManager gameManager)
        {
            manager = gameManager;

            teamControllers = new Dictionary<TeamId, TeamController>();
            TeamController[] allTeamControllers = GetComponentsInChildren<TeamController>();
            for (int i = 0; i < allTeamControllers.Length; i++)
            {
                teamControllers.Add(allTeamControllers[i].Id, allTeamControllers[i]);
            }
        }

        public TeamController GetTeamController(TeamId id)
        {
            return teamControllers.GetValueOrDefault(id);
        }
    }
}