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

            for (int i = -2; i <= 2; i++)
            {
                for (int j = -2; j <= 2; j++)
                {
                    Gizmos.DrawWireCube(new Vector3Int(i, 0, j), Vector3.one);
                }
            }
        }
    }
}