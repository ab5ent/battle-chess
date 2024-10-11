using BattleChess.Managers;
using Unity.VisualScripting;
using UnityEngine;

namespace BattleChess.LevelStructure
{
    public class Level : MonoBehaviour
    {
        protected LevelManager manager;

        [field: SerializeField]
        public LevelReferences Ref { get; private set; }

        [field: SerializeField]
        public LevelRuntimeVariables Variables { get; private set; }

        public void Initialize(LevelManager levelManager)
        {
            manager = levelManager;
            SetState(LevelState.OnInitialize);
        }

        public void Begin()
        {
            Variables.CurrentArea = Ref.Areas[0];
            Variables.CurrentArea.Initialize();
            SetState(LevelState.Prepare);
        }

        private void SetState(LevelState newLevelState)
        {
            Variables.State = newLevelState;
            manager.OnChangeLevelState(Variables.State);
        }

        private void Update()
        {
            switch (Variables.State)
            {
                case LevelState.None:
                    {
                        break;
                    }
                case LevelState.Prepare:
                    {
                        break;
                    }
                case LevelState.OnBattle:
                    {
                        break;
                    }
            }
        }

        public virtual void DeInitialize()
        {
            Variables.State = LevelState.OnDeInitialize;
            Destroy(gameObject);
        }
    }
}