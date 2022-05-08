#nullable enable
using System;
using System.Collections.Generic;

namespace Scenes
{
    public class SceneStorage
    {
        private static SceneStorage? _instance;

        private readonly Dictionary<int, Dictionary<string, string>> _storage;

        private SceneStorage()
        {
            _storage = new Dictionary<int, Dictionary<string,string>>();
        }

        public static SceneStorage GetInstance() => _instance ??= new SceneStorage();

        public void SetKey(int sceneId, string key, string value)
        {
            Dictionary<string,string> sceneStorage;
            try 
            {
                sceneStorage = _storage[sceneId];
                sceneStorage[key] = value;
            } 
            catch (Exception)
            {
                // First inserted key for this scene
                sceneStorage = new Dictionary<string, string> { { key, value } };
                _storage.Add(sceneId, sceneStorage);
            }
        }

        public string? GetKey(int sceneId, string key)
        {
            try
            {
                return _storage[sceneId][key];
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Dictionary<string, string>? GetAllKeysForScene(int sceneId)
        {
            try
            {
                return _storage[sceneId];
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
