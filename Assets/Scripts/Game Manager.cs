using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameManager instance;
    private Transform playerTransform;

    public Transform PlayerTransform { get { return playerTransform; } 
                                       set { playerTransform = value; } }

    // Singleton
    private void Awake()
    {
        if (instance != null && instance != this) Destroy(this);
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
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
}
