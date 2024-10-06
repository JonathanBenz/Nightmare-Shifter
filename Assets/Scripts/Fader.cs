using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Fader : MonoBehaviour
{
    [SerializeField] float fadeDuration = 5f;
    CanvasGroup canvasGroup;

    public float FadeDuration { get { return fadeDuration; } }

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }
    public IEnumerator FadeAndReset()
    {
        yield return StartCoroutine(FadeRoutine(1f, fadeDuration));
        yield return new WaitForSeconds(0.33f);
        yield return StartCoroutine(FadeRoutine(0f, fadeDuration));
    }
    public IEnumerator FadeRoutine(float target, float time)
    {
        while (!Mathf.Approximately(canvasGroup.alpha, target))
        {
            canvasGroup.alpha = Mathf.MoveTowards(canvasGroup.alpha, target, Time.unscaledDeltaTime / time);
            yield return null;
        }
    }
}
