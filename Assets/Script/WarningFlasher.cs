using UnityEngine;

public class WarningFlasher : MonoBehaviour
{
    public Renderer rend;
    public Color flashColor = Color.yellow;
    private Color originalColor;
    private float flashSpeed = 6f;

    void Start()
    {
        originalColor = rend.material.color;
    }

    void Update()
    {
        float t = Mathf.PingPong(Time.time * flashSpeed, 1f);
        rend.material.color = Color.Lerp(originalColor, flashColor, t);
    }
}
