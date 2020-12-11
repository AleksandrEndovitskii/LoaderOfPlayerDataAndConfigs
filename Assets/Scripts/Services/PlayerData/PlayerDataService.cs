using Models.PlayerData;
using UniRx;
using UnityEngine;
using Zenject;

namespace Services.PlayerData
{
    public class PlayerDataService : IInitializable
    {
        public ReactiveProperty<PlayerDataModel> PlayerDataModel => new ReactiveProperty<PlayerDataModel>();

        [Inject]
        private PlayerDataLoadingService _playerDataLoadingService;

        public void Initialize()
        {
            Debug.Log($"Player data service initialization started");

            PlayerDataModel.Subscribe(configModel =>
            {
                Debug.Log($"Player data model changed");
            });

            PlayerDataModel.Value = _playerDataLoadingService.Load();

            Debug.Log($"Player data service initialization finished");
        }
    }
}