using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class PlayerStats : MonoBehaviour, IDamageable
{
    [SerializeField] public int maxHealth; // maximum health player can have
    public int currentHealth; // current player health
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] Attacks attacks;

    [SerializeField] Button quick;
    [SerializeField] Button normal;
    [SerializeField] Button heavy;


    // Start is called before the first frame update
    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        healthText.text = currentHealth.ToString();
        if (attacks.turnflag && !attacks.endgame)
        {
            TurnOnButtons();
        }
        else
        {
            TurnOffButtons();
        }
    }

    public void Damage(int damage)
    {
        if (currentHealth - damage <= 0)
        {
            currentHealth = 0;
            attacks.EndGame(this.gameObject);
        }
        else
        {
            currentHealth -= damage;
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
}
