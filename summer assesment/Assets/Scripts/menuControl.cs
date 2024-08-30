using UnityEngine;
using UnityEngine.SceneManagement;

public class menuControl : MonoBehaviour
{
    public AudioSource buttonClickSound;  

    public void PlaySound()
    {
        if (buttonClickSound != null)
        {
            buttonClickSound.Play(); 
        }
    }
        public void StartGame()
        
        {
            PlaySound();
            SceneManager.LoadScene("game1"); 
        }

        public void OpenLevels()
        {
            PlaySound();
            SceneManager.LoadScene("levels"); 
        }
        public void OpenLevelOne()
                {
                    PlaySound();
                    SceneManager.LoadScene("game1"); 
                }
        public void OpenLevelTwo()
        {
            PlaySound();
            SceneManager.LoadScene("Game2"); 
        }
        public void OpenLevelThree()
        {
            PlaySound();
            SceneManager.LoadScene("Game3"); 
        }
    public void OpenMenu()
        {
            PlaySound();
            SceneManager.LoadScene("intro"); 
        }
       
        public void QuitGame()
        {
            PlaySound();
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #else
            Application.Quit();
            #endif
        }
 }
