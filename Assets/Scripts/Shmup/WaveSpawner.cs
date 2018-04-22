using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {
	public WaveData currentWave;
	public GameObject[] enemyPrefabs;
	public WaveEvent waveDestroyedEvent;
	private Wave wave;

	// Use this for initialization
	void Start () {
		SpawnWave();
	}

	void Update() {
		Debug.Log("Wave dead: " + wave.IsDead() + " " + wave.enemies.Count);
	}
	
	public void SpawnWave() {
		wave = new Wave();
		wave.enemies = new List<Enemy>();
		foreach (EnemyData data in currentWave.enemies) {
			Enemy enemy = Instantiate(enemyPrefabs[data.type], data.position, Quaternion.identity).GetComponent<Enemy>();
			enemy.transform.SetParent(transform, false);
			wave.enemies.Add(enemy);
		}
	}

	public void OnEnemyDestroyed(EnemyEventData data) {
		wave.enemies.Remove(data.enemy);
		if (wave.IsDead()) {
			WaveEventData evt = ScriptableObject.CreateInstance<WaveEventData>();
			evt.wave = currentWave;
			waveDestroyedEvent.Raise(evt);
		}
	}

	public void DoSpawnWave(WaveEventData data) {
		currentWave = data.wave;
		SpawnWave();
	}
}
