using BattleChess.LevelStructure;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace BattleChess.Entity
{
    public class Champion : MonoBehaviour
    {
        private Dictionary<Type, ChampionComponent> componentDictionary;

        private void Awake()
        {
            Initialize();
        }

        public virtual void Initialize()
        {
            componentDictionary = new Dictionary<Type, ChampionComponent>();

            ChampionComponent[] components = GetComponentsInChildren<ChampionComponent>(includeInactive: true);

            int i;

            for (i = 0; i < components.Length; i++)
            {
                components[i].SetChampion(this);
                componentDictionary.Add(components[i].GetType(), components[i]);
            }

            for (i = 0; i < components.Length; i++)
            {
                components[i].Initialize();
            }

            GetComponentInChildren<ChampionDragCollider>().SetChampion(this);
        }

        #region Utility

        public void SetParent(Transform holder)
        {
            transform.SetParent(holder);
        }

        public void SetLocalPositionAndRotation(Vector3 position, Quaternion rotation)
        {
            transform.SetLocalPositionAndRotation(position, rotation);
        }

        public void SetPositionAndRotation(Vector3 position, Quaternion rotation)
        {
            transform.SetPositionAndRotation(position, rotation);
        }

        public T GetChampionComponent<T>() where T : ChampionComponent
        {
            if (componentDictionary.TryGetValue(typeof(T), out ChampionComponent component))
            {
                return component as T;
            }
            return null;
        }

        #endregion

        #region Methods

        public void SetIdentity(ChampionId id)
        {
            GetChampionComponent<ChampionIdentity>().SetChampionIdentity(id);
        }

        public void SetBoard(Board board)
        {
            GetChampionComponent<ChampionBoardLocation>().SetBoard(board);
        }

        public void SetTeam(TeamId teamId)
        {
            GetChampionComponent<ChampionTeam>().AssignToTeam(teamId);
        }

        #endregion
    }
}