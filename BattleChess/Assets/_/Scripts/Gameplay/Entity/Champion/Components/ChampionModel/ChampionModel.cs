using BattleChess.Managers;
using UnityEngine;

namespace BattleChess.Entity
{
    public class ChampionModel : ChampionComponent
    {
        private const string MainTextureKey = "_MainTex";

        private const string ColorKey = "_Color";

        private Material clonedMaterial;

        private SkinnedMeshRenderer currentSkinnedMeshRenderer;

        public void Activate()
        {
            currentSkinnedMeshRenderer?.gameObject.SetActive(true);
        }

        public void Deactivate()
        {
            currentSkinnedMeshRenderer?.gameObject.SetActive(false);
        }

        public override void Initialize()
        {
            base.Initialize();
            clonedMaterial = new Material(GetChampionComponent<ChampionSkins>().OriginalMaterial);
            clonedMaterial.name = "ClonedChampionMaterial";
        }

        public void SetModel(ChampionId id)
        {
            Deactivate();
            ChampionSkinInfo championSkinInfo = GetChampionComponent<ChampionSkins>().GetChampionSkinInfo(id);
            currentSkinnedMeshRenderer = championSkinInfo.Skin;
            currentSkinnedMeshRenderer.material = clonedMaterial;
            clonedMaterial.SetTexture(MainTextureKey, GameManager.GetManager<SharedDataManager>().GetChampionTexture(id));
            Activate();
        }
    }
}