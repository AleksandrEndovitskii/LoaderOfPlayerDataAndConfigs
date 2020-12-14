using System;
using System.Collections.Generic;

namespace JsonObjects
{
    [Serializable]
    public class ConfigsJsonObject
    {
        public int PlayerMaxLevel;
        public List<string> QuestIds = new List<string>();
        public List<string> ShopItemIds = new List<string>();
    }
}
