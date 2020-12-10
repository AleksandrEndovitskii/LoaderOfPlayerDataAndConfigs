using Components.Utils;
using Services.Configs;
using Zenject;

namespace Components.Configs
{
    public class LoadConfigsButtonComponent : ButtonComponent
    {
        private IConfigsLoadingService _configsLoadingService;

        [Inject]
        public void Construct(IConfigsLoadingService configsLoadingService)
        {
            _configsLoadingService = configsLoadingService;
        }

        protected override void ButtonOnClick()
        {
            _configsLoadingService.Load();
        }
    }
}
