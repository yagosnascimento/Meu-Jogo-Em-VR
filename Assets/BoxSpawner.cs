using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    public GameObject boxPrefab; // Arraste seu Prefab de caixa aqui no Inspector
    public float spawnInterval = 2.0f; // Tempo entre cada caixa (segundos)
    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnBox();
            timer = 0;
        }
    }

    void SpawnBox()
    {
        // Cria a caixa exatamente na posição deste objeto Spawner
        Instantiate(boxPrefab, transform.position, transform.rotation);
    }
}