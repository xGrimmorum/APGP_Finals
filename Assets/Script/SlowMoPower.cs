using UnityEngine;
using System.Collections;

public class SlowMoPower : MonoBehaviour
{
    public float duration = 5f;
    public float slowFallSpeed = 2f;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController fred = other.GetComponent<PlayerController>();
            if (fred != null)
            {
                fred.ActivateSlowMo(duration, slowFallSpeed);
            }

            Destroy(gameObject);
        }

        PowerUpUIManager ui = FindFirstObjectByType<PowerUpUIManager>();
        if (ui != null)
        {
            ui.ShowSlowMoTimer(duration);
        }
    }
    IEnumerator SlowDownTime()
    {
        Time.timeScale = 0.5f;

        PowerUpUIManager uiManager = FindFirstObjectByType<PowerUpUIManager>();
        if (uiManager != null)
        {
            uiManager.ShowSlowMoTimer(duration);
        }

        yield return new WaitForSecondsRealtime(duration);
        Time.timeScale = 1f;
    }



}
