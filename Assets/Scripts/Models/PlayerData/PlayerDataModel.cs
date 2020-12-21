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

                Debug.Log($"Id changed from {_id} to {value}");

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

                Debug.Log($"CurrentLevel changed from {_currentLevel} to {value}");

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

                Debug.Log($"MoneyAmount changed from {_moneyAmount} to {value}");

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

        }
    }
}