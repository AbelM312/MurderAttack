using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuScript : MonoBehaviour
{
    [SerializeField] int Number;
    [SerializeField] int Number2;

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
