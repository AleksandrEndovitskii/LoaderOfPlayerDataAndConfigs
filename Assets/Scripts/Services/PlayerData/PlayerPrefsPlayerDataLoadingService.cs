using System.Reflection;
using Models.PlayerData;
using UnityEngine;
using Zenject;

namespace Services.PlayerData
{
    public class PlayerPrefsPlayerDataLoadingService : IPlayerDataLoadingService
    {
        [Inject]
        private PlayerDataService _playerDataService;
        [Inject]
        private IPlayerDataSavingService _playerDataSavingService;

        public void Load()
        {
            Debug.Log($"Loading of PlayerData from PlayerPrefs started");

            // While you are reading data from the source - do not save data to the source
            _playerDataSavingService.IsSavingBlocked = true;
            var playerDataModel = new PlayerDataModel(_playerDataSavingService);
            var propertyInfos = playerDataModel.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var propertyInfo in propertyInfos)
            {
                PropertyInfoExtensions.LoadFromPlayerPrefs(propertyInfo, playerDataModel);
            }
            _playerDataSavingService.IsSavingBlocked = false;

            Debug.Log($"Loading of PlayerData from PlayerPrefs finished");

            _playerDataService.PlayerDataModel.Value = playerDataModel;
        }
    }
}
