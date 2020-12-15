using System.Collections.Generic;
using JsonObjects;

namespace Models.Configs
{
    public class ConfigModel
    {
        public int PlayerMaxLevel { get; private set; }
        public List<string> QuestIds { get; private set; }
        public List<string> ShopItemIds { get; private set; }

        public ConfigModel(int playerMaxLevel, List<string> questIds, List<string> shopItemIds)
        {
            PlayerMaxLevel = playerMaxLevel;
            QuestIds = new List<string>(questIds);
            ShopItemIds = new List<string>(shopItemIds);
        }

        public ConfigModel(ConfigsJsonObject configsJsonObject) :
            this(configsJsonObject.PlayerMaxLevel, configsJsonObject.QuestIds, configsJsonObject.ShopItemIds)
        {

        }
    }
}