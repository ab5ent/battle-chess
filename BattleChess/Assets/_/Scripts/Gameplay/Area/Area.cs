using BattleChess.Managers;
using UnityEngine;

namespace BattleChess.AreaStructure
{
    public class Area : MonoBehaviour
    {
        [field: SerializeField]
        public AreaReferences References { get; private set; }

        [field: SerializeField]
        public AreaVariables Variables { get; private set; }

        public void Initialize()
        {
            GameManager.GetManager<BoardManager>().AssignGridMapToArea(this);
        }
    }
}