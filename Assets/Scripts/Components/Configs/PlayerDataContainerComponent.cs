using Services.PlayerData;
using TMPro;
using UniRx;
using UnityEngine;
using Zenject;

namespace Components.Configs
{
    public class PlayerDataContainerComponent : MonoBehaviour
    {
#pragma warning disable 0649
        [SerializeField]
        private TextMeshProUGUI _prefab;
#pragma warning restore 0649

        private PlayerDataService _playerDataService;

        [Inject]
        public void Construct(PlayerDataService playerDataService)
        {
            _playerDataService = playerDataService;

            _playerDataService.PlayerDataModel.Subscribe(playerDataModel =>
            {
                if (playerDataModel == null)
                {
                    return;
                }

                this.gameObject.transform.DestroyAllChildren();

                var idInstance = Instantiate(_prefab, this.gameObject.transform);
                idInstance.text = playerDataModel.Id.ToString();

                var currentLevelInstance = Instantiate(_prefab, this.gameObject.transform);
                currentLevelInstance.text = playerDataModel.CurrentLevel.ToString();

                var moneyAmountInstance = Instantiate(_prefab, this.gameObject.transform);
                moneyAmountInstance.text = playerDataModel.MoneyAmount.ToString();
            });
        }
    }
}
