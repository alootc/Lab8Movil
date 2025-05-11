using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Collections.Generic;

public class GlobalSceneManager : SingletonPersistent<GlobalSceneManager>
{
    public event Action<string> OnSceneLoaded;
    public event Action<string> OnSceneUnloaded;
    public event Action<string> OnSceneActiveChanged;

    private List<string> loadedScenes = new List<string>();

    public void LoadScene(string sceneName, LoadSceneMode mode = LoadSceneMode.Additive)
    {
        if (!loadedScenes.Contains(sceneName))
        {
            SceneManager.LoadScene(sceneName, mode);
            loadedScenes.Add(sceneName);
            OnSceneLoaded?.Invoke(sceneName);
        }
    }

    public void UnloadScene(string sceneName)
    {
        if (loadedScenes.Contains(sceneName))
        {
            SceneManager.UnloadSceneAsync(sceneName);
            loadedScenes.Remove(sceneName);
            OnSceneUnloaded?.Invoke(sceneName);
        }
    }

    public void SetActiveScene(string sceneName)
    {
        Scene scene = SceneManager.GetSceneByName(sceneName);
        if (scene.isLoaded)
        {
            SceneManager.SetActiveScene(scene);
            OnSceneActiveChanged?.Invoke(sceneName);
        }
    }

    public bool IsSceneLoaded(string sceneName)
    {
        return loadedScenes.Contains(sceneName);
    }
}