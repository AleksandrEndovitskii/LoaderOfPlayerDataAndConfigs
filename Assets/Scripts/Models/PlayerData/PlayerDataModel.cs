using System;
using UnityEngine;

namespace Models.PlayerData
{
    public class PlayerDataModel
    {
        public Action<int> IdChanged = delegate { };
        public Action<int> CurrentLevelChanged = delegate { };
        public Action<int> MoneyAmountChanged = delegate { };
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

                _id = value;

                IdChanged.Invoke(_id);
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

                _currentLevel = value;

                CurrentLevelChanged.Invoke(_currentLevel);
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

                _moneyAmount = value;

                MoneyAmountChanged.Invoke(_moneyAmount);
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
            IdChanged += value =>
            {
                var oldValue = "None";
                if (PlayerPrefs.HasKey("Id"))
                {
                    oldValue = PlayerPrefs.GetString("Id");
                }
                Debug.Log($"Id changed from {oldValue} to {value}");
            };
            CurrentLevelChanged += value =>
            {
                var oldValue = "None";
                if (PlayerPrefs.HasKey("CurrentLevel"))
                {
                    oldValue = PlayerPrefs.GetString("CurrentLevel");
                }
                Debug.Log($"CurrentLevel changed from {oldValue} to {value}");
            };
            MoneyAmountChanged += value =>
            {
                var oldValue = "None";
                if (PlayerPrefs.HasKey("MoneyAmount"))
                {
                    oldValue = PlayerPrefs.GetString("MoneyAmount");
                }
                Debug.Log($"MoneyAmount changed from {oldValue} to {value}");
            };
        }
    }
}