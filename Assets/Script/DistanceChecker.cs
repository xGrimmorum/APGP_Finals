using UnityEngine;
using TMPro;

public class DistanceTracker : MonoBehaviour
{
    public Transform Player;            
    public TextMeshProUGUI distanceText;  

    private float startY;

    void Start()
    {
        if (Player != null)
            startY = Player.position.y;
    }

    void Update()
    {
        if (Player != null && distanceText != null)
        {
            float distance = startY - Player.position.y;
            distance = Mathf.Max(0, distance); // Clamp to 0+
            distanceText.text = "Distance " + Mathf.FloorToInt(distance) + " m";
        }
    }
}
