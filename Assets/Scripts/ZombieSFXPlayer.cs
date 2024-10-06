using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ZombieSFXPlayer : MonoBehaviour
{
    [SerializeField] AudioClip zombieGrowlSFX;
    [SerializeField] float growlVolume = 0.12f;
    [SerializeField] AudioClip attackWhooshSFX;
    [SerializeField] float whooshVolume = 0.2f;
    [SerializeField] AudioClip walkSFX;
    [SerializeField] float walkVolume = 1f;

    AudioSource audioSource;
    AIController enemyAgent;

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

    public void PlayZombieSFX()
    {
        audioSource.pitch = UnityEngine.Random.Range(0.90f, 1.10f);
        audioSource.PlayOneShot(zombieGrowlSFX, growlVolume);
    }
    public void PlayAttackSFX()
    {
        audioSource.PlayOneShot(attackWhooshSFX, whooshVolume);
    }
    public void PlayWalkSFX()
    {
        audioSource.pitch = UnityEngine.Random.Range(0.90f, 1.10f);
        audioSource.PlayOneShot(walkSFX, walkVolume);
    }
}
