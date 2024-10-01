using UnityEngine;

namespace BattleChess.Common
{
    public class DragObjectControllerPrepareState : DragObjectControllerState
    {
        [SerializeField]
        private RaycastHit mouseRaycastHit;

        [SerializeField]
        private LayerMask raycastLayerMask;

        [SerializeField]
        private DraggableObject taggedDragableObject;

        public override void Initialize(DragObjectController dragObjectController)
        {
            base.Initialize(dragObjectController);
            raycastLayerMask = controller.GetDraggableLayerMask();
        }

        public override void OnEnter()
        {

        }

        public override void OnExit()
        {
        }

        public override void OnUpdate()
        {
            ProcessTryToTagDraggableObject();
            ProcessObserveTaggedDraggableObject();
        }

        private void ProcessTryToTagDraggableObject()
        {
            if (taggedDragableObject != null)
            {
                return;
            }

            if (Input.GetMouseButton(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (!Physics.Raycast(ray, out mouseRaycastHit, 1000, raycastLayerMask))
                {
                    ResetTaggedDraggableObject();
                    return;
                }

                var draggableObj = mouseRaycastHit.collider.GetComponent<DraggableObject>();
                SetTaggedDraggableObject(draggableObj);
            }
        }

        private void ProcessObserveTaggedDraggableObject()
        {
            if (taggedDragableObject == null)
            {
                return;
            }

            if (!taggedDragableObject.IsBeingDragged)
            {
                SetTaggedDraggableObject(null);
            }
        }

        #region Utility

        private void SetTaggedDraggableObject(DraggableObject draggableObject)
        {
            if (taggedDragableObject == draggableObject)
            {
                return;
            }

            taggedDragableObject?.SetSelected(false);
            taggedDragableObject = draggableObject;
            taggedDragableObject?.SetSelected(true);
        }

        private void ResetTaggedDraggableObject()
        {
            taggedDragableObject = null;
        }

        #endregion
    }
}