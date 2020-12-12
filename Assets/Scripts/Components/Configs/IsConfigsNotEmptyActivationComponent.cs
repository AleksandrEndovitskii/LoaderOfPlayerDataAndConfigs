using Services.Configs;
using UniRx;
using UnityEngine;
using Zenject;

namespace Components.Configs
{
    public class IsConfigsNotEmptyActivationComponent : MonoBehaviour
    {
        private ConfigsService _configsService;

        [Inject]
        public void Construct(ConfigsService configsService)
        {
            _configsService = configsService;

            _configsService.ConfigModel.Subscribe(configModel =>
            {
                this.gameObject.SetActive(configModel != null);
            });
        }
    }
}
