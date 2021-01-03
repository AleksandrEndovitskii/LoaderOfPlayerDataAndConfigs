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

        protected string _fileName = "Configs.json";

        protected string _url = "http://localhost:3000/Configs.json"; //TODO: add correct server ulr here

        public virtual void Load()
        {
            Debug.Log($"Loading of Configs from {_url} started");

            _fooMonoBehaviour.StartCoroutine(GetRequest(_url, request =>
            {
                HandleResponse(request, Parse);

                Debug.Log($"Loading of Configs from {_url} finished");
            }));
        }

        protected IEnumerator GetRequest(string endpoint, Action<UnityWebRequest> callback)
        {
            using (var request = UnityWebRequest.Get(endpoint))
            {
                Debug.Log($"Sending of GetRequest to {endpoint} started");

                // Send the request and wait for a response
                yield return request.SendWebRequest();

                Debug.Log($"Sending of GetRequest to {endpoint} finished");

                callback(request);
            }
        }

        protected void HandleResponse(UnityWebRequest unityWebRequest, Action<string> callback)
        {
            Debug.Log($"Handling of web response started");

            if (unityWebRequest.result == UnityWebRequest.Result.ConnectionError ||
                unityWebRequest.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log($"Handling of web response finished with error {unityWebRequest.error}");
            }
            else
            {
                if (unityWebRequest.isDone)
                {
                    var jsonString = System.Text.Encoding.UTF8.GetString(unityWebRequest.downloadHandler.data);

                    Debug.Log($"Handling of web response finished");

                    callback(jsonString);
                }
            }
        }

        protected void Parse(string jsonString)
        {
            Debug.Log($"Parsing of jsonString {jsonString} started");

            var jsonObject = JObject.Parse(jsonString);
            var configModel = jsonObject.ParseTo<ConfigModel>();

            Debug.Log($"Parsing of jsonString {jsonString} finished");

            _configsService.ConfigModel.Value = configModel;
        }
    }
}
