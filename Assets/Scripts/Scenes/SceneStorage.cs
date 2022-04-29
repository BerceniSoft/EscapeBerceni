using System.Collections;
using System.Collections.Generic;
using System;

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
        Dictionary<string,string> sceneStorage;
        try{
            sceneStorage = this.storage[sceneId];
            sceneStorage.Add(key, value);
        } 
        catch(Exception)
        {
            // First inserted key for this scene
            sceneStorage = new Dictionary<string, string>();
            sceneStorage.Add(key, value);
            this.storage.Add(sceneId, sceneStorage);
        }
    }

    public string? GetKey(int sceneId, string key)
    {
        try
        {
            return this.storage[sceneId][key];
        }
        catch(Exception)
        {
            return null;
        }

    }

    public Dictionary<string, string>? GetAllKeysForScene(int sceneId)
    {
        try
        {
            return this.storage[sceneId];
        }
        catch(Exception)
        {
            return null;
        }
    }

}
