using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicSquareGameManager : MonoBehaviour
{
    public GameObject[] replacementNumbers;

    private int[,] _numbers; 

    private UI_ManagerMagicSquare _uiManager;

    // Start is called before the first frame update
    void Start()
    {
        DisableReplacementNumbers();
        _numbers = new int[3, 3];
        _uiManager = GameObject.Find("Canvas").GetComponent<UI_ManagerMagicSquare>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisableReplacementNumbers()
    {
        for (int i = 0; i < replacementNumbers.Length; i++)
        {
            replacementNumbers[i].SetActive(false);
        }
    }

    public void EnableReplacementNumbers()
    {
        for (int i = 0; i < replacementNumbers.Length; i++)
        {
            replacementNumbers[i].SetActive(true);
        }
    }

    private bool CheckIfWin()
    {
        return true;
    }

    public void CheckLastMovement()
    {
        if (CheckIfWin())
        {
            _uiManager.ShowVictoryScreen();
            _uiManager.StopTimer();
        }
            
    }

    public void RestartGame()
    {
        _uiManager.HideVictoryScreen();
        EnableReplacementNumbers();
        GameObject[] nums = GameObject.FindGameObjectsWithTag("Number");
        for (int i = 0; i < nums.Length; i++)
        {
            nums[i].GetComponent<OptionsNumbers>().ResetPosition();
        }
        DisableReplacementNumbers();

        _uiManager.ResetTimer();
    }
}
