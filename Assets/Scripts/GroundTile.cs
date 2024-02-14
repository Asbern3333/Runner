using UnityEngine;

public class GroundTile : MonoBehaviour {

    GroundSpawner groundSpawner;
    [SerializeField] GameObject coinPrefab;
    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] GameObject shieldTPrefab;
    [SerializeField] GameObject enemyPrefab;

    private void Start () {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
	}

    private void OnTriggerExit (Collider other)
    {
        groundSpawner.SpawnTile(true);
        Destroy(gameObject, 1);
    }

    public void SpawnObstacle ()
    {
        // Choose a random point to spawn the obstacle
        int obstacleSpawnIndex = Random.Range(2, 5);
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;

        // Spawn the obstace at the position
        Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity, transform);
    }
   
    public void SpawnCoins ()
    {
        int coinsToSpawn = 3;
        for (int i = 0; i < coinsToSpawn; i++) {
            GameObject temp = Instantiate(coinPrefab, transform);
            temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
        }
    }

    float[] lanes = new float[] { -3f, 0f, 3f };
    Vector3 GetRandomPointInCollider (Collider collider)
    {
        Vector3 point = new Vector3(
            lanes[Random.Range(0, lanes.Length)], // Choose a random lane
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z)
            );
        if (point != collider.ClosestPoint(point)) {
            point = GetRandomPointInCollider(collider);
        }

        point.y = 1;
        return point;
    }

    public void SpawnShieldToken()
    {
        int shieldSpawnIndex = Random.Range(2, 5);
        Transform spawnPoint = transform.GetChild(shieldSpawnIndex).transform;
        // Spawn the obstace at the position
        Instantiate(shieldTPrefab, spawnPoint.position, Quaternion.identity, transform);
    }

    public void SpawnEnemy()
    {
        int enemySpawnIndex = Random.Range(2, 5);
        Transform spawnPoint = transform.GetChild(enemySpawnIndex).transform;
        // Spawn the obstace at the position
        Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity, transform);
    }
}