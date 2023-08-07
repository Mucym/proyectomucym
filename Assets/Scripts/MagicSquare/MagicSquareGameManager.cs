using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicSquareGameManager : MonoBehaviour
{
   
    public GameObject[] objects;
    private int[,] _numbers;

    private MagicUIManager _uiManager;
    // Start is called before the first frame update
    void Start()
    {
        DisableReplacementNumbers();
        _numbers = new int[3, 3];
        _uiManager = GameObject.Find("Canvas").GetComponent<MagicUIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisableReplacementNumbers()
    {
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i].SetActive(false);
        }
    }

    public void EnableReplacementNumbers()
    {
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i].SetActive(true);
        }
    }

    private bool CheckIfWin()
    {
        // Verificar las sumas de filas, columnas y diagonales
        int[] sums = new int[8];

        for (int i = 0; i < 3; i++)
        {
            sums[i] = objects[i].GetComponent<Numbers>().value +
                      objects[i + 3].GetComponent<Numbers>().value +
                      objects[i + 6].GetComponent<Numbers>().value;

            sums[i + 3] = objects[i * 3].GetComponent<Numbers>().value +
                          objects[i * 3 + 1].GetComponent<Numbers>().value +
                          objects[i * 3 + 2].GetComponent<Numbers>().value;

            sums[6] += objects[i * 3 + i].GetComponent<Numbers>().value;
            sums[7] += objects[i * 3 + 2 - i].GetComponent<Numbers>().value;
        }

        for (int i = 1; i < sums.Length; i++)
        {
            if (sums[i] != sums[0])
            {
                return false;
            }
        }

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
            nums[i].GetComponent<Numbers>().ResetPosition();
        }
        DisableReplacementNumbers();

        _uiManager.ResetTimer();
    }

}
