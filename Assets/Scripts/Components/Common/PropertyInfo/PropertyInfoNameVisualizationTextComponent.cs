using TMPro;
using UnityEngine;
using Zenject;

namespace Components.Common.PropertyInfo
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class PropertyInfoNameVisualizationTextComponent : MonoBehaviour
    {
        [SerializeField]
        private PropertyInfoComponent _propertyInfoComponent;
        private TextMeshProUGUI _text;

        [Inject]
        public void Construct()
        {
            _text = this.gameObject.GetComponent<TextMeshProUGUI>();

            PropertyInfoComponentOnPropertyInfoChanged(_propertyInfoComponent.PropertyInfo);

            _propertyInfoComponent.PropertyInfoChanged += PropertyInfoComponentOnPropertyInfoChanged;
        }

        private void PropertyInfoComponentOnPropertyInfoChanged(System.Reflection.PropertyInfo propertyInfo)
        {
            if (propertyInfo == null)
            {
                return;
            }

            _text.text = propertyInfo.Name;
        }
    }
}
