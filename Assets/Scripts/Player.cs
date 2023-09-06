using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    private static float time;
    private float timeRemaining = 1;


    // stuff for health etc
    [SerializeField] public TMP_Text hitpoints; // Display how much health player has left
    [SerializeField] public Slider slider; // this slider thingy
    public Image healthBar; // display health as a bar
    public Gradient gradient; // gradient thingy to change colors
    [SerializeField] public int maxHealth; // maximum health player can have
    public int currentHealth; // current player health

    void Start()
    {
        currentHealth = maxHealth;
        SetHealth();
    }

    void Update()
    {
        //OneSecondTimer();




        hitpoints.text = currentHealth.ToString();
        slider.value = currentHealth;
        healthBar.color = gradient.Evaluate(slider.normalizedValue);
        // if(currentHealth==0){
        //     Debug.Log("death");
        // }
        // else{
        //     currentHealth-=1;
        // }
    }

    // Set max health and a bar to right value
    public void SetHealth()
    {
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
        healthBar.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void testDmg()
    {
        if (time > 1)
        {
            if (time % 1 == 0)
            {
                currentHealth-=5;

            }
        }
    }
    void OneSecondTimer(){
        if (timeRemaining>0)
        {
            timeRemaining-=Time.deltaTime;
        }
        else{
            time+=1;
            timeRemaining =1;
            //textElement.text = time.ToString();
            Debug.Log(time);
            //testDmg();
            //MainCamera.orthographicSize += 0.005f;
        }
    }

}
