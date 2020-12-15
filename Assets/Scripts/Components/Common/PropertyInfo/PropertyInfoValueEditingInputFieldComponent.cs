﻿using System;
using Services.PlayerData;
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
        private PlayerDataService _playerDataService;

        [Inject]
        public void Construct()
        {
            _inputField = this.gameObject.GetComponent<TMP_InputField>();

            _inputField.onEndEdit.AddListener(InputFieldOnEndEdit);
        }

        private void InputFieldOnEndEdit(string value)
        {
            var propertyInfo = propertyInfoComponent.PropertyInfo;
            var convertedValue = Convert.ChangeType(value, propertyInfo.PropertyType);
            propertyInfo.SetValue(propertyInfoComponent.Object, convertedValue);
        }
    }
}