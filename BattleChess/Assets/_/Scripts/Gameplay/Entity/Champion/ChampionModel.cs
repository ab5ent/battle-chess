using UnityEngine;

namespace BattleChess.Entity
{
    public class ChampionModel : MonoBehaviour
    {
        [field: SerializeField]
        public ChampionId Id { get; private set; }

        public void SetMaterial(Material material)
        {
            GetComponent<SkinnedMeshRenderer>().material = material;
        }

        public void Activate()
        {
            gameObject.SetActive(true);
        }

        public void Deactivate()
        {
            gameObject.SetActive(false);
        }
    }
}