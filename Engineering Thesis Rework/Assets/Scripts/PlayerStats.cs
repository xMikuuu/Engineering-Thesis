using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class PlayerStats : MonoBehaviour, IDamageable
{
    private Attacks attacks;

    [SerializeField] private Button quick;
    [SerializeField] private Button normal;
    [SerializeField] private Button heavy;

    private GameStateManager gameStateManager;
    private GameObject ai;


    private void Start()
    {
        gameStateManager = GameObjects.Instance.StateManager;
        ai = GameObjects.Instance.AiObject;
        attacks = GameObjects.Instance.Attacks;
    }


    private void Update()
    {
        if (attacks.turnflag && !attacks.endgame)
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
            state.playerHealth = 0;
            attacks.EndGame(this.gameObject, state);
        }
        else
        {
            state.playerHealth -= damage;
        }
    }

    private void TurnOnButtons()
    {
        quick.interactable = true ;
        normal.interactable = true;
        heavy.interactable = true;
    }

    private void TurnOffButtons()
    {
        quick.interactable = false;
        normal.interactable = false;
        heavy.interactable = false;
    }

    public void PlayerQuickAttack()
    {
        attacks.listOfActions[0].ExecuteAction(ai, gameStateManager.currentState);
        //attacks.QuickAttack(ai, gameStateManager.currentState);
    }
    public void PlayerNormalAttack()
    {
        attacks.listOfActions[1].ExecuteAction(ai, gameStateManager.currentState);
    }
    public void PlayerHeavyAttack()
    {
        attacks.listOfActions[2].ExecuteAction(ai, gameStateManager.currentState);
    }

}
