using System.Reflection;
using Models.PlayerData;

namespace Services.PlayerData
{
    public interface IPlayerDataSavingService
    {
        void Save(PropertyInfo propertyInfo, PlayerDataModel playerDataModel);
    }
}
