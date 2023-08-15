using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gamemanager : MonoBehaviour
{
    public static int enemyCount = 0;
    public static int coincount = 0;
    public static int currentlevel = 0;
    private void Update()
    {
        if (enemyCount <= 0 && coincount <= 0)
        {
           LoadNextLevel();
            currentlevel++;
        }
    }

    private void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);  
    }
}
