using BattleChess.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleChess.LevelStructure
{
    public class CellGenerator : MonoBehaviour
    {
        private LevelManager manager;

        [SerializeField]
        private Transform holder;

        [SerializeField]
        private List<Cell> freeCells;

        [SerializeField]
        private Cell cellPrefab;

        public Cell GetCell()
        {
            if (freeCells.Count > 0)
            {
                Cell deactivatedCell = freeCells[0];
                freeCells.RemoveAt(0);

                return deactivatedCell;
            }

            Cell cell = Instantiate(cellPrefab, holder);
            cell.Initialize(this);
            return cell;
        }

        public void Release(Cell cell)
        {
            freeCells.Add(cell);
        }

        public void SetManager(LevelManager levelManager)
        {
            manager = levelManager;
        }
    }
}