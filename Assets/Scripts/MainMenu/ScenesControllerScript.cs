﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesControllerScript : MonoBehaviour
{



    public void LoadDisksGame()
    {
        SceneManager.LoadScene("DisksScene");
    }

    public void LoadFourEquations()
    {
        SceneManager.LoadScene("FourEquationsScene");
    }

    public void LoadRLHM()
    {
        SceneManager.LoadScene("Hanoi");
    }
    public void LoadCubos()
    {
        SceneManager.LoadScene("RL&HM");
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void LoadHerradura()
    {
        SceneManager.LoadScene("Herradura");
    }

    public void LoadColorSquares()
    {
        SceneManager.LoadScene("ColorSquaresScene");
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
