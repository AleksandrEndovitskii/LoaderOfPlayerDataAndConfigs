using JsonObjects;
using Models.Configs;
using Newtonsoft.Json;
using UnityEngine;
using Zenject;

namespace Services.Configs
{
    public class ResourcesConfigsLoadingService : IConfigsLoadingService
    {
        [Inject]
        private ConfigsService _configsService;

        public void Load()
        {
            Debug.Log($"Configs loading started");

            var configsTextAsset = Resources.Load<TextAsset>("Configs");
            var jsonString = configsTextAsset.text;
            var configsJsonObject = JsonConvert.DeserializeObject<ConfigsJsonObject>(jsonString);
            var configModel = new ConfigModel(configsJsonObject);

            Debug.Log($"Configs loading finished");

            _configsService.ConfigModel.Value = configModel;
        }
    }
}
