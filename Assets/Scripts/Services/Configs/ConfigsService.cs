using Models.Configs;
using UniRx;
using UnityEngine;
using Zenject;

namespace Services.Configs
{
    public class ConfigsService
    {
        public ReactiveProperty<ConfigModel> ConfigModel { get; private set; }

        [Inject]
        public void Construct()
        {
            Debug.Log($"Configs service initialization started");

            ConfigModel = new ReactiveProperty<ConfigModel>();

            ConfigModel.Subscribe(configModel =>
            {
                Debug.Log($"Config model changed");
            });

            Debug.Log($"Configs service initialization finished");
        }
    }
}
