using System.Reflection;
using Models.PlayerData;
using UnityEngine;

namespace Services.PlayerData
{
    public class PlayerPrefsPlayerDataSavingService : IPlayerDataSavingService
    {
        public bool IsSavingBlocked { get; set; }

        public void Save(PropertyInfo propertyInfo, PlayerDataModel playerDataModel)
        {
            if (IsSavingBlocked)
            {
                return;
            }

            Debug.Log($"Saving of key({propertyInfo.Name}) with value({propertyInfo.GetValue(playerDataModel)}) started");

            PropertyInfoExtensions.SaveToPlayerPrefs(propertyInfo, playerDataModel);

            Debug.Log($"Saving of key({propertyInfo.Name}) with value({propertyInfo.GetValue(playerDataModel)}) finished");
        }
    }
}
