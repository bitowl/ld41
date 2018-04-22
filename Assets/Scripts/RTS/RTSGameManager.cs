using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RTSGameManager : MonoBehaviour {
	[ReadOnly] public List<Fleet> fleets;
	[ReadOnly] public Fleet playerFleet;
	public List<WaveData> waveDataPresets;
	public WaveDataListEvent roundStartEvent;
	public GameState gameState;

	private int wavesLeft;
	private int waveCountThisRound;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
		// Handle Non-Player fleets
		foreach(Fleet fleet in fleets) {
			if (fleet.playerInFleet || fleet.minTravelTime == 0) {
				continue;
			}
			fleet.progress += Random.Range(0, Time.deltaTime / fleet.minTravelTime);
		}

	}

	public void OnRoundWon() {
		playerFleet = null;
	}

	public void OnFleetDestroyed(FleetEventData data) {
		fleets.Remove(data.fleet);
	}

	public void OnWaveDestroyed(WaveEventData data) {
		wavesLeft--;
		if (playerFleet != null) {
			playerFleet.progress = 1 - ((float)wavesLeft/waveCountThisRound);
		}
	}

	public void StartRound(float distance) {
		int min = Mathf.FloorToInt(Mathf.Max(distance/8, 1));
		int max = Mathf.FloorToInt(Mathf.Max(distance/4, 1));
		waveCountThisRound = Random.Range(min, max); // TODO choose depending on difficulty
		Debug.Log("Use rounds: " + waveCountThisRound + ", " + min + "<" + max);
		wavesLeft = waveCountThisRound;
		WaveDataListEventData data = ScriptableObject.CreateInstance<WaveDataListEventData>();
		data.waves = new List<WaveData>();
		for (int i = 0; i < waveCountThisRound; i++) {
			data.waves.Add(waveDataPresets[Random.Range(0, waveDataPresets.Count)]); // TODO: don't contain the same twice?
		}
		roundStartEvent.Raise(data);
		
	}

	public void OnGameWon() {
		gameState.SetGameState(GameState.State.WIN);
		SceneManager.LoadSceneAsync("WinScene");
	}

	public void OnGameLost() {
		gameState.SetGameState(GameState.State.LOSE);
		SceneManager.LoadSceneAsync("WinScene");
	}
}
