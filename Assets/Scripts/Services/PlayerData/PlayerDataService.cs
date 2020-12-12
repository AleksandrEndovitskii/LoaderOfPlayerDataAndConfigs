using Models.PlayerData;
using UniRx;
using UnityEngine;
using Zenject;

namespace Services.PlayerData
{
    public class PlayerDataService
    {
        public ReactiveProperty<PlayerDataModel> PlayerDataModel { get; private set; }

        [Inject]
        public void Construct()
        {
            Debug.Log($"Player data service initialization started");

            PlayerDataModel = new ReactiveProperty<PlayerDataModel>();

            PlayerDataModel.Subscribe(playerDataModel =>
            {
                Debug.Log($"Player data model changed");
            });

            Debug.Log($"Player data service initialization finished");
        }
    }
}