using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class PlayerStats : MonoBehaviour, IDamageable
{
    [SerializeField] Attacks attacks;

    [SerializeField] Button quick;
    [SerializeField] Button normal;
    [SerializeField] Button heavy;

    [SerializeField] GameStateManager gameStateManager;
    private GameObject ai;


    private void Awake()
    {
        ai = GameObjects.Instance.AiObject;
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
