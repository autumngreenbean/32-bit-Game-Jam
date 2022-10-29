using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
  private void Start() {
    Screen.SetResolution(1920, 1080, FullScreenMode.FullScreenWindow, 60); 
  }

    public void PlayGame()
    {
      SceneManager.LoadScene("GameScene");
    }

    public void QuitGame() {
Debug.Log("Game quit...");
      Application.Quit();
    }
}
