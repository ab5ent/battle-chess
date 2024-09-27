using BattleChess.Team;
using InfinityCode.UltimateEditorEnhancer.EditorMenus.PopupWindows;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BattleChess.Entity
{
    public class Champion : MonoBehaviour
    {
        private TeamController controller;

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
        }

        #region Utility

        public void SetTeamController(TeamController teamController)
        {
            controller = teamController;
        }

        public void SetParent(Transform holder)
        {
            transform.SetParent(holder);
        }

        public void SetLocalPositionAndRotation(Vector3 position, Quaternion rotation)
        {
            transform.SetLocalPositionAndRotation(position, rotation);
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

        private int i = 0;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                List<ChampionId> listChampionIds = Enum.GetValues(typeof(ChampionId)).Cast<ChampionId>().ToList();
                GetChampionComponent<ChampionIdentity>().SetChampionIdentity(listChampionIds[i]);
                i += 1;
            }

        }
    }
}