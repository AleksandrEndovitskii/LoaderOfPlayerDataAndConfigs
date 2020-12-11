using System.Collections.Generic;
using Models.Configs;
using Zenject;

namespace Services.Configs
{
    public class ConfigsLoadingService : IConfigsLoadingService
    {
        [Inject]
        private ConfigsService _configsService;

        public void Load()
        {
            var configModel = new ConfigModel(0, new List<string>(), new List<string>());

            _configsService.ConfigModel.Value = configModel;
        }
    }
}
