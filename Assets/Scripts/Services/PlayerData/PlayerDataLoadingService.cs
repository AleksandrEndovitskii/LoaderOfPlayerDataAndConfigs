using Models.PlayerData;
using UnityEngine;
using Zenject;

namespace Services.PlayerData
{
    public class PlayerDataLoadingService : IPlayerDataLoadingService
    {
        [Inject]
        private PlayerDataService _playerDataService;

        public void Load()
        {
            var defaultPlayerDataModel = new PlayerDataModel(1, 1, 1);

            var id = PlayerPrefs.GetInt("Id", defaultPlayerDataModel.Id.Value);
            var currentLevel = PlayerPrefs.GetInt("CurrentLevel", defaultPlayerDataModel.CurrentLevel.Value);
            var moneyAmount = PlayerPrefs.GetInt("MoneyAmount", defaultPlayerDataModel.MoneyAmount.Value);
            var playerDataModel = new PlayerDataModel(id, currentLevel, moneyAmount);

            _playerDataService.PlayerDataModel.Value = playerDataModel;
        }
    }
}
