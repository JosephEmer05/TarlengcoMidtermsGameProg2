using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform player;
    public float enemySpeed = 1f;
    public float initialSpawnInterval = 2f;
    public float spawnIntervalDecreaseRate = 0.1f;
    public float minimumSpawnInterval = 0.5f;
    public float spawnRadius = 10f;
    private float spawnTimer = 0f;
    private float currentSpawnInterval;
    private Color[] colors = { Color.red, Color.green, Color.blue, Color.magenta };
    
    void Start()
    {
        currentSpawnInterval = initialSpawnInterval;
    }

    void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= currentSpawnInterval)
        {
            SpawnEnemy();
            spawnTimer = 0f; 

            if (currentSpawnInterval > minimumSpawnInterval)
            {
                currentSpawnInterval -= spawnIntervalDecreaseRate * Time.deltaTime;
            }
        }
    }

    void SpawnEnemy()
    {
        Vector2 spawnPosition = (Vector2)player.position + Random.insideUnitCircle.normalized * spawnRadius;

        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

        SpriteRenderer enemyRenderer = enemy.GetComponent<SpriteRenderer>();
        if (enemyRenderer != null)
        {
            enemyRenderer.color = colors[Random.Range(0, colors.Length)];
        }

        enemy.AddComponent<MoveTowardsPlayer>().Initialize(player, enemySpeed);
    }
}
