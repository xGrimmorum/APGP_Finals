using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class PowerUpUIManager : MonoBehaviour
{
    public TextMeshProUGUI smashText;
    public Slider smashSlider;

    public TextMeshProUGUI slowMoText;
    public Slider slowMoSlider;

    public void ShowSmashTimer(float duration)
    {
        StopCoroutine(nameof(SmashCountdown));
        StartCoroutine(SmashCountdown(duration));
    }

    IEnumerator SmashCountdown(float duration)
    {
        if (smashText) smashText.gameObject.SetActive(true);
        if (smashSlider)
        {
            smashSlider.maxValue = duration;
            smashSlider.value = duration;
            smashSlider.gameObject.SetActive(true);
        }

        float timeLeft = duration;
        while (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            if (smashText) smashText.text = "Smash: " + Mathf.CeilToInt(timeLeft) + "s";
            if (smashSlider) smashSlider.value = timeLeft;
            yield return null;
        }

        if (smashText) smashText.gameObject.SetActive(false);
        if (smashSlider) smashSlider.gameObject.SetActive(false);
    }

    public void ShowSlowMoTimer(float duration)
    {
        StopCoroutine(nameof(SlowMoCountdown));
        StartCoroutine(SlowMoCountdown(duration));
    }

    IEnumerator SlowMoCountdown(float duration)
    {
        if (slowMoText) slowMoText.gameObject.SetActive(true);
        if (slowMoSlider)
        {
            slowMoSlider.maxValue = duration;
            slowMoSlider.value = duration;
            slowMoSlider.gameObject.SetActive(true);
        }

        float timeLeft = duration;
        while (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            if (slowMoText) slowMoText.text = "Slow-mo: " + Mathf.CeilToInt(timeLeft) + "s";
            if (slowMoSlider) slowMoSlider.value = timeLeft;
            yield return null;
        }

        if (slowMoText) slowMoText.gameObject.SetActive(false);
        if (slowMoSlider) slowMoSlider.gameObject.SetActive(false);
    }
}
