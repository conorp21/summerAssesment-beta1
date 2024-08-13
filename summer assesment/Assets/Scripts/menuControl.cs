using UnityEngine;
using UnityEngine.SceneManagement;

public class menuControl : MonoBehaviour
{
        public void StartGame()
        {
            SceneManager.LoadScene("game1"); 
        }

        public void OpenLevels()
        {
            SceneManager.LoadScene("levels"); 
        }
        public void OpenLevelOne()
                {
                    SceneManager.LoadScene("game1"); 
                }
        public void OpenLevelTwo()
        {
            SceneManager.LoadScene("Game2"); 
        }
        public void OpenLevelThree()
        {
            SceneManager.LoadScene("Game3"); 
        }
    public void OpenMenu()
        {
            SceneManager.LoadScene("intro"); 
        }
       
        public void QuitGame()
        {
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #else
            Application.Quit();
            #endif
        }
 }
