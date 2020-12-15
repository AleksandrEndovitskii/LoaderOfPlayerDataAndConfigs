using System.Reflection;
using Components.Common.PropertyInfo;
using Services.PlayerData;
using UniRx;
using UnityEngine;
using Zenject;

namespace Components.Configs
{
    public class PlayerDataContainerComponent : MonoBehaviour
    {
#pragma warning disable 0649
        [SerializeField]
        private PropertyInfoComponent _prefab;
#pragma warning restore 0649

        [Inject]
        readonly DiContainer _container = null;

        private PlayerDataService _playerDataService;

        [Inject]
        public void Construct(PlayerDataService playerDataService)
        {
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
                    var propertyInfoComponent =  _container.InstantiatePrefab(
                        _prefab,
                        this.gameObject.transform).GetComponent<PropertyInfoComponent>();
                    propertyInfoComponent.Object = model;
                    propertyInfoComponent.PropertyInfo = propertyInfo;
                }
            });
        }
    }
}
