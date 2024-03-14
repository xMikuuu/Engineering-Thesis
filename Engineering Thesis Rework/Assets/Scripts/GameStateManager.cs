using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState
{
    public int playerHealth;
    public int aiHealth;
    public bool playerPotion;
    public bool aiPotion;
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
            playerPotion = true,
            aiPotion = true
        };
    }
    public GameState CopyAndModifyState(GameState state)
    {
        GameState copiedState = new GameState()
        {
            playerHealth = state.playerHealth,
            aiHealth = state.aiHealth,
            playerPotion = state.playerPotion,
            aiPotion = state.aiPotion
        };
        return copiedState;
    }
}
