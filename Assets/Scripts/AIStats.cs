using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class AIStats : MonoBehaviour
{
    private static float time;
    private float timeRemaining = 1;

    // stuff for health etc
    [SerializeField] public TMP_Text hitpoints; // Display how much health AI has left
    [SerializeField] public Slider slider; // this slider thingy
    public Image healthBar; // display health as a bar
    public Gradient gradient; // gradient thingy to change colors
    [SerializeField] public int maxHealth; // maximum health AI can have
    public int currentHealth; // current AI health
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        SetHealth();
    }

    // Update is called once per frame
    void Update()
    {
        //OneSecondTimer();

        hitpoints.text = currentHealth.ToString();
        slider.value = currentHealth;
        healthBar.color = gradient.Evaluate(slider.normalizedValue);
    }

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
            //Debug.Log(time);
            //testDmg();
            //MainCamera.orthographicSize += 0.005f;
        }
    }
}
