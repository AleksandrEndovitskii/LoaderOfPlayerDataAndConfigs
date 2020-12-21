using TMPro;
using UnityEngine;
using Zenject;

namespace Components.Common.PropertyInfo
{
    [RequireComponent(typeof(TMP_InputField))]
    public class PropertyInfoValueEditingInputFieldComponent : MonoBehaviour
    {
        [SerializeField]
        private PropertyInfoComponent propertyInfoComponent;
        private TMP_InputField _inputField;

        [Inject]
        public void Construct()
        {
            _inputField = this.gameObject.GetComponent<TMP_InputField>();

            _inputField.onEndEdit.AddListener(InputFieldOnEndEdit);
        }

        private void InputFieldOnEndEdit(string value)
        {
            PropertyInfoExtensions.SetValue(propertyInfoComponent.PropertyInfo, propertyInfoComponent.Object, value);
            PropertyInfoExtensions.SaveToPlayerPrefs(propertyInfoComponent.PropertyInfo, propertyInfoComponent.Object);
        }
    }
}
