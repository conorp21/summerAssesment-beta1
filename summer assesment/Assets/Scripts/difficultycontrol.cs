using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    
    public static DifficultyManager instance;

   
    public int playerLives;
    public int playerKeys;
    public int numberOfEnemies;
    public int numberOfPowerups;

    void Awake()
    {

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void SetEasyDifficulty()
    {
        playerLives = 3;
        playerKeys = 3;
        numberOfEnemies = 3;
        numberOfPowerups = 3;
    }

    public void SetMediumDifficulty()
    {
        playerLives = 2;
        playerKeys = 3;
        numberOfEnemies = 5;
        numberOfPowerups = 2;
    }

    public void SetHardDifficulty()
    {
        playerLives = 1;
        playerKeys = 4;
        numberOfEnemies = 10;
        numberOfPowerups = 1;
    }
}
