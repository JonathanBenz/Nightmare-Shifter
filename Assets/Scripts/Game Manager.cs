using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameManager instance;

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
}
