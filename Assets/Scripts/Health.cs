using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    [SerializeField] int hitPoints = 3;
    bool isDead;

    UIManager deathUI;

    public bool IsDead { get { return isDead; } }

    PlayerSFXPlayer audio;

    private void Awake()
    {
        audio = GetComponent<PlayerSFXPlayer>();
        deathUI = FindObjectOfType<UIManager>();
    }

    public void LoseHealthPoint()
    {
        if (hitPoints <= 0 && !isDead) Die();
        else if (hitPoints > 0) { hitPoints -= 1; audio.PlayHitFX(); }
    }

    void Die()
    {
        audio.PlayDeathSFX();
        audio.PlayBloodSplatterSFX();
        isDead = true;
        Time.timeScale = 0;
        // Display UI Event
        StartCoroutine(deathUI.DisplayDeathUI());
    }
}
