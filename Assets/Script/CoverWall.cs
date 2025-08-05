using UnityEngine;

public class CoverWall : MonoBehaviour
{
    public BoxCollider holeCollider;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player hit the wall! Game Over.");
        }
    }
}
