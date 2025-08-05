using UnityEngine;

public class Barrier : MonoBehaviour
{
    public Transform Player;

    void Update()
    {
        if (Player != null)
        {
            Vector3 newPos = transform.position;
            newPos.y = Player.position.y; // Follow Player only on Y-axis
            transform.position = newPos;
        }
    }
}
