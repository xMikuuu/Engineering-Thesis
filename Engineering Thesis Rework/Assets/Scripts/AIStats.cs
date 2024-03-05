using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class AIStats : MonoBehaviour, IDamageable
{
    [SerializeField] public int maxHealth; // maximum health player can have
    public int currentHealth; // current player health
    [SerializeField] TextMeshProUGUI healthText;

    [SerializeField] public GameObject playerObject;
    [SerializeField] public Attacks attacks;

    [SerializeField] public GameStateManager gameStateManager;

    public GameState gameState;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        healthText.text = currentHealth.ToString();
        if (!attacks.turnflag && !attacks.endgame)
        {
            gameState = gameStateManager.CopyAndModifyState();
            Debug.Log(gameState.ai.GetComponent<AIStats>().currentHealth);
            gameState.attacks.listOfActions[0].ExecuteAction(gameState.ai);
            //gameState.attacks.listOfActions[0].ExecuteAction(gameState.ai);

            //attacks.QuickAttack(playerObject);
            //attacks.listOfActions[2].ExecuteAction(playerObject);
            attacks.ChangeTurn();
        }
    }

    public void Damage(int damage)
    {
        if(currentHealth - damage <= 0)
        {
            currentHealth = 0;
            attacks.EndGame(this.gameObject);
        }
        else
        {
            currentHealth -= damage;
        }
    }
}
