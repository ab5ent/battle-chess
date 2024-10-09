using BattleChess.LevelStructure;
using UnityEngine;
using UnityEngine.UIElements;

namespace BattleChess.Entity
{
    public class ChampionBoardLocation : ChampionComponent
    {
        private Board board;

        private Cell currentCell, selectedCell;

        public void SetBoard(Board newBoard)
        {
            board = newBoard;
        }

        public void SetTemporaryOnBoard(Vector3 position)
        {
            Cell cell = board.GetCell(position);
            if (cell)
            {
                SwapSelectedCell(cell);
                SetPosition(cell.Position, Vector3.up * 1.5f);
            }
        }

        public void ReturnToCurrentCell()
        {
            SetPosition(currentCell.Position, Vector3.zero);
            SetSelectedCell(null);
        }

        public void SwapOnBoard()
        {
            if (!selectedCell)
            {
                ReturnToCurrentCell();
                return;
            }

            Champion selectedCellChampion = selectedCell.CurrentChampion;
            Cell _currentCell = currentCell;

            selectedCell.SetChampion(champion);
            SetCurrentCell(selectedCell);
            SetPosition(selectedCell.Position, Vector3.zero);

            _currentCell.SetChampion(selectedCellChampion);
            selectedCellChampion?.GetChampionComponent<ChampionBoardLocation>().SetCurrentCell(_currentCell);
            selectedCellChampion?.GetChampionComponent<ChampionBoardLocation>().SetPosition(_currentCell.Position, Vector3.zero);

            SetSelectedCell(null);
        }

        public void SwapSelectedCell(Cell cell)
        {
            if (cell == null)
            {
                return;
            }

            Cell oldCell = selectedCell;
            SetSelectedCell(cell);
            oldCell?.RefreshPreview();
            selectedCell?.OnDragChampionOnPreview(champion);
        }

        public void SetCurrentCell(Cell cell)
        {
            currentCell = cell;
        }

        public void SetSelectedCell(Cell cell)
        {
            selectedCell = cell;
        }

        public void SetPosition(Vector2Int intPosition, Vector3 offset)
        {
            Vector3 onBoardPosition = board.GetWorldPosition(new Vector3Int(intPosition.x, 0, intPosition.y));
            champion.SetLocalPositionAndRotation(onBoardPosition + offset, Quaternion.identity);
        }
    }
}