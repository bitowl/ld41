using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

[CustomEditor(typeof(WaveSpawner))]
public class WaveSpawnerEditor : Editor {
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (Application.isEditor && GUILayout.Button("Serialize Wave to Scriptable Object")) {
            SerializeWave();
        }

        if (GUILayout.Button("Create Wave from Scriptable Object")) {
            WaveSpawner spawner = target as WaveSpawner;
            DeleteEnemies(spawner);
            spawner.SpawnWave();
        }
    }

	void DeleteEnemies(WaveSpawner spawner) {
		foreach (Enemy enemy in spawner.transform.GetComponentsInChildren<Enemy>()) {
			DestroyImmediate(enemy.gameObject);
		}
	}

    void SerializeWave() {
        WaveSpawner spawner = target as WaveSpawner;
        WaveData wave = spawner.currentWave;
        wave.enemies = new List<EnemyData>();
        foreach (Enemy enemy in spawner.transform.GetComponentsInChildren<Enemy>()) {
            EnemyData data = new EnemyData();
            data.position = enemy.transform.localPosition;
            data.type = enemy.type;
            wave.enemies.Add(data);
        }
        EditorUtility.SetDirty(wave);
    }
}