using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageControls : MonoBehaviour
{
    public static int selectedStage;

    void Start()
    {

    }

    void Update()
    {

    }

    // Jungle Run
    public void PlayJungle()
    {
        selectedStage = 1;

        SceneManager.LoadScene(3);
    }

    // Desert Run
    public void PlayDesert()
    {
        selectedStage = 4;

        SceneManager.LoadScene(3);
    }

    // Main Menu
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    // Stage Select
    public void StageSelect()
    {
        SceneManager.LoadScene(2);
    }

    // Quit Game
    public void QuitGame()
    {
        Application.Quit();
    }
}