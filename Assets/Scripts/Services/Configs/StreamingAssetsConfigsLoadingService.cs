using System.IO;
using UnityEngine;

namespace Services.Configs
{
    public class StreamingAssetsConfigsLoadingService : URLConfigsLoadingService
    {
        public override void Load()
        {
            var path = GetPathToFileInStreamingAssets(_fileName);
            if (string.IsNullOrEmpty(path))
            {
                Debug.LogError($"No file with name {_fileName} was found in streaming assets");

                return;
            }

            Debug.Log($"File with name {_fileName} was found in streaming assets by path: {path}");

            _url = path;

            base.Load();
        }

        private string GetPathToFileInStreamingAssets(string fileName)
        {
            var result = "";
            var path = Application.streamingAssetsPath + "/" + fileName;

#if (UNITY_EDITOR || UNITY_STANDALONE_LINUX)
                result = "file://" + path;
#endif
#if (UNITY_ANDROID && !UNITY_EDITOR && !UNITY_STANDALONE_LINUX)
//
#endif

                if (!File.Exists(path))
                {
                    return string.Empty;
                }

                return result;
        }
    }
}
