using System.Reflection;
using Components.Common.PropertyInfo;
using Services.PlayerData;
using UniRx;
using UnityEngine;
using Zenject;

namespace Components.PlayerData
{
    public class PlayerDataContainerComponent : MonoBehaviour
    {
        [SerializeField]
        private PropertyInfoComponent _propertyInfoComponentPrefab;

        private DiContainer _diContainer;

        private PlayerDataService _playerDataService;

        [Inject]
        public void Construct(DiContainer diContainer, PlayerDataService playerDataService)
        {
            _diContainer = diContainer;
            _playerDataService = playerDataService;

            _playerDataService.PlayerDataModel.Subscribe(model =>
            {
                if (model == null)
                {
                    return;
                }

                this.gameObject.transform.DestroyAllChildren();

                var propertyInfos = model.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
                foreach (var propertyInfo in propertyInfos)
                {
                    var propertyInfoComponentInstance =  _diContainer.InstantiatePrefab(
                        _propertyInfoComponentPrefab,
                        this.gameObject.transform).GetComponent<PropertyInfoComponent>();
                    propertyInfoComponentInstance.Object = model;
                    propertyInfoComponentInstance.PropertyInfo = propertyInfo;
                }
            });
        }
    }
}
