using System.Reflection;
using Models.PlayerData;

namespace Services.PlayerData
{
    public interface IPlayerDataSavingService
    {
        bool IsSavingBlocked { get; set; }

        void Save(PropertyInfo propertyInfo, PlayerDataModel playerDataModel);
    }
}
