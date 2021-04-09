using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public Transform[] spawnPoints;
	public GameObject[] enemyPrefabs;
    int randomSpawn, randomEnemy;
    public static bool spawnAllowed;

	// Use this for initialization
	void Start () 
	{
		spawnAllowed = true;
        InvokeRepeating("SpawnAEnemy", 0f, 15f);
	}

	void SpawnAEnemy()
	{
		if (spawnAllowed) {
			randomEnemy = Random.Range(0, enemyPrefabs.Length);
			randomSpawn = Random.Range(0, spawnPoints.Length);

			Instantiate(enemyPrefabs[randomEnemy], spawnPoints[randomSpawn].position, Quaternion.identity);
		}
	}
}
