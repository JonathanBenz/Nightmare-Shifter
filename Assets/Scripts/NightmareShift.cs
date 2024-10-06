using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class NightmareShift : MonoBehaviour
{
    [SerializeField] TMP_Text promptShiftText;
    [SerializeField] Fader fader;

    private void Start()
    {
        promptShiftText.enabled = false;
    }
    void OscillateOpacity()
    {
        //Normalizes oscillations between 0 and 1 instead of -1 and 1
        float textAlpha = 0.5f * (Mathf.Sin(Time.time - (Mathf.PI / 2)) + 1); 
        promptShiftText.alpha = textAlpha;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            promptShiftText.enabled = true;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            OscillateOpacity();
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                if (SceneManager.GetActiveScene().buildIndex == 1) { StartCoroutine(fader.FadeRoutine(1f, fader.FadeDuration)); promptShiftText.enabled = false; Invoke("LoadNightmare", 1f); }
                else if (SceneManager.GetActiveScene().buildIndex == 2) { StartCoroutine(fader.FadeRoutine(1f, fader.FadeDuration)); promptShiftText.enabled = false; Invoke("LoadMainMenu", 1f); }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
            promptShiftText.enabled = false;
    }
    // This code def has to be refactored in the future. This is spaghetti right here.
    private void LoadNightmare()
    {
        SceneManager.LoadScene(2);
    }
    private void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
