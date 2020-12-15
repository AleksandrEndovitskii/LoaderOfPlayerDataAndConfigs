using System;
using Services.PlayerData;
using TMPro;
using UnityEngine;
using Zenject;

namespace Components.Utils
{
    [RequireComponent(typeof(TMP_InputField))]
    public class ValueEditingInputFieldComponent : MonoBehaviour
    {
        [SerializeField]
        private KeyValueComponent _keyValueComponent;
        private TMP_InputField _inputField;
        private PlayerDataService _playerDataService;

        [Inject]
        public void Construct(PlayerDataService playerDataService)
        {
            _inputField = this.gameObject.GetComponent<TMP_InputField>();

            _playerDataService = playerDataService;

            _inputField.onEndEdit.AddListener(InputFieldOnEndEdit);
        }

        private void InputFieldOnEndEdit(string value)
        {
            var type = _playerDataService.PlayerDataModel.Value.GetType();
            var propertyInfo = type.GetProperty(_keyValueComponent.Key);
            var convertedValue = Convert.ChangeType(value, propertyInfo.PropertyType);
            propertyInfo.SetValue(_playerDataService.PlayerDataModel.Value, convertedValue);
        }
    }
}
