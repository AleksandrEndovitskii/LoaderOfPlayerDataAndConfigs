using Models.Configs;
using UniRx;
using UnityEngine;
using Zenject;

namespace Services.Configs
{
    public class ConfigsService : IInitializable
    {
        public ReactiveProperty<ConfigModel> ConfigModel => new ReactiveProperty<ConfigModel>();

        [Inject]
        private ConfigsLoadingService _configsLoadingService;

        public void Initialize()
        {
            Debug.Log($"Configs service initialization started");

            ConfigModel.Subscribe(configModel =>
            {
                Debug.Log($"Config model changed");
            });

            ConfigModel.Value = _configsLoadingService.Load();

            Debug.Log($"Configs service initialization finished");
        }
    }
}
