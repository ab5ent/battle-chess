using BattleChess.LevelStructure;
using UnityEngine;

namespace BattleChess.Managers
{
    public class LevelManager : BaseManager
    {
        [field: SerializeField]
        public Level CurrentLevel { get; private set; }

        [SerializeField]
        private BoardData boardData;

        [SerializeField]
        private CellGenerator cellGenerator;

        [SerializeField]
        private InputController inputController;

        public override void Initialize(GameManager gameManager)
        {
            base.Initialize(gameManager);
            cellGenerator.SetManager(this);
            inputController.SetManager(this);
        }

        public void LoadLevel(LevelType levelType, int levelId)
        {
            CurrentLevel?.DeInitialize();
            Level levelPrefab = Resources.Load<Level>($"Levels/{levelType}/Level_{levelType}_{levelId}");
            CurrentLevel = Instantiate(levelPrefab, transform);
            CurrentLevel.Initialize(this);
        }

        public BoardInformation GetBoardInformation(BoardForm form)
        {
            return boardData.GetBoardInformation(form);
        }

        public Cell GetCell()
        {
            return cellGenerator.GetCell();
        }
    }
}