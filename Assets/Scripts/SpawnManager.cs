using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private float sideBound = 10f;
    private float spawnPosZ = 18f;

    private float startDelay = 1f;
    private float spawnInterval = 1.5f;

    public GameObject enemyPrefab;


    public void ActivateSpawning()
    {
        InvokeRepeating("SpawnEnemy", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void SpawnEnemy()
    {
        float randomPositionX = Random.Range(-sideBound, sideBound);
        Instantiate(enemyPrefab, new Vector3(randomPositionX, 1, spawnPosZ), enemyPrefab.transform.rotation);
    }
}
