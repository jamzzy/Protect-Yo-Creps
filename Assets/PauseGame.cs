using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseGame : MonoBehaviour
{

    public bool pause = false;
    public int score = 0;
   
    public GameObject winpanel;
    public GameObject losepanel;
    public AudioManager am;

 public void WinGame()
    {
        winpanel.SetActive(true);
        am.Jheez();
    }
    public void LoseGame()
    {
        losepanel.SetActive(true);
        am.Fault();
    }

    public void GamePause()
    {
        pause = true;
    }
    public void GameUnPause()
    {
        pause = false;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    


}
