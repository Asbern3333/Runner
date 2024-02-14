using UnityEngine;

public class GroundSpawner : MonoBehaviour {

    [SerializeField] GameObject groundTile;
    Vector3 nextSpawnPoint;

    public void SpawnTile (bool spawnItems)
    {
        GameObject temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;

        if (spawnItems) {
            float spawnChance = Random.value; // generates a random number between 0 and 1
            if(spawnChance < 0.05f) {
                temp.GetComponent<GroundTile>().SpawnEnemy();
            }else if (spawnChance < 0.3f) {
                temp.GetComponent<GroundTile>().SpawnObstacle();
            }else if (spawnChance < 0.7f) {
                temp.GetComponent<GroundTile>().SpawnObstacle();
                temp.GetComponent<GroundTile>().SpawnCoins();
            } else if (spawnChance < 0.95f) {
                temp.GetComponent<GroundTile>().SpawnCoins();
            } else if (spawnChance < 1f){
                temp.GetComponent<GroundTile>().SpawnShieldToken();
            }
        }
    }

    private void Start () {
        for (int i = 0; i < 15; i++) {
            if (i < 3) {
                SpawnTile(false);
            } else {
                SpawnTile(true);
            }
        }
    }
}