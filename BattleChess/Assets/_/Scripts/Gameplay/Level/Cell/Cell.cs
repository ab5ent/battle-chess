using BattleChess.Entity;
using System;
using UnityEngine;

namespace BattleChess.LevelStructure
{
    [Serializable]
    public class Cell
    {
        private CellGenerator generator;

        private bool isInitialized;

        [field: SerializeField]
        public int Row { get; private set; }

        [field: SerializeField]
        public int Column { get; private set; }

        [field: SerializeField]
        public Champion CurrentChampion { get; private set; }

        public Cell(CellGenerator cellGenerator)
        {
            generator = cellGenerator;
            isInitialized = false;
            Row = int.MinValue;
            Column = int.MinValue;
        }

        public void SetChampion(Champion newChampion)
        {
            CurrentChampion = newChampion;
        }

        public void ClearChampion()
        {
            CurrentChampion = null;
        }

        public void Activate(int row, int column)
        {
            isInitialized = true;
            Row = row;
            Column = column;
            ClearChampion();
        }

        public void Deactivate()
        {
            isInitialized = false;
            Row = int.MinValue;
            Column = int.MinValue;
            ClearChampion();
            generator.Release(this);
        }
    }
}