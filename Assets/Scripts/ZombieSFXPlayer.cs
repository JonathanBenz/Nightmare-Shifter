using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ZombieSFXPlayer : MonoBehaviour
{
    //private bool playedSound;
    //private float timer;

    AudioSource audioSource;
    AIController enemyAgent;

    //public bool PlayedSound { get { return playedSound; } }
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
        /*if (playedSound)
        {
            ResetSoundTrigger();
        }*/
    }

    public void PlayZombieSFX()
    {
        audioSource.pitch = UnityEngine.Random.Range(0.90f, 1.10f);
        audioSource.PlayOneShot(audioSource.clip);
        //playedSound = true;
    }
    /*private void ResetSoundTrigger()
    {
        timer += Time.deltaTime;
        if(timer > UnityEngine.Random.Range(10f, 16f))
        {
            playedSound = false;
            timer = 0f;
        }
    }*/
}
