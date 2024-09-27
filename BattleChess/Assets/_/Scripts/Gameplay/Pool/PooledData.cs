using UnityEngine;

namespace BattleChess.ObjectPooling
{
    [CreateAssetMenu(fileName = "ObjectPooling", menuName = "Data/PooledData")]
    public class PooledData : ScriptableObject
    {
        [SerializeField]
        private PooledObjectInfo[] data;

        public PooledObjectInfo GetObjectInfo(PooledObjectId id)
        {
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].Prefab.Id == id)
                {
                    return data[i];
                }
            }

            return null;
        }
    }
}