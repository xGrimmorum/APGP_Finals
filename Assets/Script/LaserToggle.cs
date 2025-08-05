using UnityEngine;

public class LaserToggle : MonoBehaviour
{
    public GameObject laserBeam;
    public Renderer warningRenderer;  // New: reference to a warning material or object
    public float warningDuration = 1f;
    public float laserDuration = 1.5f;
    public float cooldownDuration = 2f;

    private enum LaserState { Idle, Warning, Firing }
    private LaserState currentState = LaserState.Idle;
    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        switch (currentState)
        {
            case LaserState.Idle:
                if (timer >= cooldownDuration)
                {
                    timer = 0f;
                    EnterWarningState();
                }
                break;

            case LaserState.Warning:
                if (timer >= warningDuration)
                {
                    timer = 0f;
                    EnterFiringState();
                }
                break;

            case LaserState.Firing:
                if (timer >= laserDuration)
                {
                    timer = 0f;
                    EnterIdleState();
                }
                break;
        }
    }

    void EnterWarningState()
    {
        currentState = LaserState.Warning;
        if (warningRenderer != null)
            warningRenderer.material.EnableKeyword("_EMISSION");
        laserBeam.SetActive(false);
    }

    void EnterFiringState()
    {
        currentState = LaserState.Firing;
        if (warningRenderer != null)
            warningRenderer.material.DisableKeyword("_EMISSION");
        laserBeam.SetActive(true);
    }

    void EnterIdleState()
    {
        currentState = LaserState.Idle;
        if (warningRenderer != null)
            warningRenderer.material.DisableKeyword("_EMISSION");
        laserBeam.SetActive(false);
    }
}
