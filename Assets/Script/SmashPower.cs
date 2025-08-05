using UnityEngine;

public class SmashPower : MonoBehaviour
{
    public float duration = 5f;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                // Call method on Player to handle smash logic
                player.ActivateSmash(duration);

                // Trigger UI
                PowerUpUIManager ui = FindFirstObjectByType<PowerUpUIManager>();
                if (ui != null)
                {
                    ui.ShowSmashTimer(duration);
                }

                // Destroy the power-up
                Destroy(gameObject);
            }
        }
    }
}
