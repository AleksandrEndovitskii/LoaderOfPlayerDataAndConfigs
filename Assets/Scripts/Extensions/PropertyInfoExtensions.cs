using System;
using System.Reflection;
using UnityEngine;

public static class PropertyInfoExtensions
{
    public static void SetValue(this PropertyInfo propertyInfo, object obj, object value)
    {
        var convertedValue = Convert.ChangeType(value, propertyInfo.PropertyType);
        propertyInfo.SetValue(obj, convertedValue);
    }

    public static object GetDefaultValue(Type t)
    {
        if (t.IsValueType)
            return Activator.CreateInstance(t);

        return null;
    }

    public static void SaveToPlayerPrefs(PropertyInfo propertyInfo, System.Object obj)
    {
        if (propertyInfo == null)
        {
            return;
        }
        if (obj == null)
        {
            return;
        }
        var value = propertyInfo.GetValue(obj);
        var key = obj.GetType().Name + "_" + propertyInfo.Name;
        PlayerPrefs.SetString(key, value.ToString());
    }
    public static void LoadFromPlayerPrefs(PropertyInfo propertyInfo, System.Object obj)
    {
        if (propertyInfo == null)
        {
            return;
        }
        if (obj == null)
        {
            return;
        }
        var defaultValue = GetDefaultValue(propertyInfo.PropertyType);
        var key = obj.GetType().Name + "_" + propertyInfo.Name;
        var value = PlayerPrefs.GetString(key, defaultValue.ToString());
        SetValue(propertyInfo, obj, value);
    }
}
