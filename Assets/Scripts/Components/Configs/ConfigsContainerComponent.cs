using System.Reflection;
using Components.Common.PropertyInfo;
using Services.Configs;
using UniRx;
using UnityEngine;
using Zenject;

namespace Components.Configs
{
    public class ConfigsContainerComponent : MonoBehaviour
    {
        [SerializeField]
        private PropertyInfoComponent _propertyInfoComponentPrefab;

        private DiContainer _diContainer;

        private ConfigsService _configsService;

        [Inject]
        public void Construct(DiContainer diContainer, ConfigsService configsService)
        {
            _diContainer = diContainer;
            _configsService = configsService;

            _configsService.ConfigModel.Subscribe(model =>
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
