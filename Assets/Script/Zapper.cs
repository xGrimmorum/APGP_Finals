using UnityEngine;

public class Zapper : MonoBehaviour
{
    public LineRenderer line;
    public Transform pointA;
    public Transform pointB;
    public float toggleInterval = 1.5f;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        bool isActive = Mathf.FloorToInt(timer / toggleInterval) % 2 == 0;

        line.enabled = isActive;

        if (isActive)
        {
            line.SetPosition(0, pointA.position);
            line.SetPosition(1, pointB.position);
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (line.enabled && other.CompareTag("Player"))
        {
            Debug.Log("Player zapped!");
            // Game Over or health system
        }
    }

}
