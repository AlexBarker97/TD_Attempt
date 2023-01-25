using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagment : MonoBehaviour
{
    private Scene activeScene;
    public void ReloadScene()
    {
        activeScene = SceneManager.GetActiveScene();
        SceneManager.LoadSceneAsync(activeScene.name);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void LoadNewScene(string scene)
    {
        string levelToLoad;
        levelToLoad = scene;
        SceneManager.LoadSceneAsync(levelToLoad);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log(SceneManager.sceneCount);
    }
}
