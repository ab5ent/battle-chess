using BattleChess.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleChess.Entity
{
    public class ChampionIdentity : MonoBehaviour
    {
        [field: SerializeField]
        public ChampionId Id { get; private set; }

        [SerializeField]
        private Material baseMaterial;

        private ChampionModel[] models;

        private ChampionModel currentModel;

        private Material clonedMaterial;

        private void Awake()
        {
            clonedMaterial = new Material(baseMaterial);
            models = GetComponentsInChildren<ChampionModel>(includeInactive: true);
        }

        public void SetChampionId(ChampionId id)
        {
            Id = id;
            SwitchModel(GetChampionModel(Id));
        }

        private void SwitchModel(ChampionModel championModel)
        {
            currentModel?.Deactivate();
            currentModel = championModel;
            championModel.SetMaterial(clonedMaterial);
            clonedMaterial.SetTexture("_MainTex", GameManager.Instance.SharedDataManager.GetChampionTexture(championModel.Id));
            championModel.Activate();
        }

        private ChampionModel GetChampionModel(ChampionId id)
        {
            for (int i = 0; i < models.Length; i++)
            {
                if (models[i].Id == id)
                {
                    return models[i];
                }
            }

            return null;
        }

        private int index;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                SetChampionId(models[index].Id);
                index++;
            }
        }
    }
}