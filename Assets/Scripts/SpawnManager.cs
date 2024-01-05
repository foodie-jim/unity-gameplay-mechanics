using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enermyPrefab;
    public GameObject powerupPrefab;
    public int enemyCount;
    public int waveNumber = 1;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(this.waveNumber);
        Instantiate(this.powerupPrefab, this.GenerateSpawnPosition(), this.powerupPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        this.enemyCount = FindObjectsOfType<Enemy>().Length;
        if (this.enemyCount == 0) {
            this.waveNumber++;
            this.SpawnEnemyWave(this.waveNumber);
            Instantiate(this.powerupPrefab, this.GenerateSpawnPosition(), this.powerupPrefab.transform.rotation);
        }
    }

    private void SpawnEnemyWave(int enemiesToSpawn) {

        for (int i=0; i<enemiesToSpawn; i++) {

            Instantiate(this.enermyPrefab, this.GenerateSpawnPosition(), this.enermyPrefab.transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPosition () {
        float spawnPosX = Random.Range(-9, 9);
        float spawnPosZ = Random.Range(-9, 9);
        return new Vector3(spawnPosX, 0, spawnPosZ);
    }
}
