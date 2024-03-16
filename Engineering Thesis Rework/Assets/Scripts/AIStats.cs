using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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
    private int actionNumber;
    private string path;
    private void Start()
    {
        gameStateManager = GameObjects.Instance.StateManager;
        attacks = GameObjects.Instance.Attacks;
        player = GameObjects.Instance.PlayerObject;
        path = minimax.path; // œcie¿ka do logów
    }



    private void Update()
    {

        if (!attacks.turnflag && !attacks.endgame)
        {
            File.WriteAllText(Path.Combine(path, "logs.txt"), String.Empty);
            // Easy Mode
            if (h == 0)
            {
                int x = UnityEngine.Random.Range(0, attacks.listOfAIActions.Count);
                Debug.Log("Podjêta akcja: " + x);
                attacks.listOfAIActions[x].ExecuteAction(player, gameStateManager.currentState);
                attacks.ChangeTurn();
            }

            // Medium Mode
            if (h == 1)
            {
                gameState = gameStateManager.CopyAndModifyState(gameStateManager.currentState);
                actionNumber = minimax.MinimaxFunction(0, true, 1, gameState);
                attacks.listOfAIActions[actionNumber].ExecuteAction(player, gameStateManager.currentState);
                attacks.ChangeTurn();
            }

            if (h >= 3)
            {
                gameState = gameStateManager.CopyAndModifyState(gameStateManager.currentState);
                actionNumber = minimax.MinimaxFunction(0, true, h, gameState);
                Debug.Log(actionNumber);
                attacks.listOfAIActions[actionNumber].ExecuteAction(player, gameStateManager.currentState);
                //File.AppendAllText(Path.Combine(path, "logs.txt"), "\nWybrana akcja: " + actionNumber + " Dla stanu gry:" + minimax.EvaluateGameState(gameStateManager.currentState));
                attacks.ChangeTurn();
            }
        }
    }

    public void Damage(int damage, GameState state)
    {
        if (state.aiHealth - damage <= 0)
        {
            state.aiHealth -= damage;

            attacks.EndGame(this.gameObject, state);
        }
        else
        {
            state.aiHealth -= damage;
        }
    }

    public void Heal(int heal, GameState state)
    {
        if (state == GameObjects.Instance.StateManager.currentState) 
        {
        //{
           attacks.listOfAIActions.RemoveAt(attacks.listOfAIActions.Count - 1);
           Debug.Log("AI heal");
        }
        state.aiPotion = false;
        if (state.aiHealth + heal >= 100)
        {
            state.aiHealth = 100;
        }
        else
        {
            state.aiHealth += heal;
        }
    }
}
