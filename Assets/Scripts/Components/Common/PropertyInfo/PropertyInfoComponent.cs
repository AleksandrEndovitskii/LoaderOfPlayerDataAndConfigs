using System;
using UnityEngine;

namespace Components.Common.PropertyInfo
{
    public class PropertyInfoComponent : MonoBehaviour
    {
        public Action<System.Object> ObjectChanged = delegate { };
        public Action<System.Reflection.PropertyInfo> PropertyInfoChanged = delegate { };

        public System.Object Object
        {
            get
            {
                return _object;
            }
            set
            {
                if (value == _object)
                {
                    return;
                }

                _object = value;

                ObjectChanged.Invoke(_object);
            }
        }
        public System.Reflection.PropertyInfo PropertyInfo
        {
            get
            {
                return _propertyInfo;
            }
            set
            {
                if (value == _propertyInfo)
                {
                    return;
                }

                _propertyInfo = value;

                PropertyInfoChanged.Invoke(_propertyInfo);
            }
        }

        private System.Object _object;
        private System.Reflection.PropertyInfo _propertyInfo;
    }
}
