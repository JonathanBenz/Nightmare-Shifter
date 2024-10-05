using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ZombieSFXPlayer : MonoBehaviour
{
    private bool playedSound;

    AudioSource audioSource;
    AIController enemyAgent;

    public bool PlayedSound { get { return playedSound; } }
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        enemyAgent = GetComponent<AIController>();
    }

    private void OnEnable()
    {
        enemyAgent.ZombieGroan += PlayZombieSFX;
    }

    private void OnDisable()
    {
        enemyAgent.ZombieGroan -= PlayZombieSFX;
    }

    private void Update()
    {
        if (playedSound)
        {
            Invoke("ResetSoundTrigger", UnityEngine.Random.Range(6f, 10f));
        }
    }

    public void PlayZombieSFX()
    {
        audioSource.pitch = UnityEngine.Random.Range(0.95f, 1.10f);
        audioSource.Play();
        playedSound = true;
    }
    private void ResetSoundTrigger()
    {
        playedSound = false;
    }
}
