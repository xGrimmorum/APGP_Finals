using UnityEngine;

public class LaserDamage : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (gameObject.activeSelf && other.CompareTag("Player"))
        {
            Debug.Log("Player hit by laser!");
        }
    }
}
