using System;
using Services.PlayerData;
using UnityEngine;

namespace Models.PlayerData
{
    public class PlayerDataModel
    {
        public Action<string, string, string> PropertyValueChanged = delegate { };

        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                if (value == _id)
                {
                    return;
                }

                PropertyValueChanged.Invoke(ReflectionExtensions.GetCallerName(), _id.ToString(), value.ToString());

                _id = value;
            }
        }
        public int CurrentLevel
        {
            get
            {
                return _currentLevel;
            }
            set
            {
                if (value == _currentLevel)
                {
                    return;
                }

                PropertyValueChanged.Invoke(ReflectionExtensions.GetCallerName(), _currentLevel.ToString(), value.ToString());

                _currentLevel = value;
            }
        }
        public int MoneyAmount
        {
            get
            {
                return _moneyAmount;
            }
            set
            {
                if (value == _moneyAmount)
                {
                    return;
                }

                PropertyValueChanged.Invoke(ReflectionExtensions.GetCallerName(), _moneyAmount.ToString(), value.ToString());

                _moneyAmount = value;
            }
        }

        private int _id;
        private int _currentLevel;
        private int _moneyAmount;

        private IPlayerDataSavingService _playerDataSavingService;

        public PlayerDataModel(IPlayerDataSavingService playerDataSavingService)
        {
            _playerDataSavingService = playerDataSavingService;

            PropertyValueChanged += (propertyName, previousValue, currentValue) =>
            {
                Debug.Log($"{GetType().Name}.{propertyName} changed from {previousValue} to {currentValue}");

                var propertyInfo = GetType().GetProperty(propertyName);
                _playerDataSavingService.Save(propertyInfo, this);
            };
        }
    }
}