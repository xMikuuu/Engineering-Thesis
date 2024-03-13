using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState
{
    public int playerHealth;
    public int aiHealth;
}
public class GameStateManager : MonoBehaviour
{
    public GameState currentState;

    private void Start()
    {
        currentState = new GameState()
        {
            playerHealth = 100,
            aiHealth = 100,
        };
    }
    public GameState CopyAndModifyState()
    {
        GameState copiedState = new GameState()
        {
            playerHealth = currentState.playerHealth,
            aiHealth = currentState.aiHealth,
        };
        return copiedState;
    }
}
