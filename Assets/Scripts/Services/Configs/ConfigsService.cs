using Models.Configs;
using UniRx;
using UnityEngine;
using Zenject;

namespace Services.Configs
{
    public class ConfigsService : IInitializable
    {
        public ReactiveProperty<ConfigModel> ConfigModel => new ReactiveProperty<ConfigModel>();

        public void Initialize()
        {
            Debug.Log($"Configs service initialization started");

            ConfigModel.Subscribe(configModel =>
            {
                Debug.Log($"Config model changed");
            });

            Debug.Log($"Configs service initialization finished");
        }
    }
}
