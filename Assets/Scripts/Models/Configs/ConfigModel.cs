using System.Collections.Generic;
using JsonObjects;
using UniRx;

namespace Models.Configs
{
    public class ConfigModel
    {
        public ReactiveProperty<int> PlayerMaxLevel { get; private set; }
        public ReactiveCollection<string> QuestIds { get; private set; }
        public ReactiveCollection<string> ShopItemIds { get; private set; }

        public ConfigModel(int playerMaxLevel, List<string> questIds, List<string> shopItemIds)
        {
            PlayerMaxLevel = new ReactiveProperty<int>(playerMaxLevel);
            QuestIds = new ReactiveCollection<string>(questIds);
            ShopItemIds = new ReactiveCollection<string>(shopItemIds);
        }

        public ConfigModel(ConfigsJsonObject configsJsonObject) :
            this(configsJsonObject.PlayerMaxLevel, configsJsonObject.QuestIds, configsJsonObject.ShopItemIds)
        {

        }
    }
}