using BattleChess.Entity;
using UnityEngine;
using UnityEngine.UIElements;

namespace BattleChess.LevelStructure
{
    public class Cell : MonoBehaviour
    {
        private CellGenerator generator;

        private Vector2Int position;

        [SerializeField]
        private SpriteRenderer preview;

        [SerializeField]
        public Vector2Int Position => position;

        [field: SerializeField]
        public Champion CurrentChampion { get; private set; }

        public void Initialize(CellGenerator cellGenerator)
        {
            generator = cellGenerator;
            name = $"Cell_[unassigned]";
            position = new Vector2Int(int.MinValue, int.MinValue);
            SetActive(false);
        }

        public void SetChampion(Champion newChampion)
        {
            CurrentChampion = newChampion;
            RefreshPreview();
        }

        public void ClearChampion()
        {
            CurrentChampion = null;
            RefreshPreview();
        }

        public void Activate(int row, int column)
        {
            name = $"Cell_[{row}, {column}]";
            SetPosition(row, column);
            ClearChampion();
            SetActive(true);
        }

        public void SetPosition(int row, int column)
        {
            position.x = row;
            position.y = column;
        }

        public void Deactivate()
        {
            name = $"Cell_[unassigned]";
            SetPosition(int.MinValue, int.MinValue);
            ClearChampion();
            generator.Release(this);
        }

        public void SetHolder(Transform holder)
        {
            transform.SetParent(holder);
        }

        public void SetPositionAndRotation(Vector3 position, Quaternion rotation)
        {
            position += Vector3.up * 0.01f;
            transform.SetPositionAndRotation(position, rotation);
        }

        public void SetActive(bool value)
        {
            gameObject.SetActive(value);
        }

        #region

        public void RefreshPreview()
        {
            preview.color = CurrentChampion ? Color.cyan : Color.white;
        }

        public void OnDragChampionOnPreview(Champion champion)
        {
            if (champion == CurrentChampion)
            {
                preview.color = CurrentChampion ? Color.cyan : Color.green;
            }
            else
            {
                preview.color = CurrentChampion ? Color.red : Color.green;
            }
        }

        #endregion
    }
}