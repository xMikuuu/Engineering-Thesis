using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections.LowLevel.Unsafe;
using UnityEditor;
using UnityEngine;

public class AIStats : MonoBehaviour, IDamageable
{
    private Attacks attacks;
    private GameStateManager gameStateManager;
    private GameObject player;
    private GameState gameState;
    [SerializeField] private Minimax minimax;
    [SerializeField] private int h; // how many moves in future should algorithm check
    private MinimaxResult result;

    private void Start()
    {
        gameStateManager = GameObjects.Instance.StateManager;
        attacks = GameObjects.Instance.Attacks;
        player = GameObjects.Instance.PlayerObject;
    }



    private void Update()
    {
        if (!attacks.turnflag && !attacks.endgame)
        {
            gameState = gameStateManager.CopyAndModifyState();

            Debug.Log("Wybrany ruch: "+ minimax.MinimaxFunction(0, 0, true, h, gameState, gameState.aiHealth-gameState.playerHealth));
            //attacks.listOfActions[minimax.MinimaxFunction(0, 0, true, h, gameState)].ExecuteAction(player, gameStateManager.currentState);
            //result = minimax.MinimaxFunction(0, 0, true, h, gameState);
            //Debug.Log(result.bestActionIndex);

            //Debug.Log(gameState.aiHealth);

            //attacks.listOfActions[0].ExecuteAction(player, gameState);
            //Debug.Log("Virtual Player Health:" + gameState.playerHealth);
            //attacks.listOfActions[1].ExecuteAction(player, gameState);
            //Debug.Log("Virtual Player Health:" + gameState.playerHealth);
            //attacks.listOfActions[2].ExecuteAction(player, gameState);
            //Debug.Log("Virtual Player Health:" + gameState.playerHealth);
            //Debug.Log(gameState.aiHealth);
            attacks.ChangeTurn();
        }
    }

    public void Damage(int damage, GameState state)
    {
        if (state.aiHealth - damage <= 0)
        {
            state.aiHealth = 0;
            attacks.EndGame(this.gameObject, state);
        }
        else
        {
            state.aiHealth -= damage;
        }
    }
}
