using UniRx;

namespace Models.PlayerData
{
    public class PlayerDataModel
    {
        public ReactiveProperty<int> Id { get; private set; }
        public ReactiveProperty<int> CurrentLevel { get; private set; }
        public ReactiveProperty<int> MoneyAmount { get; private set; }

        public PlayerDataModel(int id, int currentLevel, int moneyAmount)
        {
            Id = new ReactiveProperty<int>(id);
            CurrentLevel = new ReactiveProperty<int>(currentLevel);
            MoneyAmount = new ReactiveProperty<int>(moneyAmount);
        }
    }
}