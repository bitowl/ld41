using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BreakScreen : MonoBehaviour {
	private bool breakScreenVisible;
	public GameObject contents;
	public GameState gameState;
	public StringEvent audioEvent;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			breakScreenVisible = !breakScreenVisible;
			UpdateState();
		}
	}

	void UpdateState() {
		audioEvent.Raise("drawer");
					contents.SetActive(breakScreenVisible);
			if (breakScreenVisible) {
				Time.timeScale = 0;
			} else {
				Time.timeScale = 1;
			}
	}

	public void HideBreakScreen() {
		breakScreenVisible = false;
		UpdateState();
	}

	public void QuitGame() {
		Time.timeScale = 1;
		gameState.SetGameState(GameState.State.MENU);
        SceneManager.LoadSceneAsync("MenuScene");
	}
}
