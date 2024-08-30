using UnityEngine;
using TMPro;  // Import the TextMeshPro namespace

public class GameTimer : MonoBehaviour
{
    public float timeRemaining = 60f;  // Set the starting time (in seconds)
    public bool timerIsRunning = false;  // Whether the timer is currently running
    public TextMeshProUGUI timeText;  // Reference to the TextMeshProUGUI element

    void Start()
    {
        // Start the timer
        timerIsRunning = true;
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;  // Decrease the timer
                UpdateTimerDisplay(timeRemaining);  // Update the UI display
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;  // Stop the timer
                // You can trigger an event here, like ending the game
            }
        }
    }

    void UpdateTimerDisplay(float timeToDisplay)
    {
        timeToDisplay += 1;  // Add 1 to display time in full seconds
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);  // Calculate minutes
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);  // Calculate seconds
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);  // Format and display
    }
}
