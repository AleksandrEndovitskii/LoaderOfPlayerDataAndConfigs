using System.Reflection;
using Models.PlayerData;
using Zenject;

namespace Services.PlayerData
{
    public class PlayerPrefsPlayerDataLoadingService : IPlayerDataLoadingService
    {
        [Inject]
        private PlayerDataService _playerDataService;

        public void Load()
        {
            var playerDataModel = new PlayerDataModel();
            var propertyInfos = playerDataModel.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var propertyInfo in propertyInfos)
            {
                PropertyInfoExtensions.LoadFromPlayerPrefs(propertyInfo, playerDataModel);
            }

            _playerDataService.PlayerDataModel.Value = playerDataModel;
        }
    }
}
