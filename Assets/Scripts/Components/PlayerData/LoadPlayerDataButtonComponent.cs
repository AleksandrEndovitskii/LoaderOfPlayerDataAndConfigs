using Components.Utils;
using Services.PlayerData;
using Zenject;

namespace Components.PlayerData
{
    public class LoadPlayerDataButtonComponent : ButtonComponent
    {
        private IPlayerDataLoadingService _playerDataLoadingService;

        [Inject]
        public void Construct(IPlayerDataLoadingService playerDataLoadingService)
        {
            _playerDataLoadingService = playerDataLoadingService;
        }

        protected override void ButtonOnClick()
        {
            _playerDataLoadingService.Load();
        }
    }
}
