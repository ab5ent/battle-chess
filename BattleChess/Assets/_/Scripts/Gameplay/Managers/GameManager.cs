using ab5entSDK.Common;
using BattleChess.Entity;
using BattleChess.Mathematics;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleChess.Managers
{
    public class GameManager : SingletonMonoBehaviour<GameManager>
    {
        private Dictionary<Type, BaseManager> managersDictionary;

        protected override void Awake()
        {
            base.Awake();
            Initialize();
        }

        private void Initialize()
        {
            managersDictionary = new Dictionary<Type, BaseManager>();

            BaseManager[] baseManagers = GetComponentsInChildren<BaseManager>();

            for (int i = 0; i < baseManagers.Length; i++)
            {
                managersDictionary.Add(baseManagers[i].GetType(), baseManagers[i]);
            }

            for (int i = 0; i < managersDictionary.Count; i++)
            {
                baseManagers[i].Initialize(this);
            }
        }

        private void Update()
        {
        }

        private void StartGame()
        {
            GetManager<LevelManager>().LoadLevel(LevelType.Campaign, 0);
        }

        public static T GetManager<T>() where T : BaseManager
        {
            if (Instance.managersDictionary.TryGetValue(typeof(T), out BaseManager component))
            {
                return component as T;
            }
            return null;
        }

        #region Pause/Resume

        public bool IsPaused() => Time.timeScale <= 0;

        public void Pause(float duration = 0)
        {
            StartCoroutine(ChangeTimeScale(1, 0, duration));
        }

        public void Resume(float duration = 0)
        {
            StartCoroutine(ChangeTimeScale(0, 1, duration));
        }

        protected IEnumerator ChangeTimeScale(float startValue, float endValue, float duration)
        {
            float elapsedTime = 0;

            while (elapsedTime < duration)
            {
                float t = startValue > endValue ? Easing.EaseIn(elapsedTime / duration) : Easing.EaseOut(elapsedTime / duration);
                Time.timeScale = Mathf.Lerp(startValue, endValue, t);
                yield return null;
                elapsedTime += Time.unscaledDeltaTime;
            }

            Time.timeScale = endValue;
        }

        #endregion
    }
}