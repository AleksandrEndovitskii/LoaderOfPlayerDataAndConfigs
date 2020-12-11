using Models.PlayerData;
using UniRx;
using UnityEngine;
using Zenject;

namespace Services.PlayerData
{
    public class PlayerDataService : IInitializable
    {
        public ReactiveProperty<PlayerDataModel> PlayerDataModel => new ReactiveProperty<PlayerDataModel>();

        public void Initialize()
        {
            Debug.Log($"Player data service initialization started");

            PlayerDataModel.Subscribe(playerDataModel =>
            {
                Debug.Log($"Player data model changed");
            });

            Debug.Log($"Player data service initialization finished");
        }
    }
}