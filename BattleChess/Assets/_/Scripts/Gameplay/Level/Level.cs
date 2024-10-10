using BattleChess.Team;
using BattleChess.Managers;
using UnityEngine;
using BattleChess.Entity;

namespace BattleChess.LevelStructure
{
    public class Level : MonoBehaviour
    {
        protected LevelManager manager;

        [field: SerializeField]
        public LevelConfigures Config { get; private set; }

        [field: SerializeField]
        public LevelReferences Ref { get; private set; }

        [field: SerializeField]
        public LevelRuntimeVariables Variables { get; private set; }

        public void Initialize(LevelManager levelManager)
        {
            manager = levelManager;

            Variables.State = LevelState.OnInitialize;
            Variables.InformationOfBoard = levelManager.GetBoardInformation(Config.FormOfBoard);

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
                    break;
                case LevelState.Prepare:
                    {
                        break;
                    }
                case LevelState.OnBattle:
                    break;
            }

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                var champ = GameManager.Instance.PoolManager.GetPooledObject<Champion>(ObjectPooling.PooledObjectId.Champion);
                champ.SetIdentity(ChampionIdentity.GetRandomChampionId());
                champ.SetTeam(TeamId.User);
            }
        }

        public Cell GetCell()
        {
            return manager.GetCell();
        }

        public virtual void DeInitialize()
        {
            Variables.State = LevelState.OnDeInitialize;
            Destroy(gameObject);
        }
    }
}