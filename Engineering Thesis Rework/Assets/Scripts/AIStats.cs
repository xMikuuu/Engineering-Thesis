using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using Unity.Collections.LowLevel.Unsafe;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField] private GameObject menu;
    private bool delay;
    public static float time;
    private float timeRemaining = 1;

    // stuff for health etc
    [SerializeField] public TMP_Text hitpoints; // Display how much health player has left
    [SerializeField] public Slider slider; // this slider thingy
    public Image healthBar; // display health as a bar
    public Gradient gradient; // gradient thingy to change colors

    [SerializeField] private GameObject fightScreen;

    private void Start()
    {
        gameStateManager = GameObjects.Instance.StateManager;
        attacks = GameObjects.Instance.Attacks;
        player = GameObjects.Instance.PlayerObject;
        path = minimax.path; // œcie¿ka do logów
        SetHealth();
    }

    public void Difficulty(int difficulty)
    {
        h = difficulty;
        menu.SetActive(false);
        attacks.console.SetText(" ");
        fightScreen.SetActive(true);
        StartCoroutine("fightScreenFunction");

    }

    public void SetHealth()
    {
        slider.maxValue = 100;
        slider.value = 100;
        healthBar.color = gradient.Evaluate(slider.normalizedValue);
    }

    private IEnumerator fightScreenFunction()
    {
        yield return new WaitForSeconds(1);
        fightScreen.SetActive(false);
    }

    private void Update()
    {
        hitpoints.text = gameStateManager.currentState.aiHealth.ToString();
        slider.value = gameStateManager.currentState.aiHealth;
        healthBar.color = gradient.Evaluate(slider.normalizedValue);
        delay= false;
        
        if (!attacks.turnflag && !attacks.endgame && !attacks.menu)
        {
            OneSecondTimer();
            if (delay)
            {
                File.WriteAllText(Path.Combine(path, "logs.txt"), String.Empty);
                // Easy Mode <- wszystko dzia³a
                if (h == 0)
                {
                    if (gameStateManager.currentState.aiPotion && gameStateManager.currentState.aiHealth <= 70)
                    {
                        int coinflip = UnityEngine.Random.Range(0, 2);
                        if (coinflip == 0)
                        {
                            attacks.listOfAIActions[3].ExecuteAction(player, gameStateManager.currentState);
                        }
                        else
                        {
                            actionNumber = UnityEngine.Random.Range(0, attacks.listOfAIActions.Count);
                        }
                    }
                    else
                    {
                        actionNumber = UnityEngine.Random.Range(0, attacks.listOfAIActions.Count - 1);
                    }
                    attacks.listOfAIActions[actionNumber].ExecuteAction(player, gameStateManager.currentState);

                    //if(gameStateManager.currentState.aiHealth <= 100-(attacks.healValue-20) && gameStateManager.currentState.aiPotion)
                    //{
                    //    x = UnityEngine.Random.Range(0, 2);
                    //    if (x == 1)
                    //    {
                    //        attacks.listOfAIActions[3].ExecuteAction(player, gameStateManager.currentState);
                    //    }
                    //    else
                    //    {

                    //    }
                    //}
                    //else
                    //{
                    //    x = UnityEngine.Random.Range(0, attacks.listOfAIActions.Count - 1);
                    //    attacks.listOfAIActions[x].ExecuteAction(player, gameStateManager.currentState);
                    //}
                    //{
                    //    x = UnityEngine.Random.Range(0, 2);
                    //    if (x == 1 && gameStateManager.currentState.aiPotion)
                    //    {
                    //        attacks.listOfAIActions[3].ExecuteAction(player, gameStateManager.currentState);
                    //    }
                    //    else
                    //    {
                    //        x = UnityEngine.Random.Range(0, attacks.listOfAIActions.Count);
                    //        attacks.listOfAIActions[x].ExecuteAction(player, gameStateManager.currentState);
                    //    }
                    //}
                    //else
                    //{
                    //    x = UnityEngine.Random.Range(0, attacks.listOfAIActions.Count-1);
                    //    attacks.listOfAIActions[x].ExecuteAction(player, gameStateManager.currentState);
                    //}
                    attacks.ChangeTurn();
                }

                // Medium Mode <- wszystko dzia³a
                if (h == 1)
                {
                    gameState = gameStateManager.CopyAndModifyState(gameStateManager.currentState);
                    actionNumber = minimax.MinimaxFunction(0, true, 1, gameState);
                    attacks.listOfAIActions[actionNumber].ExecuteAction(player, gameStateManager.currentState);
                    attacks.ChangeTurn();
                }

                if (h >= 3)
                {

                    if (gameStateManager.currentState.playerHealth <= attacks.heavyThreshold)
                    {
                        attacks.listOfAIActions[2].ExecuteAction(player, gameStateManager.currentState);

                    }
                    else
                    {

                        gameState = gameStateManager.CopyAndModifyState(gameStateManager.currentState);
                        actionNumber = minimax.MinimaxFunction(0, true, h, gameState);
                        Debug.Log(actionNumber);
                        attacks.listOfAIActions[actionNumber].ExecuteAction(player, gameStateManager.currentState);
                        //File.AppendAllText(Path.Combine(path, "logs.txt"), "\nWybrana akcja: " + actionNumber + " Dla stanu gry:" + minimax.EvaluateGameState(gameStateManager.currentState));

                    }
                    attacks.ChangeTurn();
                    
                }
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
           //attacks.listOfAIActions.RemoveAt(attacks.listOfAIActions.Count - 1);
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

    private void TurnDelay()
    {
        if (time > 1)
        {
            if (time % 1 == 0)
            {
                delay = true;
            }
        }
    }

    void OneSecondTimer()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            time += 1;
            timeRemaining = 1;
            //Debug.Log(time);
            TurnDelay();
        }
    }

}
