using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemySpawner : MonoBehaviour {

	public Transform[] spawnPoints;
	public float minSpawnInterval = 0.1f;
	public float maxSpawnInterval = 1;
	public GameObject enemyPrefab;

	private float spawnTimer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		spawnTimer -= Time.deltaTime;

		if (spawnTimer <= 0) {
			SpawnEnemy(spawnPoints[Random.Range(0, spawnPoints.Length)]);
			spawnTimer = Random.Range(minSpawnInterval, maxSpawnInterval);
		}
	}

	void SpawnEnemy(Transform spawnPoint) {
		GameObject enemy = Instantiate(enemyPrefab, spawnPoint.localPosition, spawnPoint.rotation);
		enemy.transform.SetParent(transform, false);
	}
}
