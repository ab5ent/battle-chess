using UnityEngine;

namespace BattleChess.Common
{
    public class DraggableObject : MonoBehaviour
    {
        [field: SerializeField]
        public DraggableObjectId Id { get; private set; }

        private bool isSelected;

        public virtual void SetSelected(bool value)
        {
            isSelected = value;
        }
    }
}