using Models.PlayerData;
using Zenject;

namespace Services.PlayerData
{
    public class PlayerDataLoadingService : IPlayerDataLoadingService
    {
        [Inject]
        private PlayerDataService _playerDataService;

        public void Load()
        {
            var playerDataModel = new PlayerDataModel(0, 0, 0);

            _playerDataService.PlayerDataModel.Value = playerDataModel;
        }
    }
}
