using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

namespace Components.Common.PropertyInfo
{
    [RequireComponent(typeof(TMP_InputField))]
    public class PropertyInfoValueVisualizationInputFieldComponent : MonoBehaviour
    {
        [SerializeField]
        private PropertyInfoComponent _propertyInfoComponent;
        private TMP_InputField _inputField;

        [Inject]
        public void Construct()
        {
            _inputField = this.gameObject.GetComponent<TMP_InputField>();

            PropertyInfoComponentOnValueChanged(_propertyInfoComponent.PropertyInfo);

            _propertyInfoComponent.PropertyInfoChanged += PropertyInfoComponentOnValueChanged;
        }

        private void PropertyInfoComponentOnValueChanged(System.Reflection.PropertyInfo propertyInfo)
        {
            if (propertyInfo == null)
            {
                return;
            }

            var value = propertyInfo.GetValue(_propertyInfoComponent.Object);
            if (value is List<string> enumerable)
            {
                _inputField.text = ListExtensions.ToString(enumerable);
            }
            else
            {
                _inputField.text = value.ToString();
            }
        }
    }
}
