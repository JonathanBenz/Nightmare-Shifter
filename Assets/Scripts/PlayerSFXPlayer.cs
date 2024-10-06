using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSFXPlayer : MonoBehaviour
{
    [SerializeField] AudioClip footSteps;
    [SerializeField] float footStepVolume = 0.1f;

    [SerializeField] AudioClip hitSound;
    [SerializeField] float hitVolume = 1f;

    [SerializeField] AudioClip deathSound;
    [SerializeField] float deathVolume = 1f;

    [SerializeField] AudioClip bloodSplatter;
    [SerializeField] float splatterVolume = 1f;

    AudioSource audioSource;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayFootStepsSFX()
    {
        audioSource.pitch = UnityEngine.Random.Range(0.90f, 1.10f);
        audioSource.PlayOneShot(footSteps, footStepVolume);
    }
    public void PlayHitFX()
    {
        audioSource.pitch = UnityEngine.Random.Range(0.90f, 1.10f);
        audioSource.PlayOneShot(hitSound, hitVolume);
    }
    public void PlayDeathSFX()
    {
        audioSource.pitch = UnityEngine.Random.Range(0.90f, 1.10f);
        audioSource.PlayOneShot(deathSound, deathVolume);
    }
    public void PlayBloodSplatterSFX()
    {
        audioSource.pitch = UnityEngine.Random.Range(0.90f, 1.10f);
        audioSource.PlayOneShot(bloodSplatter, splatterVolume);
    }
}
