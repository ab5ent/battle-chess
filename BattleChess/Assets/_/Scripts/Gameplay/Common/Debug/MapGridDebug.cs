using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleChess.Gameplay.Common
{
    public class MapGridDebug : MonoBehaviour
    {
        [SerializeField]
        private Grid grid;

        [SerializeField]
        private bool enableDebug;

        private void OnDrawGizmos()
        {
            if (!enableDebug)
            {
                return;
            }

            for (int i = -5; i < 5; i++)
            {
                for (int j = -5; j < 5; j++)
                {
                    Gizmos.DrawWireCube(new Vector3Int(i, 0, j), Vector3.one);
                }
            }
        }
    }
}