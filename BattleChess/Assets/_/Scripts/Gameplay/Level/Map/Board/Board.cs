using BattleChess.Entity;
using BattleChess.Team;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace BattleChess.LevelStructure
{
    public abstract class Board : MonoBehaviour
    {
        protected TeamController controller;

        protected BoardStructure structure;

        protected Grid unityGrid;

        [SerializeField]
        protected List<Cell> cells;

        public virtual void Initialize(TeamController teamController)
        {
            controller = teamController;
            unityGrid = controller.CurrentLevel.Ref.UnityGrid;
            cells = new List<Cell>();
        }

        public void SetStructure(BoardStructure newStructure)
        {
            structure = newStructure;
        }

        public void SetCells()
        {
            for (int rowIndex = structure.StartRowIndex; rowIndex <= structure.EndRowIndex; rowIndex++)
            {
                for (int columnIndex = structure.StartColumnIndex; columnIndex <= structure.EndColumnIndex; columnIndex++)
                {
                    Cell cell = controller.CurrentLevel.GetCell();
                    cell.Activate(rowIndex, columnIndex);
                    cells.Add(cell);
                }
            }
        }

        public void ClearCells()
        {
            for (int i = 0; i < cells.Count; i++)
            {
                cells[i].Deactivate();
            }
        }

        public abstract void ProcessPrepareState();

        #region MonoBehaviour

        protected virtual void OnDrawGizmosSelected()
        {
            if (!unityGrid || structure == null)
                return;

            Gizmos.color = Color.red;

            for (int rowIndex = structure.StartRowIndex; rowIndex <= structure.EndRowIndex; rowIndex++)
            {
                for (int columnIndex = structure.StartColumnIndex; columnIndex <= structure.EndColumnIndex; columnIndex++)
                {
                    Vector3 position = unityGrid.CellToWorld(new Vector3Int(rowIndex, 0, columnIndex));
                    Gizmos.DrawWireCube(position, new Vector3(1, 0.05f, 1));
                }
            }
        }

        #endregion

        public virtual void DeInitialize()
        {
            for (int i = 0; i < cells.Count; i++)
            {
                cells[i].Deactivate();
            }
        }

        public virtual void AddChampion(Champion champion, int rowIndex, int columnIndex)
        {
            champion.SetBoard(this);

            for (int i = 0; i < cells.Count; i++)
            {
                if (cells[i].Row == rowIndex && cells[i].Column == columnIndex)
                {
                    cells[i].SetChampion(champion);
                    Vector3 position = unityGrid.CellToWorld(new Vector3Int(rowIndex, 0, columnIndex));
                    champion.SetPositionAndRotation(position, Quaternion.identity);
                }
            }
        }

        public Vector3 ConvertToGridPosition(Vector3 position)
        {
            Vector3Int cellPosition = unityGrid.WorldToCell(position);
            cellPosition.x = Mathf.Clamp(cellPosition.x, structure.StartRowIndex, structure.EndRowIndex);
            cellPosition.y = 0;
            cellPosition.z = Mathf.Clamp(cellPosition.z, structure.StartColumnIndex, structure.EndColumnIndex);
            return unityGrid.CellToWorld(cellPosition);
        }

        public Vector3Int Get(Vector3 position)
        {
            Vector3Int cellPosition = unityGrid.WorldToCell(position);
            cellPosition.x = Mathf.Clamp(cellPosition.x, structure.StartRowIndex, structure.EndRowIndex);
            cellPosition.y = 0;
            cellPosition.z = Mathf.Clamp(cellPosition.z, structure.StartColumnIndex, structure.EndColumnIndex);

            return cellPosition;
        }
    }
}