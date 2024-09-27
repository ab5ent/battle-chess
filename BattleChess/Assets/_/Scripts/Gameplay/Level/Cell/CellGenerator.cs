using BattleChess.Managers;
using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleChess.LevelStructure
{
    public class CellGenerator : MonoBehaviour
    {
        private LevelManager manager;

        [SerializeField]
        private List<Cell> freeCells;

        public Cell GetCell()
        {
            if (freeCells.Count > 0)
            {
                Cell deactivatedCell = freeCells[0];
                freeCells.RemoveAt(0);

                return deactivatedCell;
            }

            Cell cell = new GameObject("Cell").AddComponent<Cell>();
            cell.transform.SetParent(transform);
            cell.Initialize(this);
            return cell;
        }

        public void Release(Cell cell)
        {
            cell.transform.SetParent(transform);
            freeCells.Add(cell);
        }

        public void SetManager(LevelManager levelManager)
        {
            manager = levelManager;
        }
    }
}