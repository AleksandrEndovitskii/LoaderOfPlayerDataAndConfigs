using System.Collections.Generic;
using System.Reflection;
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
            var configModel = new ConfigModel();
            var propertyInfos = configModel.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var propertyInfo in propertyInfos)
            {
                var jsonToken = jsonObject[propertyInfo.Name];
                System.Object value = null;
                if (jsonToken is JArray)
                {
                    var jArray = jsonToken.Value<JArray>();
                    value = jArray.ToObject<List<string>>();
                }
                else
                {
                    value = jsonToken.ToObject<string>();
                }
                PropertyInfoExtensions.SetValue(propertyInfo, configModel, value);
            }

            Debug.Log($"Configs loading finished");

            _configsService.ConfigModel.Value = configModel;
        }
    }
}
