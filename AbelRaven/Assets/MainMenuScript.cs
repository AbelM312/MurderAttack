using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuScript : MonoBehaviour
{
    [SerializeField] int Number;
    [SerializeField] int Number2;

    private PlayerAttack playerAttack;

    public string targetSceneName; // The name of the scene to switch to
    //private bool conditionMet = false; // Example condition

    private void Start()
    {
        
        playerAttack = GameObject.Find("Player").GetComponent<PlayerAttack>();

    }

    void Update()
    {
        // Check if the condition is met
        if (playerAttack.numberOfCrows <= 0)
        {
            // Call the method to switch scenes
            SwitchScene();
        }
    }

    public void SwitchScene()
    {
        // Load the target scene
        SceneManager.LoadScene(targetSceneName);
    }

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(Number);
    }

    public void PlayGame2()
    {
        SceneManager.LoadSceneAsync(Number2);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
