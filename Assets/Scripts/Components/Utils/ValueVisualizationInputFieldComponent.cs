using TMPro;
using UnityEngine;
using Zenject;

namespace Components.Utils
{
    [RequireComponent(typeof(TMP_InputField))]
    public class ValueVisualizationInputFieldComponent : MonoBehaviour
    {
        [SerializeField]
        private KeyValueComponent _keyValueComponent;
        private TMP_InputField _inputField;

        [Inject]
        public void Construct()
        {
            _inputField = this.gameObject.GetComponent<TMP_InputField>();

            KeyValueComponentOnValueChanged(_keyValueComponent.Value);

            _keyValueComponent.ValueChanged += KeyValueComponentOnValueChanged;
        }

        private void KeyValueComponentOnValueChanged(string value)
        {
            if (value == "")
            {
                return;
            }

            _inputField.text = value;
        }
    }
}
