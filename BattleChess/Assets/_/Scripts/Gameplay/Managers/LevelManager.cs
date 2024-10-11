using BattleChess.Common;
using BattleChess.LevelStructure;
using System;
using UnityEngine;

namespace BattleChess.Managers
{
    public class LevelManager : BaseManager
    {
        [field: SerializeField]
        public Level CurrentLevel { get; private set; }

        [SerializeField]
        private CellGenerator cellGenerator;

        [SerializeField]
        private DragObjectController dragObjectController;

        public override void Initialize(GameManager gameManager)
        {
            base.Initialize(gameManager);
            cellGenerator.SetManager(this);
            dragObjectController.SetManager(this);
        }

        public void LoadLevel(LevelType levelType, int levelId)
        {
            CurrentLevel?.DeInitialize();
            Level levelPrefab = Resources.Load<Level>($"Levels/{levelType}/Level_{levelType}_{levelId}");
            CurrentLevel = Instantiate(levelPrefab, transform);
            CurrentLevel.Initialize(this);
        }

        public Cell GetCell()
        {
            return cellGenerator.GetCell();
        }

        public void OnChangeLevelState(LevelState state)
        {
            dragObjectController.OnChangeLevelState(state);
        }
    }
}