using BattleChess.LevelStructure;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace BattleChess.Entity
{
    public class ChampionBoardLocation : ChampionComponent
    {
        private Board board;

        public Vector3Int v;

        public void SetBoard(Board newBoard)
        {
            board = newBoard;
        }

        public void SetToBoardCellCenter(Vector3 position)
        {
            v = board.Get(position);
            champion.SetLocalPositionAndRotation(board.ConvertToGridPosition(position) + Vector3.up * 0.5f, Quaternion.identity);
        }

        public void PlaceToBoardCellCenter(Vector3 position)
        {
            champion.SetLocalPositionAndRotation(board.ConvertToGridPosition(position), Quaternion.identity);
        }
    }
}