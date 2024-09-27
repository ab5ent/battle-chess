using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleChess
{
    [Serializable]
    public class BoardStructure
    {
        [field: SerializeField]
        public int StartRowIndex { get; private set; }

        [field: SerializeField]
        public int EndRowIndex { get; private set; }

        [field: SerializeField]
        public int StartColumnIndex { get; private set; }

        [field: SerializeField]
        public int EndColumnIndex { get; private set; }
    }
}