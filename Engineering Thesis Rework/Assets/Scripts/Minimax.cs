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

    public int MinimaxFunction(int depth, bool isMax, int h, GameState gameState)
    {
        if (depth == h)
        {
            return EvaluateGameState(gameState);
        }
        if (isMax) // Gracz Maksymalizuj¹cy
        {
            //Debug.Log("-----------------MAX-------------------");
            int bestValue = int.MinValue;
            int bestAction = -1;

            for (int i = 0; i < attacks.listOfAIActions.Count; i++)
            {
                GameState tempGameState = gameStateManager.CopyAndModifyState(gameState); // kopia stanu gry


                if(i == 3 && !tempGameState.aiPotion)
                {
                    continue;//?
                }

                attacks.listOfAIActions[i].ExecuteAction(GameObjects.Instance.PlayerObject, tempGameState); // egzekucja akcji
                Debug.Log(tempGameState.aiPotion);
                //Debug.Log("Action number: "+ i+"    G³êbokoœæ: " + depth + "  PlayerHP: "+tempGameState.playerHealth + "    AiHP:"+   tempGameState.aiHealth + "    Stan gry: "+EvaluateGameState(tempGameState));
                int value = MinimaxFunction(depth + 1, false, h, tempGameState);

                if (value > bestValue)
                {
                    bestValue = value;
                    bestAction = i;
                }
            }
            // Zwracanie najlepszej akcji / najlepszej wartoœci
            if (depth == 0)
            {
                return bestAction;
            }
            else
            {
                return bestValue;
            }
        }
        else // Gracz Minimalizuj¹cy
        {
            //Debug.Log("------------------MIN------------------");
            int worstValue = int.MaxValue;
            int worstAction = -1;

            for (int i = 0; i < attacks.listOfPlayerActions.Count; i++)
            {
                GameState tempGameState = gameStateManager.CopyAndModifyState(gameState);


                if (i == 3 && !tempGameState.playerPotion)
                {
                    continue;//?
                }


                attacks.listOfPlayerActions[i].ExecuteAction(GameObjects.Instance.AiObject, tempGameState);
                //Debug.Log("Action number: " + i + "    G³êbokoœæ: " + depth + "  PlayerHP: " + tempGameState.playerHealth + "    AiHP:" + tempGameState.aiHealth + "    Stan gry: " + EvaluateGameState(tempGameState));
                int value = MinimaxFunction(depth + 1, true, h, tempGameState);
                if (value < worstValue)
                {
                    worstValue = value;
                    worstAction = i;
                }
            }
            if (depth == 0)
            {
                return worstAction;
            }
            else
            {
                return worstValue;
            }
        }
    }


    // Dzia³a tylko dla H = 1

    //public int MinimaxFunction(int depth, bool isMax, int h, GameState gameState, int bestActionSoFar = -1)
    //{
    //    if (depth == h)
    //    {
    //        return EvaluateGameState(gameState);
    //    }

    //    if (isMax)
    //    {
    //        int bestValue = int.MinValue;
    //        int bestAction = -1;

    //        for (int i = 0; i < attacks.listOfActions.Count; i++)
    //        {
    //            GameState tempGameState = gameStateManager.CopyAndModifyState();
    //            attacks.listOfActions[i].ExecuteAction(GameObjects.Instance.PlayerObject, tempGameState);
    //            int value = MinimaxFunction(depth + 1, false, h, tempGameState);

    //            if (value > bestValue)
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
    //        int worstValue = int.MaxValue;

    //        for (int i = 0; i < attacks.listOfActions.Count; i++)
    //        {
    //            GameState tempGameState = gameStateManager.CopyAndModifyState();
    //            attacks.listOfActions[i].ExecuteAction(GameObjects.Instance.AiObject, tempGameState);
    //            int value = MinimaxFunction(depth + 1, true, h, tempGameState);

    //            worstValue = Math.Min(worstValue, value);
    //        }
    //        return worstValue;
    //    }
    //}


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

    //public int MinimaxFunction(int depth, int nodeIndex, bool isMax, int h, GameState gameState)
    //{
    //    if (depth == h)
    //    { 
    //        return bestMove;
    //    }
    //    if (isMax)
    //    {        
    //        temp = int.MinValue;
    //        int tempScore = -1;
    //        for (int i = 0; i < attacks.listOfActions.Count; i++)
    //        {
    //            tempGameState = gameStateManager.CopyAndModifyState(); // kopia stanu gry
    //            attacks.listOfActions[i].ExecuteAction(GameObjects.Instance.PlayerObject, tempGameState); // wykonanie akcji z listy
    //            tempScore = EvaluateGameState(tempGameState); // obliczenie score'a (hp ai - hp gracza)
    //            temp = Math.Max(tempScore, MinimaxFunction(depth + 1, i, true, h, gameState));
    //        }
    //        return temp;
    //    }

    //    else
    //    {
    //        return -1;
    //        //temp = int.MaxValue;
    //        //for (int i = 0; i < attacks.listOfActions.Count; i++)
    //        //{
    //        //    tempGameState = gameStateManager.CopyAndModifyState();
    //        //    attacks.listOfActions[i].ExecuteAction(GameObjects.Instance.AiObject, tempGameState);
    //        //    temp = Math.Min(temp, MinimaxFunction(depth + 1, i, true, h, gameState, score));
    //        //}
    //        //return temp;
    //    }
    //}
}
