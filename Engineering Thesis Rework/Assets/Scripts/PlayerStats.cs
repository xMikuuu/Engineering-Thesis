using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;


public class PlayerStats : MonoBehaviour, IDamageable
{
    private Attacks attacks;

    [SerializeField] private Button quick;
    [SerializeField] private Button normal;
    [SerializeField] private Button heavy;
    [SerializeField] private Button potion;

    private bool potionUsed;

    private GameStateManager gameStateManager;
    private GameObject ai;
    private GameState gameState;
    private bool delay;
    public static float time;
    private float timeRemaining = 1;
    [SerializeField] private Minimax minimax;
    // stuff for health etc
    [SerializeField] public TMP_Text hitpoints; // Display how much health player has left
    [SerializeField] public Slider slider; // this slider thingy
    public Image healthBar; // display health as a bar
    public Gradient gradient; // gradient thingy to change colors
    private void Start()
    {
        gameStateManager = GameObjects.Instance.StateManager;
        ai = GameObjects.Instance.AiObject;
        attacks = GameObjects.Instance.Attacks;
        SetHealth();
    }
    public void SetHealth()
    {
        slider.maxValue = 100;
        slider.value = 100;
        healthBar.color = gradient.Evaluate(slider.normalizedValue);
    }

    private void Update()
    {
        hitpoints.text = gameStateManager.currentState.playerHealth.ToString();
        slider.value = gameStateManager.currentState.playerHealth;
        healthBar.color = gradient.Evaluate(slider.normalizedValue);
        OneSecondTimer();

        //if (attacks.turnflag && !attacks.endgame && !delay)
        //{

        //        gameState = gameStateManager.CopyAndModifyState(gameStateManager.currentState);
        //        attacks.listOfAIActions[minimax.MinimaxFunction(0, false, 3, gameState)].ExecuteAction(ai, gameStateManager.currentState);



        //        attacks.ChangeTurn();

        //}
        if (attacks.turnflag && !attacks.endgame && !attacks.menu && delay)
        {
            TurnOnButtons();
        }
        else
        {
            TurnOffButtons();
        }
    }

    public void Damage(int damage, GameState state)
    {

        if (state.playerHealth - damage <= 0)
        {
            state.playerHealth -= damage;

            attacks.EndGame(this.gameObject, state);
        }
        else
        {
            state.playerHealth -= damage;
        }
    }

    public void Heal(int heal, GameState state)
    {
        if(state == GameObjects.Instance.StateManager.currentState)
        {
            Debug.Log("Player heal");
            //attacks.listOfPlayerActions.RemoveAt(attacks.listOfPlayerActions.Count - 1);
            potionUsed = true;
        }
        state.playerPotion = false;
        if (state.playerHealth + heal >= 100)
        {
            state.playerHealth = 100;
        }
        else
        {
            state.playerHealth += heal;
        }

    }

    private void TurnOnButtons()
    {
        quick.interactable = true ;
        normal.interactable = true;
        heavy.interactable = true;


        if (gameStateManager.currentState.playerHealth == 100)
        {
            potion.interactable = false;
        }
        else
        {
            if (!potionUsed)
            {
                potion.interactable = true;
            }
            else
            {
                potion.interactable = false;
            }
        }
    }

    private void TurnOffButtons()
    {
        quick.interactable = false;
        normal.interactable = false;
        heavy.interactable = false;
        potion.interactable = false;
    }

    public void PlayerQuickAttack()
    {
        attacks.listOfActions[0].ExecuteAction(ai, gameStateManager.currentState);
        delay = false;
    }
    public void PlayerNormalAttack()
    {
        attacks.listOfActions[1].ExecuteAction(ai, gameStateManager.currentState);
        delay = false;
    }
    public void PlayerHeavyAttack()
    {
        attacks.listOfActions[2].ExecuteAction(ai, gameStateManager.currentState);
        delay = false;
    }
    public void PlayerPotion()
    {
        attacks.listOfActions[3].ExecuteAction(ai, gameStateManager.currentState);
        delay = false;
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
