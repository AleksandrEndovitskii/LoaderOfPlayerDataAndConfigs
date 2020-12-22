using System;
using UnityEngine;

namespace Models.PlayerData
{
    public class PlayerDataModel
    {
        public Action<string, string, string> ValueChanged = delegate { };

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

                ValueChanged.Invoke(ReflectionExtensions.GetCallerName(), _id.ToString(), value.ToString());

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

                ValueChanged.Invoke(ReflectionExtensions.GetCallerName(), _currentLevel.ToString(), value.ToString());

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

                ValueChanged.Invoke(ReflectionExtensions.GetCallerName(), _moneyAmount.ToString(), value.ToString());

                _moneyAmount = value;
            }
        }

        private int _id;
        private int _currentLevel;
        private int _moneyAmount;

        public PlayerDataModel(int id, int currentLevel, int moneyAmount) :
            base()
        {
            Id = id;
            CurrentLevel = currentLevel;
            MoneyAmount = moneyAmount;
        }

        public PlayerDataModel()
        {
            ValueChanged += (name, previousValue, currentValue) =>
            {
                Debug.Log($"{GetType().Name}.{ReflectionExtensions.GetCallerName()} changed from {previousValue} to {currentValue}");
            };
        }
    }
}