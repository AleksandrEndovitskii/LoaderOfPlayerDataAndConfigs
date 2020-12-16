using System.Collections.Generic;

namespace Models.Configs
{
    public class ConfigModel
    {
        public int PlayerMaxLevel { get; private set; }
        public List<string> QuestIds { get; private set; }
        public List<string> ShopItemIds { get; private set; }
    }
}