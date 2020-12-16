using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json.Linq;

public static class JObjectExtensions
{
    public static T ParseTo<T>(this JObject jsonObject) where T : new()
    {
        var configModel = new T();
        var propertyInfos = configModel.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
        foreach (var propertyInfo in propertyInfos)
        {
            var jsonToken = jsonObject[propertyInfo.Name];
            System.Object value = null;
            if (jsonToken is JArray)
            {
                var jArray = jsonToken.Value<JArray>();
                value = jArray.ToObject<List<string>>();
            }
            else
            {
                value = jsonToken.ToObject<string>();
            }

            PropertyInfoExtensions.SetValue(propertyInfo, configModel, value);
        }

        return configModel;
    }
}
