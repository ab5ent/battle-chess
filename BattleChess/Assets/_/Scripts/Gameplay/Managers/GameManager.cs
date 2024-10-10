using ab5entSDK.Common;
using BattleChess.Mathematics;
using System.Collections;
using UnityEngine;

namespace BattleChess.Managers
{
    public class GameManager : SingletonMonoBehaviour<GameManager>
    {
        public CameraManager CameraManager { get; private set; }

        public InputManager InputManager { get; private set; }

        public LevelManager LevelManager { get; private set; }

        public PoolManager PoolManager { get; private set; }

        public SharedDataManager SharedDataManager { get; private set; }

        public TeamManager TeamManager { get; private set; }

        protected override void Awake()
        {
            base.Awake();
            GetManagers();
            Initialize();
        }

        private void GetManagers()
        {
            CameraManager = GetComponentInChildren<CameraManager>();
            LevelManager = GetComponentInChildren<LevelManager>();
            InputManager = GetComponentInChildren<InputManager>();
            PoolManager = GetComponentInChildren<PoolManager>();
            SharedDataManager = GetComponentInChildren<SharedDataManager>();
            TeamManager = GetComponentInChildren<TeamManager>();
        }

        private void Initialize()
        {
            CameraManager.Initialize(this);
            InputManager.Initialize(this);
            PoolManager.Initialize(this);
            SharedDataManager.Initialize(this);

            TeamManager.Initialize(this);
            LevelManager.Initialize(this);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartGame();
            }
        }

        private void StartGame()
        {
            LevelManager.LoadLevel(LevelType.Campaign, 0);
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