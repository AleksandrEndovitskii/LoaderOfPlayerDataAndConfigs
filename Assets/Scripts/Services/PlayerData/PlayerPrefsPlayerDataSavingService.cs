using System.Reflection;
using Zenject;

namespace Services.PlayerData
{
    public class PlayerPrefsPlayerDataSavingService : IPlayerDataSavingService
    {
        [Inject]
        private PlayerDataService _playerDataService;

        public void Save()
        {
            var playerDataModel = _playerDataService.PlayerDataModel.Value;
            var propertyInfos = playerDataModel.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var propertyInfo in propertyInfos)
            {
                PropertyInfoExtensions.SaveToPlayerPrefs(propertyInfo, playerDataModel);
            }
        }
    }
}
