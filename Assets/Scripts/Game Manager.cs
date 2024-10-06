using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private GameManager instance;
    [SerializeField] GameObject credits;

    // Singleton
    private void Awake()
    {
        if (instance != null && instance != this) Destroy(this);
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        if(credits != null) credits.SetActive(false);
    }
    public void Load(int index)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(index);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void ToggleCredits()
    {
        if(credits.activeInHierarchy) credits.SetActive(false);
        else credits.SetActive(true);
    }
}
