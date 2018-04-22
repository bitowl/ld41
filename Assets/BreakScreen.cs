using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BreakScreen : MonoBehaviour {
	private bool breakScreenVisible;
	public GameObject contents;
	public GameState gameState;
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
		gameState.SetGameState(GameState.State.MENU);
        SceneManager.LoadSceneAsync("MenuScene");
	}
}
