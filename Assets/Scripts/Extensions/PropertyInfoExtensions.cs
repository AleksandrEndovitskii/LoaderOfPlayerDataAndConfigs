using System;
using System.Reflection;
using UnityEngine;

public static class PropertyInfoExtensions
{
    public static void SetValue(this PropertyInfo propertyInfo, object obj, object value)
    {
        //var defaultValue = GetDefaultValue(value.GetType());
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
        PlayerPrefs.SetString(propertyInfo.Name, value.ToString());
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
        var value = PlayerPrefs.GetString(propertyInfo.Name, defaultValue.ToString());
        SetValue(propertyInfo, obj, value);
    }
}
