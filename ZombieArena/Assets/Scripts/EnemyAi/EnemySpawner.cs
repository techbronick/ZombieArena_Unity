using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyObject;
    public Transform[] spawnPoints;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SpawnEnemies();
        }
    }

    void SpawnEnemies()
    {
        foreach (var sp in spawnPoints)
        {
            Instantiate(enemyObject, sp.position, sp.rotation);
            this.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
