using BattleChess.AreaStructure;
using BattleChess.LevelStructure;
using UnityEngine;

namespace BattleChess.Managers
{
    public class BoardManager : BaseManager
    {
        [field: SerializeField]
        public Grid GridMap { get; private set; }

        public void AssignGridMapToArea(Area area)
        {
            GridMap.transform.SetParent(area.transform);
            GridMap.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
            GridMap.gameObject.SetActive(true);
        }

        public void ReturnGridMap()
        {
            GridMap.transform.SetParent(transform);
            GridMap.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
            GridMap.gameObject.SetActive(false);
        }

        [ContextMenu("Test")]
        public void Test()
        {
            AssignGridMapToArea(selectArea);
        }

        public Area selectArea;

        public Vector3 GetPositionOnGrid(Vector3Int location)
        {
            return GridMap.CellToWorld(location);
        }
    }
}