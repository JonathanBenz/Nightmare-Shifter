using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] Canvas deathScreen;
    Fader fader;
    private void Awake()
    {
        fader = deathScreen.GetComponent<Fader>();
    }
    private void Start()
    {
        deathScreen.enabled = false;
    }

    public IEnumerator DisplayDeathUI()
    {
        deathScreen.enabled = true;
        yield return fader.FadeRoutine(1f, fader.FadeDuration);
    }
}
