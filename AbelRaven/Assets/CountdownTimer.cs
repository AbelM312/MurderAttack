using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour
{
    public float countdownTime = 10f; // Adjust this to set the countdown time in seconds
    public TextMeshProUGUI countdownText;

    private bool isGameOver = false;

    void Start()
    {
        UpdateCountdownText();
    }

    void Update()
    {
        if (!isGameOver)
        {
            // Update the countdown timer
            countdownTime -= Time.deltaTime;

            // Check if the countdown has reached zero
            if (countdownTime <= 0f)
            {
                EndGame();
            }

            UpdateCountdownText();
        }
    }

    void UpdateCountdownText()
    {
        // Update the UI text with the current countdown time
        countdownText.text = "Crows leave in: " + Mathf.Ceil(countdownTime).ToString();
    }

    void EndGame()
    {
        // Perform actions when the game is over (e.g., player wins)
        Debug.Log("Game Over - Player Wins!");
        isGameOver = true;

        // Add any additional actions or scene transitions here
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}