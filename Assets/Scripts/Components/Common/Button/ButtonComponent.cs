using UnityEngine;

namespace Components.Common.Button
{
    [RequireComponent(typeof(UnityEngine.UI.Button))]
    public class ButtonComponent : MonoBehaviour
    {
        private UnityEngine.UI.Button _button;

        private void Awake()
        {
            _button = this.gameObject.GetComponent<UnityEngine.UI.Button>();
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
