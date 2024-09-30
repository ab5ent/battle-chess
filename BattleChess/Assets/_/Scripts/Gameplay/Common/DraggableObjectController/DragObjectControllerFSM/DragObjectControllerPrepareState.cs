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
        private DraggableObject currentDragableObject;

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
            if (Input.GetMouseButton(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (!Physics.Raycast(ray, out mouseRaycastHit, 1000, raycastLayerMask))
                {
                    ResetCurrentDraggableObject();
                    return;
                }

                var draggableObj = mouseRaycastHit.collider.GetComponent<DraggableObject>();
                SetCurrentDraggableObject(draggableObj);
            }
        }

        private void SetCurrentDraggableObject(DraggableObject draggableObject)
        {
            if (currentDragableObject == draggableObject)
            {
                return;
            }

            currentDragableObject?.SetSelected(false);
            currentDragableObject = draggableObject;
            currentDragableObject.SetSelected(true);
        }

        private void ResetCurrentDraggableObject()
        {
            currentDragableObject = null;
        }
    }
}