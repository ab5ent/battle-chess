using BattleChess.AreaStructure;
using BattleChess.Common.Hex;
using UnityEngine;

namespace BattleChess.Managers
{
    public class BoardManager : BaseManager
    {
        [SerializeField]
        private Hex hexPrefab;

        public void AssignGridMapToArea(Area area)
        {
            /*GridMap.transform.SetParent(area.transform);
            GridMap.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
            GridMap.gameObject.SetActive(true);*/
        }

        public void ReturnGridMap()
        {
            /*GridMap.transform.SetParent(transform);
            GridMap.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
            GridMap.gameObject.SetActive(false);*/
        }

        public Vector3 GetPositionOnGrid(Vector3Int location)
        {
            return Vector3.zero;
        }

        public override void Initialize(GameManager gameManager)
        {
            base.Initialize(gameManager);

            int totalRows = 4;

            for (int rIndex = 0; rIndex < totalRows; rIndex++)
            {
                int totalColumns = rIndex % 2 == 0 ? 4 : 5;
                string x = "";

                for (int cIndex = 0; cIndex < totalColumns; cIndex++)
                {
                    x += $"({rIndex}, {cIndex})";
                    Hex hex = Instantiate<Hex>(hexPrefab, transform);
                    hex.transform.position = new Vector3(rIndex, 0, cIndex);

                }
                Debug.Log(x);
            }
        }
    }
}