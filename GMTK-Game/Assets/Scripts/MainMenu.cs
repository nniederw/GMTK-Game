using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void LoadTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
    public void LoadTutorialLevel()
    {
        SceneManager.LoadScene("TutorialLevel");
    }
    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level 1");
    }
    public void LoadLevel2()
    {
        SceneManager.LoadScene("Level 2");
    }
    public void LoadLevel3()
    {
        SceneManager.LoadScene("Level 3");
    }
}