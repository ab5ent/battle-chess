using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleChess.Common.Hex
{
    public struct Face
    {
        public List<Vector3> Vertices { get; private set; }

        public List<int> Triangles { get; private set; }

        public List<Vector2> UVs { get; private set; }

        public Face(List<Vector3> vertices, List<int> triangles, List<Vector2> uVs)
        {
            Vertices = vertices;
            Triangles = triangles;
            UVs = uVs;
        }
    }
}