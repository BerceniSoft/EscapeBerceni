using System.Collections;
using System.Collections.Generic;

#nullable enable
public class SceneStorage
{
    private Dictionary<int, Dictionary<string, string>> storage;

    private SceneStorage()
    {
        this.storage = new Dictionary<int, Dictionary<string,string>>();
    }

    private static SceneStorage? instance = null;

    public static SceneStorage getInstance()
    {
        if(SceneStorage.instance == null)
        {
            SceneStorage.instance = new SceneStorage();
        }

        return SceneStorage.instance;
    }

    public void AddKey(int sceneId, string key, string value)
    {
        var sceneStorage = this.storage[sceneId];

        if(sceneStorage == null)
        {
            // First inserted key for this scene
            sceneStorage = new Dictionary<string, string>();
            sceneStorage.Add(key, value);
            this.storage.Add(sceneId, sceneStorage);
        }
        else
        {
            sceneStorage.Add(key, value);
        }
    }

    public string? GetKey(int sceneId, string key)
    {
         var sceneStorage = this.storage[sceneId];
         
         if(sceneStorage == null)
         {
             return null;
         }

         return sceneStorage[key];
    }

    public Dictionary<string, string>? GetAllKeysForScene(int sceneId)
    {
        return this.storage[sceneId];
    }

}
