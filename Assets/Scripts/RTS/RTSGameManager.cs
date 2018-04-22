using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTSGameManager : MonoBehaviour {
	[ReadOnly] public List<Fleet> fleets;
	[ReadOnly] public Fleet playerFleet;

	private int wavesLeft;
	private int waveCountThisRound;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
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

	public void StartRound() {
		waveCountThisRound = 3;
		wavesLeft = 3;
	}
}
