using System.Reflection;
using Models.PlayerData;
using UnityEngine;

namespace Services.PlayerData
{
    public class PlayerPrefsPlayerDataSavingService : IPlayerDataSavingService
    {
        public void Save(PropertyInfo propertyInfo, PlayerDataModel playerDataModel)
        {
            Debug.Log($"Saving of key({propertyInfo.Name}) with value({playerDataModel}) started");

            PropertyInfoExtensions.SaveToPlayerPrefs(propertyInfo, playerDataModel);

            Debug.Log($"Saving of key({propertyInfo.Name}) with value({playerDataModel}) finished");
        }
    }
}
