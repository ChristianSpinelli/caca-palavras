using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerScenes : MonoBehaviour
{
  public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
        string theme = GameManager.instance.theme;
        GameManager.instance = new GameManager();
        GameManager.instance.theme = theme;
    }

    public void LoadStage(string theme)
    {
        SceneManager.LoadScene("Game");
        GameManager.instance = new GameManager();
        GameManager.instance.theme = theme;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
