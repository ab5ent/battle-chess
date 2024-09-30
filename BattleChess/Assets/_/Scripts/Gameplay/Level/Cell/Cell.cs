using BattleChess.Entity;
using UnityEngine;

namespace BattleChess.LevelStructure
{
    public class Cell : MonoBehaviour
    {
        private CellGenerator generator;

        private bool isInitialized;

        [field: SerializeField]
        public int Row { get; private set; }

        [field: SerializeField]
        public int Column { get; private set; }

        [field: SerializeField]
        public Champion CurrentChampion { get; private set; }

        public void SetActive(bool value)
        {
            gameObject.SetActive(value);
        }

        public void SetPositionAndRotation(Vector3 position, Quaternion quaternion)
        {
            transform.SetPositionAndRotation(position, quaternion);
        }

        public void SetParent(Transform holder)
        {
            transform.SetParent(holder);
        }

        public void Initialize(CellGenerator cellGenerator)
        {
            generator = cellGenerator;
            isInitialized = false;
            Row = int.MinValue;
            Column = int.MinValue;
            SetActive(false);
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
            SetActive(true);
        }

        public void Deactivate()
        {
            isInitialized = false;
            Row = int.MinValue;
            Column = int.MinValue;
            ClearChampion();
            SetActive(false);

            generator.Release(this);
        }
    }
}