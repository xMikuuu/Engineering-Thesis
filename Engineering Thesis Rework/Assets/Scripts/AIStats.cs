using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections.LowLevel.Unsafe;
using UnityEditor;
using UnityEngine;

public class AIStats : MonoBehaviour, IDamageable
{
    [SerializeField] public Attacks attacks;
    [SerializeField] GameStateManager gameStateManager;
    GameObject player;

    GameState gameState;


    private void Start()
    {
        player = GameObjects.Instance.PlayerObject;
    }



    private void Update()
    {
        if (!attacks.turnflag && !attacks.endgame)
        {
            gameState = gameStateManager.CopyAndModifyState();

            Debug.Log(gameState.aiHealth);

            attacks.listOfActions[0].ExecuteAction(player, gameState);
            Debug.Log("Virtual Player Health:" + gameState.playerHealth);
            attacks.listOfActions[1].ExecuteAction(player, gameState);
            Debug.Log("Virtual Player Health:" + gameState.playerHealth);
            attacks.listOfActions[2].ExecuteAction(player, gameState);
            Debug.Log("Virtual Player Health:" + gameState.playerHealth);
            Debug.Log(gameState.aiHealth);
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
