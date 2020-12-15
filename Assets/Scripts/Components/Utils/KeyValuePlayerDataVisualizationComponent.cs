using System;
using Services.PlayerData;
using TMPro;
using UnityEngine;
using Zenject;

namespace Components.Utils
{
    [RequireComponent(typeof(KeyValueComponent))]
    [RequireComponent(typeof(TMP_InputField))]
    public class KeyValuePlayerDataVisualizationComponent : MonoBehaviour
    {
        private KeyValueComponent _keyValueComponent;
        private TMP_InputField _inputField;
        private PlayerDataService _playerDataService;

        [Inject]
        public void Construct(PlayerDataService playerDataService)
        {
            _inputField = this.gameObject.GetComponent<TMP_InputField>();
            _keyValueComponent = this.gameObject.GetComponent<KeyValueComponent>();

            _playerDataService = playerDataService;

            IdComponentOnIdChanged(_playerDataService.PlayerDataModel.Value.Id.ToString());

            _inputField.onEndEdit.AddListener(InputFieldOnEndEdit);
            _keyValueComponent.ValueChanged += IdComponentOnIdChanged;
        }

        private void InputFieldOnEndEdit(string value)
        {
            _playerDataService.PlayerDataModel.Value.Id = Convert.ToInt32(value);
        }
        private void IdComponentOnIdChanged(string id)
        {
            if (id == "")
            {
                return;
            }

            _inputField.text = _playerDataService.PlayerDataModel.Value.Id.ToString();
        }
    }
}
