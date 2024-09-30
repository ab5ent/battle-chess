using BattleChess.Common;
using BattleChess.Managers;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace BattleChess.LevelStructure
{
    public class DragObjectController : MonoBehaviour
    {
        public LayerMask drayLayerMask;

        [SerializeField]
        private DraggableObjectInfo[] draggableObjectInfo;

        private LevelManager manager;

        private RaycastHit mouseRaycastHit;

        private Vector3 hittedPoint;

        private Vector3Int selectedGridPosition;

        private bool draw;

        public void SetManager(LevelManager levelManager)
        {
            manager = levelManager;
            SetLayerMask();
        }

        private void SetLayerMask()
        {
            for (int i = 0; i < draggableObjectInfo.Length; i++)
            {
                drayLayerMask &= draggableObjectInfo[i].DraggableLayerMask;
            }
        }

        private void Update()
        {
            if (!manager.CurrentLevel)
            {
                return;
            }

            switch (manager.CurrentLevel.Variables.State)
            {
                case LevelState.None:
                    break;
                case LevelState.Prepare:
                    ProcessPrepareState();
                    break;
                case LevelState.OnInitialize:
                    break;
                case LevelState.OnBattle:
                    break;
                case LevelState.OnDeInitialize:
                    break;
            }


        }

        #region Prepare

        private void ProcessPrepareState()
        {
            if (Input.GetMouseButton(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (!Physics.Raycast(ray, out mouseRaycastHit, 10, drayLayerMask))
                {
                    return;
                }

                if (mouseRaycastHit.collider.CompareTag("Champion"))
                {
                    Debug.Log("Champ");
                }

                //IntergateHittedPosition(mouseRaycastHit.point);
                return;
            }

            //IntergateHittedPosition(Vector3.negativeInfinity);

        }

        #endregion

        #region HittedPosition

        private void IntergateHittedPosition(Vector3 position)
        {
            hittedPoint = position;

            if (IsInvalidVector3(position))
            {
                draw = false;
                selectedGridPosition = Vector3Int.zero;
                return;
            }

            Vector3Int rawGridPosition = IntegrateToGridPosition(hittedPoint);

            BoardStructure structure = manager.CurrentLevel.Variables.InformationOfBoard.UserBoardStructure;

            bool insideColumn = rawGridPosition.x >= structure.StartColumnIndex && rawGridPosition.x <= structure.EndColumnIndex;
            bool insideRow = rawGridPosition.z >= structure.StartRowIndex && rawGridPosition.z <= structure.EndRowIndex;

            //draw = insideColumn && insideRow;
            //selectedGridPosition = draw ? rawGridPosition : Vector3Int.zero;
        }

        private Vector3Int IntegrateToGridPosition(Vector3 position)
        {
            return manager.CurrentLevel.Ref.UnityGrid.WorldToCell(position);
        }

        #endregion

        private bool IsInvalidVector3(Vector3 vector3)
        {
            return vector3.x <= float.NegativeInfinity || vector3.y <= float.NegativeInfinity || vector3.z <= float.NegativeInfinity;
        }
    }
}