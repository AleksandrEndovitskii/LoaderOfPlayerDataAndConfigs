using Services.PlayerData;
using UniRx;
using UnityEngine;
using Zenject;

namespace Components.PlayerData
{
    public class IsPlayerDataNotEmptyActivationComponent : MonoBehaviour
    {
        private PlayerDataService _playerDataService;

        [Inject]
        public void Construct(PlayerDataService playerDataService)
        {
            _playerDataService = playerDataService;

            _playerDataService.PlayerDataModel.Subscribe(playerDataModel =>
            {
                this.gameObject.SetActive(playerDataModel != null);
            });
        }
    }
}
