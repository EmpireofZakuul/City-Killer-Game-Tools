using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Button StartGame;
    public Button GameCredits;
    public Button GameControls;
    public Button QuitGame;
    public Button HowTo;
    public Button ReturnMainMenu;

    public SceneFader SceneFader;



    public void PlayGamelevel()
    {
        SceneManager.LoadScene("GameLevel");
       // SceneFader.FadTo("GameLevel");
    }

    public void GameMenuCredits()
    {
         SceneManager.LoadScene("Credits");
        //SceneFader.FadTo("Credits");
    }

    public void GameMenuControls()
    {
        SceneManager.LoadScene("Controls");
        //SceneFader.FadTo("Controls");
    }

    public void GameObjectives()
    {
        SceneManager.LoadScene("HowToPlay");
        //SceneFader.FadTo("HowToPlay");
    }


    public void QuitGameMenu()
    {

#if UNITY_STANDALONE
        Application.Quit();
#endif

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }


    public void ReturnMenu()
    {
         SceneManager.LoadScene("Menu");
        //SceneFader.FadTo("Menu");
    }
}
