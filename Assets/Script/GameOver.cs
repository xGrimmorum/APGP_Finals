using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject PlayerPiecePrefab;
    public int piecesPerAxis = 3; // 3x3x3 = 27 pieces
    public float explosionForce = 300f;
    public float explosionRadius = 2f;

    public void Shatter()
    {
        Vector3 startPos = transform.position - Vector3.one * 0.5f;

        for (int x = 0; x < piecesPerAxis; x++)
        {
            for (int y = 0; y < piecesPerAxis; y++)
            {
                for (int z = 0; z < piecesPerAxis; z++)
                {
                    Vector3 pos = startPos + new Vector3(x, y, z) * 0.3f;
                    GameObject piece = Instantiate(PlayerPiecePrefab, pos, Random.rotation);
                    Rigidbody rb = piece.GetComponent<Rigidbody>();
                    if (rb != null)
                        rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
                }
            }
        }

        Destroy(gameObject);
    }
}
