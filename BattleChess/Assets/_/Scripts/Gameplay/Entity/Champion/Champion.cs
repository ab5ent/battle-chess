using UnityEngine;

namespace BattleChess.Team
{
    public class Champion : MonoBehaviour
    {
        private TeamController controller;

        public void Initialize()
        {
            gameObject.SetActive(true);
        }

        #region Utility

        public void SetTeamController(TeamController teamController)
        {
            controller = teamController;
        }

        public void SetParent(Transform holder)
        {
            transform.SetParent(holder);
        }

        public void SetLocalPositionAndRotation(Vector3 position, Quaternion rotation)
        {
            transform.SetLocalPositionAndRotation(position, rotation);
        }

        #endregion
    }
}