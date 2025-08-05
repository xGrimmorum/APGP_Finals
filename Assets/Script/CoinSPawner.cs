using UnityEngine;

public class CoinSPawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public Transform Player;
    public float spawnInterval = 1.5f;
    public float verticalSpacing = 10f;
    public float horizontalRange = 3f;

    private float lastY;

    void Start()
    {
        lastY = Player.position.y;
    }

    void Update()
    {
        if (Player.position.y < lastY - verticalSpacing)
        {
            SpawnCoin();
            lastY = Player.position.y;
        }
    }

    void SpawnCoin()
    {
        float offsetX = Random.Range(-horizontalRange, horizontalRange);
        float offsetZ = Random.Range(-horizontalRange, horizontalRange);

        Vector3 spawnPos = new Vector3(
            Player.position.x + offsetX,
            Player.position.y - 20f, // Ahead of Player
            Player.position.z + offsetZ
        );

        Instantiate(coinPrefab, spawnPos, Quaternion.identity);
    }
}
