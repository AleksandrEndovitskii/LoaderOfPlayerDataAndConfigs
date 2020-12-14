using System.Linq;
using Services.Configs;
using TMPro;
using UniRx;
using UnityEngine;
using Zenject;

namespace Components.Configs
{
    public class ConfigsContainerComponent : MonoBehaviour
    {
#pragma warning disable 0649
        [SerializeField]
        private TextMeshProUGUI _prefab;
#pragma warning restore 0649

        private ConfigsService _configsService;

        [Inject]
        public void Construct(ConfigsService configsService)
        {
            _configsService = configsService;

            _configsService.ConfigModel.Subscribe(configModel =>
            {
                if (configModel == null)
                {
                    return;
                }

                this.gameObject.transform.DestroyAllChildren();

                var playerMaxLevelInstance = Instantiate(_prefab, this.gameObject.transform);
                playerMaxLevelInstance.text = configModel.PlayerMaxLevel.ToString();

                var questIdsInstance = Instantiate(_prefab, this.gameObject.transform);
                questIdsInstance.text = configModel.QuestIds.ToList().ToString<string>();

                var shopItemIdsInstance = Instantiate(_prefab, this.gameObject.transform);
                shopItemIdsInstance.text = configModel.ShopItemIds.ToList().ToString<string>();
            });
        }
    }
}
