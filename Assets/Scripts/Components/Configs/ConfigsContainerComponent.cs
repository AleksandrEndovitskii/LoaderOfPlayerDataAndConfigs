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
#pragma warning disable 0649
        [SerializeField]
        private PropertyInfoComponent _propertyInfoComponentPrefab;
#pragma warning restore 0649

        [Inject]
        readonly DiContainer _container = null;

        private ConfigsService _configsService;

        [Inject]
        public void Construct(ConfigsService configsService)
        {
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
                    var propertyInfoComponentInstance =  _container.InstantiatePrefab(
                        _propertyInfoComponentPrefab,
                        this.gameObject.transform).GetComponent<PropertyInfoComponent>();
                    propertyInfoComponentInstance.Object = model;
                    propertyInfoComponentInstance.PropertyInfo = propertyInfo;
                }
            });
        }
    }
}
