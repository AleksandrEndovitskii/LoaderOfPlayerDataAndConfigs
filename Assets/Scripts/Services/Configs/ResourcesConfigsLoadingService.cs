using Models.Configs;
using Newtonsoft.Json.Linq;
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
            var jsonObject = JObject.Parse(jsonString);
            var configModel = jsonObject.ParseTo<ConfigModel>();

            Debug.Log($"Configs loading finished");

            _configsService.ConfigModel.Value = configModel;
        }
    }
}
