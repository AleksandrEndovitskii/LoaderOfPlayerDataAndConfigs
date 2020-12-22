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
            Debug.Log($"{GetType().Name} initialization started");

            ConfigModel = new ReactiveProperty<ConfigModel>();

            ConfigModel.Subscribe(configModel =>
            {
                Debug.Log($"{nameof(configModel)} changed");
            });

            Debug.Log($"{GetType().Name} initialization finished");
        }
    }
}
