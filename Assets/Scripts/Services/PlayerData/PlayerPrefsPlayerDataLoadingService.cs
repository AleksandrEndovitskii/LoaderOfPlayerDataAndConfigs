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

            var playerDataModel = new PlayerDataModel(_playerDataSavingService);
            var propertyInfos = playerDataModel.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var propertyInfo in propertyInfos)
            {
                PropertyInfoExtensions.LoadFromPlayerPrefs(propertyInfo, playerDataModel);
            }

            Debug.Log($"Loading of PlayerData from PlayerPrefs finished");

            _playerDataService.PlayerDataModel.Value = playerDataModel;
        }
    }
}
