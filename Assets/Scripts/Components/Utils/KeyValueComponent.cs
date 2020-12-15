using System;
using UnityEngine;

namespace Components.Utils
{
    public class KeyValueComponent : MonoBehaviour
    {
        public Action<string> KeyChanged = delegate { };
        public Action<string> ValueChanged = delegate { };

#pragma warning disable 0649
        [SerializeField]
        private string _key;
        [SerializeField]
        private string _value;
#pragma warning restore 0649

        public string Key
        {
            get
            {
                return _key;
            }
            set
            {
                if (value == _key)
                {
                    return;
                }

                _key = value;

                KeyChanged.Invoke(_key);
            }
        }
        public string Value
        {
            get
            {
                return _value;
            }
            set
            {
                if (value == _value)
                {
                    return;
                }

                _value = value;

                ValueChanged.Invoke(_value);
            }
        }
    }
}
