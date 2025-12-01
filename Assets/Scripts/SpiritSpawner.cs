using UnityEngine;

public class SpiritSpawner : MonoBehaviour
{
    public GameObject spirit;
    public int numberOfSpirits = 5;
    public float minx, maxX, minZ, maxZ;
    public float yPosition = 6f;

    void Start()
    {
        SpawnAllSpirits();
    }

    void SpawnAllSpirits()
    {
        for (int i = 0; i < numberOfSpirits; i++)
        {
            float randomX = Random.Range(minx, maxX);
            float randomZ = Random.Range(minZ, maxZ);
            Vector3 spawnPosition = new Vector3(randomX, yPosition, randomZ);
            Instantiate(spirit, spawnPosition, Quaternion.identity);
        }
    }
}
