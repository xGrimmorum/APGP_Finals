using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public GameObject[] powerupPrefabs; 
    public Transform player;            
    public float spawnInterval = 5f;    
    public float spawnDistanceAhead = 30f;
    public float xRange = 5f;
    public float zRange = 5f;

    private float nextSpawnY;

    void Start()
    {
        if (player != null)
            nextSpawnY = player.position.y - spawnDistanceAhead;
    }

    void Update()
    {
        if (player == null) return;

        if (player.position.y < nextSpawnY)
        {
            SpawnPowerup();
            nextSpawnY -= spawnInterval;
        }
    }

    void SpawnPowerup()
    {
        int index = Random.Range(0, powerupPrefabs.Length);
        GameObject selectedPowerup = powerupPrefabs[index];

        Vector3 spawnPos = new Vector3(
            Random.Range(-xRange, xRange),
            player.position.y - spawnDistanceAhead,
            Random.Range(-zRange, zRange)
        );

        Instantiate(selectedPowerup, spawnPos, Quaternion.identity);
    }
}
