using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
   
    public static GameManager instance;

   
    public int playerLives = 3;
    public int playerKeys = 0;
    public int numberOfEnemies;
    public int numberOfPowerups;
    public Vector2[] enemyPositions;
    public GameObject enemyPrefab;

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
    void start(){
     if (DifficultyManager.instance != null)
        {
            playerLives = DifficultyManager.instance.playerLives;
            playerKeys = DifficultyManager.instance.playerKeys;
            numberOfEnemies = DifficultyManager.instance.numberOfEnemies;
            numberOfPowerups = DifficultyManager.instance.numberOfPowerups;

            
            InitializeEnemyPositions();

            
            SpawnEnemies();
        }
        
    }   

      public void AddLife()
    {
        playerLives++;
        
    }

    public void RemoveLife()
    {
        if (playerLives > 0)
        {
            playerLives--;
           

            if (playerLives == 0)
            {
                 SceneManager.LoadScene("gameOver2");
            }
        }
    }

    public int showlife()
    {
        return playerLives;
    }

    
    public void AddKey()
    {
        playerKeys++;
    
    }

    
    public void RemoveKey()
    {
        if (playerKeys > 0)
        {
            playerKeys--;
            
        }
    }

   
    

    void InitializeEnemyPositions()
    {
        enemyPositions = new Vector2[]
        {
            new Vector2(10, 0),
            new Vector2(12, 2),
            new Vector2(20, 0),
            new Vector2(22, 2),
            new Vector2(24, 0),
            new Vector2(26, 2),
            new Vector2(28, 0),
            new Vector2(30, 2),
            new Vector2(32, 0),
            new Vector2(34, 2)
        };
    }

     void SpawnEnemies()
    {
        for (int i = 0; i< numberOfEnemies && i< enemyPositions.Length; i++)
        {
            Instantiate(enemyPrefab, new Vector3(enemyPositions[i].x, enemyPositions[i].y, 0), Quaternion.identity);
        }
    }
}

