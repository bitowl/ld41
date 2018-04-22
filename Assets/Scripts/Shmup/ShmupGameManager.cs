using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShmupGameManager : MonoBehaviour {
	public WaveEvent createWaveEvent;
	public GameEvent roundWonEvent;
	[ReadOnly] public List<WaveData> waves;

	// Use this for initialization
	void Start () {
	}

	void SpawnNextWave() {
		if (waves.Count > 0) {
			WaveData wave = waves[0];
			WaveEventData data = ScriptableObject.CreateInstance<WaveEventData>();
			data.wave = wave;
			createWaveEvent.Raise(data);
			waves.RemoveAt(0);
		} else {
			roundWonEvent.Raise();
		}
	}

	public void OnPreviousWaveDied(WaveEventData data) {
		SpawnNextWave();
	}

	public void OnRoundStart(WaveDataListEventData data) {
		waves = data.waves;
		SpawnNextWave();
	}
	
}
