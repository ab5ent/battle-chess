using BattleChess.Entity;
using BattleChess.LevelStructure;
using System;
using UnityEngine;

namespace BattleChess.Team
{
    public class TeamController : MonoBehaviour
    {
        public Level CurrentLevel { get; protected set; }

        [field: SerializeField]
        public TeamId ID { get; protected set; }

        protected Board board;

        public void Initialize(Level level)
        {
            CurrentLevel = level;
            board = GetComponent<Board>();
            board.Initialize(this);
        }

        public virtual void ProcessPrepareState()
        {

        }

        public virtual void DeInitialize()
        {
            board.DeInitialize();
        }

        public void AddChampion(Champion champ)
        {
            board.AddChampion(champ);
        }
    }
}