using UnityEngine;

public class SpiritSpawner : MonoBehaviour
{
    public GameObject spirit;
    public int numberOfSpirits = 5;
    public float minX, maxX, minZ, maxZ;
    public float yPosition = 6f;
    public float checkRadius = 1f; // radius untuk mengecek tabrakan
    public LayerMask obstacleLayer; // layer untuk benda-benda yang harus dihindari

    void Start()
    {
        SpawnAllSpirits();
    }

    void SpawnAllSpirits()
    {
        int spawned = 0;
        int maxAttempts = 50; // mencegah infinite loop

        while (spawned < numberOfSpirits && maxAttempts > 0)
        {
            float randomX = Random.Range(minX, maxX);
            float randomZ = Random.Range(minZ, maxZ);
            Vector3 spawnPosition = new Vector3(randomX, yPosition, randomZ);

            // cek apakah posisi ini kosong
            if (!Physics.CheckSphere(spawnPosition, checkRadius, obstacleLayer))
            {
                Instantiate(spirit, spawnPosition, Quaternion.identity);
                spawned++;
            }
            else
            {
                Debug.Log("[SpiritSpawner] Position blocked, retrying...");
            }

            maxAttempts--;
        }

        if (spawned < numberOfSpirits)
        {
            Debug.LogWarning("[SpiritSpawner] Tidak semua spirit berhasil spawn karena area penuh.");
        }
    }
}
