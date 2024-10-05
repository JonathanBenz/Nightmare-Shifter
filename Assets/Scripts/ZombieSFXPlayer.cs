using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSFXPlayer : MonoBehaviour
{
    private bool playedSound;

    AudioSource audioSource;

    public bool PlayedSound { get { return playedSound; } }
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayZombieSFX()
    {
        audioSource.pitch = UnityEngine.Random.Range(0.95f, 1.10f);
        audioSource.Play();
        playedSound = true;
    }
}
