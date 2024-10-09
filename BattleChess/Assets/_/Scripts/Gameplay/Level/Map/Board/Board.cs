using BattleChess.Entity;
using BattleChess.Team;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.FilePathAttribute;

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
                    cell.SetPositionAndRotation(unityGrid.CellToWorld(new Vector3Int(rowIndex, 0, columnIndex)), cell.transform.rotation);
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

        protected virtual void OnDrawGizmos()
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

        public virtual void AddChampion(Champion champion, Vector2Int location)
        {
            champion.SetBoard(this);

            for (int i = 0; i < cells.Count; i++)
            {
                if (cells[i].Position.x == location.x && cells[i].Position.y == location.y)
                {
                    cells[i].SetChampion(champion);
                    Vector3 position = unityGrid.CellToWorld(new Vector3Int(cells[i].Position.x, 0, cells[i].Position.y));
                    champion.SetPositionAndRotation(position, Quaternion.identity);
                }
            }
        }

        public virtual void AddChampion(Champion champion)
        {
            champion.SetBoard(this);

            for (int i = 0; i < cells.Count; i++)
            {
                if (cells[i].CurrentChampion == null)
                {
                    cells[i].SetChampion(champion);
                    champion.GetChampionComponent<ChampionBoardLocation>().SetCurrentCell(cells[i]);
                    champion.GetChampionComponent<ChampionBoardLocation>().ReturnToCurrentCell();
                    return;
                }
            }
        }

        public Cell GetCell(Vector3 position)
        {
            Vector3Int cellPosition = unityGrid.WorldToCell(position);
            cellPosition.x = Mathf.Clamp(cellPosition.x, structure.StartRowIndex, structure.EndRowIndex);
            cellPosition.z = Mathf.Clamp(cellPosition.z, structure.StartColumnIndex, structure.EndColumnIndex);
            return GetCell(cellPosition.x, cellPosition.z);
        }

        public Cell GetCell(int rowIndex, int columnIndex)
        {
            for (int i = 0; i < cells.Count; i++)
            {
                if (cells[i].Position.x == rowIndex && cells[i].Position.y == columnIndex)
                {
                    return cells[i];
                }
            }

            return null;
        }

        public Vector3 GetWorldPosition(Vector3Int vector3Int)
        {
            return unityGrid.CellToWorld(vector3Int);
        }
    }
}