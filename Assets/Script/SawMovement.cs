using UnityEngine;

public class SawMovement : MonoBehaviour
{
    public float speed = 2f;
    public float range = 3f;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float offset = Mathf.Sin(Time.time * speed) * range;
        transform.position = startPos + new Vector3(offset, 0, 0); // X-axis movement
    }
}
