using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Custom/GameState")]
public class GameState : ScriptableObject
{
    public enum State
    {
        NONE,
        MENU,
        HELP,
        PLAY,
        WIN,
        LOSE,
        QUIT
    };

    public State gameState = State.MENU;
    public void SetGameState(State state)
    {
        gameState = state;
    }
    public State GetGameState()
    {
        return gameState;
    }

}
