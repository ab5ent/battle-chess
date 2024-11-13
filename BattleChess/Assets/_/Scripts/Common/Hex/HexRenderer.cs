using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleChess.Common.Hex
{
    [RequireComponent(typeof(MeshRenderer))]
    [RequireComponent(typeof(MeshFilter))]
    public class HexRenderer : MonoBehaviour
    {
        [SerializeField]
        protected Material originalMaterial;

        protected MeshRenderer meshRenderer;

        protected MeshFilter meshFilter;

        protected Mesh mesh;

        protected Material instanceMaterial;

        private List<Face> faces = new List<Face>();

        [SerializeField]
        private float innerSize;

        [SerializeField]
        private float outerSize;

        [SerializeField]
        private float height;

        [SerializeField]
        private bool isFlatTopped;

        [SerializeField]
        private bool is3DObject;

        private void Awake()
        {
            meshRenderer = GetComponent<MeshRenderer>();
            meshFilter = GetComponent<MeshFilter>();

            mesh = new Mesh();
            mesh.name = "Hex";

            meshFilter.mesh = mesh;
            instanceMaterial = new Material(originalMaterial);
            meshRenderer.material = instanceMaterial;
        }

        public void OnValidate()
        {
            if (Application.isPlaying)
            {
                DrawMesh();
            }
        }

        public void OnEnable()
        {
            DrawMesh();
        }

        private void DrawMesh()
        {
            if (mesh)
            {
                DrawFaces();
                CombineFaces();
            }
        }

        private void DrawFaces()
        {
            faces = new List<Face>();

            // Top face
            for (int point = 0; point < 6; point++)
            {
                faces.Add(CreateFace(innerSize, outerSize, height / 2, height / 2, point));
            }

            if (is3DObject)
            {
                // Bottom face
                for (int point = 0; point < 6; point++)
                {
                    faces.Add(CreateFace(innerSize, outerSize, -height / 2, -height / 2, point, true));
                }

                // Outer face
                for (int point = 0; point < 6; point++)
                {
                    faces.Add(CreateFace(outerSize, outerSize, height / 2, -height / 2, point, true));
                }

                // Inner face
                for (int point = 0; point < 6; point++)
                {
                    faces.Add(CreateFace(innerSize, innerSize, height / 2, -height / 2, point, false));
                }
            }
        }

        private void CombineFaces()
        {
            List<Vector3> vertices = new List<Vector3>();
            List<int> triangles = new List<int>();
            List<Vector2> uvs = new List<Vector2>();

            for (int i = 0; i < faces.Count; i++)
            {
                vertices.AddRange(faces[i].Vertices);
                uvs.AddRange(faces[i].UVs);

                // Offsets the triangles
                int offset = (4 * i);
                foreach (int triangle in faces[i].Triangles)
                {
                    triangles.Add(triangle + offset);
                }
            }

            mesh.vertices = vertices.ToArray();
            mesh.triangles = triangles.ToArray();
            mesh.uv = uvs.ToArray();
            mesh.RecalculateNormals();
        }

        private Face CreateFace(float innerRad, float outerRad, float heightA, float heightB, int point, bool isReverse = false)
        {
            Vector3 pointA = GetPoint(innerRad, heightB, point);
            Vector3 pointB = GetPoint(innerRad, heightB, (point < 5) ? point + 1 : 0);
            Vector3 pointC = GetPoint(outerRad, heightA, (point < 5) ? point + 1 : 0);
            Vector3 pointD = GetPoint(outerRad, heightA, point);

            List<Vector3> vertices = new List<Vector3>() { pointA, pointB, pointC, pointD };
            List<int> triangles = new List<int>() { 0, 1, 2, 2, 3, 0 };
            List<Vector2> uvs = new List<Vector2>() { new Vector2(0, 0), new Vector2(1, 0), new Vector2(1, 1), new Vector2(0, 1) };

            if (isReverse)
            {
                vertices.Reverse();
            }

            return new Face(vertices, triangles, uvs);
        }

        private Vector3 GetPoint(float size, float height, int index)
        {
            float angle = Mathf.PI / 180f * (isFlatTopped ? 60 * index : 60 * index - 30);
            return new Vector3(size * Mathf.Cos(angle), height, size * Mathf.Sin(angle));
        }
    }
}
