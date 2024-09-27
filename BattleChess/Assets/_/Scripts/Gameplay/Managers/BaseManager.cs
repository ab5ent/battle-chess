using UnityEngine;

namespace BattleChess.Managers
{
    public class BaseManager : MonoBehaviour
    {
        protected GameManager manager;

        public virtual void Initialize(GameManager gameManager)
        {
            manager = gameManager;
        }
    }
}