using System;
using System.Reflection;
using UnityEngine;

namespace Components.Utils
{
    public class PropertyInfoComponent : MonoBehaviour
    {
        public Action<System.Object> ObjectChanged = delegate { };
        public Action<PropertyInfo> PropertyInfoChanged = delegate { };

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
        public PropertyInfo PropertyInfo
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
        private PropertyInfo _propertyInfo;
    }
}
