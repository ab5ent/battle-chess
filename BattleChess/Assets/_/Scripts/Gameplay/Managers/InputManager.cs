using UnityEngine;

namespace BattleChess.Managers
{
    public class InputManager : BaseManager
    {
        private Camera _camera;

        private RaycastHit mouseRaycastHit;

        private void Awake()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
        }

        private void Mouse()
        {
        }
    }
}