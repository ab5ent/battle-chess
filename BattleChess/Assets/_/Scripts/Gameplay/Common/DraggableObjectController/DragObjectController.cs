using BattleChess.LevelStructure;
using BattleChess.Managers;
using UnityEngine;

namespace BattleChess.Common
{
    public class DragObjectController : MonoBehaviour
    {
        protected LayerMask draggableLayerMask;

        [SerializeField]
        private DraggableObjectInfo[] draggableObjectInfo;

        private LevelManager manager;

        private RaycastHit mouseRaycastHit;

        private Vector3 hittedPoint;

        private Vector3Int selectedGridPosition;

        private DragObjectControllerState currentState;

        [SerializeField]
        private DragObjectControllerState[] states;

        public void SetManager(LevelManager levelManager)
        {
            manager = levelManager;
            SetLayerMask();
            SetFSM();
        }

        private void SetFSM()
        {
            states = new DragObjectControllerState[3]
            {
                ScriptableObject.CreateInstance<DragObjectControllerEmptyState>(),
                ScriptableObject.CreateInstance<DragObjectControllerInitializeState>(),
                ScriptableObject.CreateInstance<DragObjectControllerPrepareState>()
            };

            for (int i = 0; i < states.Length; i++)
            {
                states[i].Initialize(this);
            }

            SwitchCurrentState(GetDragObjectControllerState<DragObjectControllerEmptyState>());
        }

        private void SetLayerMask()
        {
            for (int i = 0; i < draggableObjectInfo.Length; i++)
            {
                draggableLayerMask |= draggableObjectInfo[i].DraggableLayerMask;
            }
        }

        public LayerMask GetDraggableLayerMask()
        {
            return draggableLayerMask;
        }

        private void Update()
        {
            currentState?.OnUpdate();
        }

        #region Prepare

        #endregion

        #region HittedPosition

        private void IntegrateHitPosition(Vector3 position)
        {
            hittedPoint = position;

            if (IsInvalidVector3(position))
            {
                selectedGridPosition = Vector3Int.zero;
                return;
            }

            Vector3Int rawGridPosition = IntegrateToGridPosition(hittedPoint);

            //BoardStructure structure = manager.CurrentLevel.Variables.InformationOfBoard.UserBoardStructure;

            //bool insideColumn = rawGridPosition.x >= structure.StartColumnIndex && rawGridPosition.x <= structure.EndColumnIndex;
            //bool insideRow = rawGridPosition.z >= structure.StartRowIndex && rawGridPosition.z <= structure.EndRowIndex;

            //draw = insideColumn && insideRow;
            //selectedGridPosition = draw ? rawGridPosition : Vector3Int.zero;
        }

        private Vector3Int IntegrateToGridPosition(Vector3 position)
        {
            return Vector3Int.zero;
            //return manager.CurrentLevel.Ref.UnityGrid.WorldToCell(position);
        }

        #endregion

        private bool IsInvalidVector3(Vector3 vector3)
        {
            return vector3.x <= float.NegativeInfinity || vector3.y <= float.NegativeInfinity || vector3.z <= float.NegativeInfinity;
        }

        private T GetDragObjectControllerState<T>() where T : DragObjectControllerState
        {
            for (int i = 0; i < states.Length; i++)
            {
                if (states[i] is T state)
                {
                    return state;
                }
            }

            return null;
        }

        private void SwitchCurrentState(DragObjectControllerState state)
        {
            currentState?.OnExit();
            currentState = state;
            currentState.OnEnter();
        }

        public void OnChangeLevelState(LevelState state)
        {
            switch (state)
            {
                case LevelState.None:
                    SwitchCurrentState(GetDragObjectControllerState<DragObjectControllerEmptyState>());
                    break;
                case LevelState.Prepare:
                    SwitchCurrentState(GetDragObjectControllerState<DragObjectControllerPrepareState>());
                    break;
                case LevelState.OnInitialize:
                    SwitchCurrentState(GetDragObjectControllerState<DragObjectControllerInitializeState>());
                    break;
                case LevelState.OnBattle:
                    break;
                case LevelState.OnDeInitialize:
                    break;
            }
        }
    }
}