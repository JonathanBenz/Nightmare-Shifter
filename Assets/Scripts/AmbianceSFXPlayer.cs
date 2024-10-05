using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AmbianceSFXPlayer : MonoBehaviour
{
    [SerializeField] AudioClip windAmbiance;
    [SerializeField] float windVolume = 0.2f;
    [SerializeField] AudioClip nightmareAmbiance;
    [SerializeField] float nightmareVolume = 0.2f;

    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        // If regular scene
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            audioSource.clip = windAmbiance;
            audioSource.volume = windVolume;
            audioSource.Play();
        }
        // If nightmare scene
        else if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            audioSource.clip = nightmareAmbiance;
            audioSource.volume = nightmareVolume;
            audioSource.Play();
        }
    }
}
