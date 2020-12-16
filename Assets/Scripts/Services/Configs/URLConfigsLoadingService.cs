using System;
using System.Collections;
using Common;
using Models.Configs;
using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.Networking;
using Zenject;

namespace Services.Configs
{
    public class URLConfigsLoadingService : IConfigsLoadingService
    {
        [Inject]
        private ConfigsService _configsService;
        [Inject]
        private FooMonoBehaviour _fooMonoBehaviour;

        private string url = "http://localhost:3000/Configs.json"; //TODO: add correct server ulr here

        public void Load()
        {
            Debug.Log($"Configs loading started");

            _fooMonoBehaviour.StartCoroutine(GetRequest(url, request =>
            {
                HandleResponse(request, Parse);
            }));
        }

        private IEnumerator GetRequest(string endpoint, Action<UnityWebRequest> callback)
        {
            using (var request = UnityWebRequest.Get(endpoint))
            {
                // Send the request and wait for a response
                yield return request.SendWebRequest();

                callback(request);
            }
        }

        private void HandleResponse(UnityWebRequest unityWebRequest, Action<string> callback)
        {
            if (unityWebRequest.isNetworkError || unityWebRequest.isHttpError)
            {
                Debug.Log("Error " + unityWebRequest.error);
            }
            else
            {
                if (unityWebRequest.isDone)
                {
                    var jsonString = System.Text.Encoding.UTF8.GetString(unityWebRequest.downloadHandler.data);

                    callback(jsonString);
                }
            }
        }

        private void Parse(string jsonString)
        {
            var jsonObject = JObject.Parse(jsonString);
            var configModel = jsonObject.ParseTo<ConfigModel>();

            Debug.Log($"Configs loading finished");

            _configsService.ConfigModel.Value = configModel;
        }
    }
}
