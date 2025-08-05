using UnityEngine;
using System.Collections;


public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float fallSpeed = 10f;
    public bool isSmashing = false;

    private Rigidbody rb;
    private GameOver shatterScript;

    public Vector2 xBounds = new Vector2(-5f, 5f);
    public Vector2 zBounds = new Vector2(-5f, 5f);


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;

        shatterScript = GetComponent<GameOver>();
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(moveX, -fallSpeed, moveZ) * moveSpeed;
        rb.linearVelocity = move;
    }
    void LateUpdate()
    {
        Vector3 pos = transform.position;

        pos.x = Mathf.Clamp(pos.x, xBounds.x, xBounds.y);
        pos.z = Mathf.Clamp(pos.z, zBounds.x, zBounds.y);

        transform.position = pos;
    }


    void OnCollisionEnter(Collision collision)
    {
        if (isSmashing)
        {
            Destroy(collision.gameObject);
        }
        else
        {
            Debug.Log("Player Died!.");

            if (shatterScript != null)
            {
                shatterScript.Shatter();
            }

        }
    }
    public void ActivateSlowMo(float duration, float slowFallSpeed)
    {
        StopAllCoroutines(); // prevent overlap
        StartCoroutine(SlowFallRoutine(duration, slowFallSpeed));
    }

    private IEnumerator SlowFallRoutine(float duration, float slowFallSpeed)
    {
        float originalFallSpeed = fallSpeed;
        fallSpeed = slowFallSpeed;

        yield return new WaitForSeconds(duration);

        fallSpeed = originalFallSpeed;
    }

    public void ActivateSmash(float duration)
    {
        StopCoroutine("SmashRoutine"); // Prevent overlap
        StartCoroutine(SmashRoutine(duration));
    }

    private IEnumerator SmashRoutine(float duration)
    {
        isSmashing = true;
        yield return new WaitForSeconds(duration);
        isSmashing = false;
    }

}
