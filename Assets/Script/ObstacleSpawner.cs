using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public float spawnDistance = 20f;
    public float interval = 5f;
    private float lastSpawnY;

    void Start() => lastSpawnY = 0f;

    void Update()
    {
        float playerY = GameObject.FindWithTag("Player").transform.position.y;

        if (playerY < lastSpawnY - interval)
        {
            SpawnObstacle(playerY - spawnDistance);
            lastSpawnY = playerY;
        }
    }

    void SpawnObstacle(float yPos)
    {
        int index = Random.Range(0, obstaclePrefabs.Length);
        Vector3 position = new Vector3(Random.Range(-3f, 3f), yPos, 0);
        Instantiate(obstaclePrefabs[index], position, Quaternion.identity);

    }
}

