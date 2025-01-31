using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    Scene currentScene;
    string sceneName;
    public void LoadScene(int index) => SceneManager.LoadScene(index);

    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
    }
    public void LoadScene() => SceneManager.LoadScene(sceneName);
    public void Quit() => Application.Quit();

}
