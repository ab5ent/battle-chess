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
        public TeamId Id { get; protected set; }

        public void Initialize(Level level)
        {
            CurrentLevel = level;
        }

        public virtual void ProcessPrepareState()
        {

        }

        public virtual void DeInitialize()
        {
        }

        public void AddChampion(Champion champ)
        {
        }
    }
}