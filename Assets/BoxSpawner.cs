using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject[] prefabs;

    [Header("Spawn Settings")]
    public float spawnInterval = 2.0f;      // Intervalo inicial
    public float minSpawnInterval = 0.5f;   // Intervalo mínimo
    public float speedUpRate = 0.1f;         // Quanto acelera
    public float timeToSpeedUp = 10f;        // A cada quantos segundos acelera

    private float spawnTimer;
    private float speedTimer;

    void Update()
    {
        // Timer de spawn
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnInterval)
        {
            SpawnBox();
            spawnTimer = 0f;
        }

        // Timer de aceleração
        speedTimer += Time.deltaTime;

        if (speedTimer >= timeToSpeedUp)
        {
            AumentarVelocidade();
            speedTimer = 0f;
        }
    }

    void SpawnBox()
    {
        int index = Random.Range(0, prefabs.Length);
        Instantiate(prefabs[index], transform.position, transform.rotation);
    }

    void AumentarVelocidade()
    {
        spawnInterval -= speedUpRate;

        if (spawnInterval < minSpawnInterval)
        {
            spawnInterval = minSpawnInterval;
        }
    }
}
