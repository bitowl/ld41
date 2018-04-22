using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameState gameState;
    private GameState.State displayedState;

	public GameObject winLosePanel;
	public TextMeshProUGUI winLoseText;
	public GameObject menuPanel;
	public GameObject helpPanel;

    void Update()
    {
        if (gameState.GetGameState() != displayedState)
        {
            RenderState(gameState.GetGameState());
        }
    }

    void RenderState(GameState.State state)
    {
		Debug.Log("SHOW STATE: " + state);
        displayedState = state;

		winLosePanel.SetActive(false);
		menuPanel.SetActive(false);
		helpPanel.SetActive(false);

        switch (state)
        {
			case GameState.State.NONE:
				ChangeState(GameState.State.MENU);
				break;
			case GameState.State.WIN:
				winLosePanel.SetActive(true);
				winLoseText.text = "You saved the galaxy!";
				break;
			case GameState.State.LOSE:
				winLosePanel.SetActive(true);
				winLoseText.text = "Mission failed.";
				break;
			case GameState.State.MENU:
				menuPanel.SetActive(true);
				break;
			case GameState.State.HELP:
				helpPanel.SetActive(true);
				break;
			case GameState.State.PLAY:
				SceneManager.LoadSceneAsync("Prototype2");
				break;
			case GameState.State.QUIT:
				Application.Quit();
				break;	
        }
    }

	public void ChangeState(GameState.State state) {
		gameState.SetGameState(state);
	}

	public void ChangeState(string state) {
		ChangeState((GameState.State)System.Enum.Parse(typeof(GameState.State), state, true));
	}
}
