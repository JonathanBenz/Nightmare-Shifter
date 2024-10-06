using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int hitPoints = 3;
    bool isDead;

    public bool IsDead { get { return isDead; } }

    PlayerSFXPlayer audio;

    private void Awake()
    {
        audio = GetComponent<PlayerSFXPlayer>();
    }

    public void LoseHealthPoint()
    {
        if (hitPoints <= 0 && !isDead) Die();
        else if (hitPoints > 0) { hitPoints -= 1; audio.PlayHitFX(); }
    }

    void Die()
    {
        // TODO: Death UI
        audio.PlayDeathSFX();
        audio.PlayBloodSplatterSFX();
        isDead = true;
        Time.timeScale = 0;
    }
}
