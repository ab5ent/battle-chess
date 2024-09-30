using System;
using UnityEngine;

namespace BattleChess.Common
{
    public abstract class DragObjectControllerState : ScriptableObject
    {
        protected DragObjectController controller;

        public virtual void Initialize(DragObjectController dragObjectController)
        {
            controller = dragObjectController;
        }

        public abstract void OnEnter();

        public abstract void OnUpdate();

        public abstract void OnExit();
    }
}