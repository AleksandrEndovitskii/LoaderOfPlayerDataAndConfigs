using TMPro;
using UnityEngine;
using Zenject;

namespace Components.Utils
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class KeyVisualizationTextComponent : MonoBehaviour
    {
        [SerializeField]
        private KeyValueComponent _keyValueComponent;
        private TextMeshProUGUI _text;

        [Inject]
        public void Construct()
        {
            _text = this.gameObject.GetComponent<TextMeshProUGUI>();

            IdComponentOnKeyChanged(_keyValueComponent.Key);

            _keyValueComponent.KeyChanged += IdComponentOnKeyChanged;
        }

        private void IdComponentOnKeyChanged(string key)
        {
            if (key == "")
            {
                return;
            }

            _text.text = key;
        }
    }
}
