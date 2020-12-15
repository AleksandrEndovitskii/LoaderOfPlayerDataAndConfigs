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

            _inputField.text = propertyInfo.GetValue(_propertyInfoComponent.Object).ToString();
        }
    }
}
