using System;
using System.Reflection;
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
            var playerDataModel = new PlayerDataModel();
            var propertyInfos = playerDataModel.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var propertyInfo in propertyInfos)
            {
                var defaultValue = 1;//(int) GetDefaultValue(propertyInfo.PropertyType);
                var value = PlayerPrefs.GetInt(propertyInfo.Name, defaultValue);
                SetValue(propertyInfo, playerDataModel, value);
            }

            _playerDataService.PlayerDataModel.Value = playerDataModel;
        }

        private void SetValue(PropertyInfo propertyInfo, object instance, object value)
        {
            propertyInfo.SetValue(instance, Convert.ChangeType(value, propertyInfo.PropertyType));
        }

        private object GetDefaultValue(Type t)
        {
            if (t.IsValueType)
                return Activator.CreateInstance(t);

            return null;
        }
    }
}
