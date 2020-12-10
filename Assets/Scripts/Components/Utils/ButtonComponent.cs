using UnityEngine;
using UnityEngine.UI;

namespace Components.Utils
{
    [RequireComponent(typeof(Button))]
    public class ButtonComponent : MonoBehaviour
    {
        private Button _button;

        private void Awake()
        {
            _button = this.gameObject.GetComponent<Button>();
        }
        private void Start()
        {
            _button.onClick.AddListener(ButtonOnClick);
        }
        private void OnDestroy()
        {
            _button.onClick.RemoveListener(ButtonOnClick);
        }

        protected virtual void ButtonOnClick()
        {

        }
    }
}
