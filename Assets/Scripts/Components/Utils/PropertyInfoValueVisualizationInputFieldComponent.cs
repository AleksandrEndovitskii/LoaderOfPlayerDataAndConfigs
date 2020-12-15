using System.Reflection;
using TMPro;
using UnityEngine;
using Zenject;

namespace Components.Utils
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

        private void PropertyInfoComponentOnValueChanged(PropertyInfo propertyInfo)
        {
            if (propertyInfo == null)
            {
                return;
            }

            _inputField.text = propertyInfo.GetValue(_propertyInfoComponent.Object).ToString();
        }
    }
}
