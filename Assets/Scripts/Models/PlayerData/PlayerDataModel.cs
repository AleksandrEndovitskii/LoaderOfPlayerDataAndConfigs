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

                var previousValue = _id;
                _id = value;
                PropertyValueChanged.Invoke(ReflectionExtensions.GetCallerName(),
                    previousValue.ToString(), _id.ToString());
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

                var previousValue = _currentLevel;
                _currentLevel = value;
                PropertyValueChanged.Invoke(ReflectionExtensions.GetCallerName(),
                    previousValue.ToString(), _currentLevel.ToString());
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

                var previousValue = _moneyAmount;
                _moneyAmount = value;
                PropertyValueChanged.Invoke(ReflectionExtensions.GetCallerName(),
                    previousValue.ToString(), _moneyAmount.ToString());
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