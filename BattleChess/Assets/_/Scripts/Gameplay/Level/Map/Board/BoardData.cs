using BattleChess.LevelStructure;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace BattleChess
{
    [CreateAssetMenu(fileName = "BoardData", menuName = "Data/BoardData")]
    public class BoardData : ScriptableObject
    {
        [SerializeField]
        private BoardInformation[] listOfBoardInformation;

        public BoardInformation GetBoardInformation(BoardForm form)
        {
            for (int i = 0; i < listOfBoardInformation.Length; i++)
            {
                if (listOfBoardInformation[i].Form == form)
                {
                    return listOfBoardInformation[i];
                }
            }

            return null;
        }
    }
}