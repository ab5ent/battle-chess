using UnityEngine;

namespace BattleChess.Common
{
    public class DraggableObject : MonoBehaviour
    {
        [field: SerializeField]
        public DraggableObjectId Id { get; private set; }

        protected Vector3 mousePosition;

        protected Vector3 lastPosition;

        protected bool isSelected;

        public bool IsBeingDragged { get; protected set; }

        public virtual void SetSelected(bool value)
        {
            isSelected = value;
        }

        private void OnMouseDown()
        {
            IsBeingDragged = true;
        }

        private void OnMouseDrag()
        {
            if (isSelected)
            {
                MouseDragOnObject();
            }
        }

        private void OnMouseUp()
        {
            IsBeingDragged = false;
            MouseUpOnObject();
        }

        #region

        protected virtual void MouseDownOnObject()
        {

        }

        protected virtual void MouseDragOnObject()
        {

        }

        protected virtual void MouseUpOnObject()
        {

        }

        #endregion
    }
}