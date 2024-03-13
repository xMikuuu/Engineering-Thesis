using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class MinimaxResult
{
    public int bestActionIndex;
    public int score;

    public MinimaxResult(int index, int score)
    {
        this.bestActionIndex = index;
        this.score = score;
    }
}


public class Minimax : MonoBehaviour
{

    private Attacks attacks;
    private GameStateManager gameStateManager;

    // difficulty levels:
    // easy: ai moves randomly
    // medium: current best move
    // hard: 3 moves ahead

    private int temp;
    private GameState tempGameState;
    public int score;
    public int bestMove;

    private void Start()
    {
        gameStateManager = GameObjects.Instance.StateManager;
        attacks = GameObjects.Instance.Attacks;
    }

    private int EvaluateGameState(GameState gameState)
    {
        return gameState.aiHealth - gameState.playerHealth;
    }


    //public int MinimaxFunction(int depth, int nodeIndex, bool isMax, int h, GameState gameState, int bestActionSoFar)
    //{
    //    if (depth == h)
    //    {
    //        return EvaluateGameState(gameState);
    //        //return new MinimaxResult(nodeIndex, score);
    //    }

    //    int bestAction = -1;

    //    if (isMax)
    //    {
    //        int bestValue = int.MinValue;


    //        for (int i = 0; i < attacks.listOfActions.Count; i++)
    //        {
    //            tempGameState = gameStateManager.CopyAndModifyState();
    //            attacks.listOfActions[i].ExecuteAction(GameObjects.Instance.PlayerObject, tempGameState);
    //            int value = MinimaxFunction(depth + 1, i, false, h, tempGameState, bestActionSoFar);
    //            if(value > bestValue)
    //            {
    //                bestValue = value;
    //                bestAction = i;
    //            }
    //        }
    //        if (depth == 0)
    //        {
    //            return bestAction;
    //        }
    //        else
    //        {
    //            return bestValue;
    //        }
    //    }
    //    else
    //    {
    //        return 7;
    //    }
    //    //return new MinimaxResult(nodeIndex, score);

    //}


    // Ten mój minimax

    public int MinimaxFunction(int depth, int nodeIndex, bool isMax, int h, GameState gameState)
    {
        //int bestAction = -1;
        if (depth == h)
        { 
            return bestMove;
        }
        if (isMax)
        {        
            temp = int.MinValue;
            int tempScore = -1;
            for (int i = 0; i < attacks.listOfActions.Count; i++)
            {
                tempGameState = gameStateManager.CopyAndModifyState();
                attacks.listOfActions[i].ExecuteAction(GameObjects.Instance.PlayerObject, tempGameState);
                //tempScore = EvaluateGameState(tempGameState);
                temp = Math.Max(temp, MinimaxFunction(depth + 1, i, true, h, gameState));
            }
            //Debug.Log(temp);
            return temp;
        }

        else
        {
            return -1;
            //temp = int.MaxValue;
            //for (int i = 0; i < attacks.listOfActions.Count; i++)
            //{
            //    tempGameState = gameStateManager.CopyAndModifyState();
            //    attacks.listOfActions[i].ExecuteAction(GameObjects.Instance.AiObject, tempGameState);
            //    temp = Math.Min(temp, MinimaxFunction(depth + 1, i, true, h, gameState, score));
            //}
            //return temp;
        }
    }
}
