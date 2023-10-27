using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class PlayerActions : MonoBehaviour
{
    [SerializeField] Actions Actions;
    [SerializeField] GameObject Player;
    [SerializeField] GameObject AI;




    // Movement buttons and attack buttons
    public bool rightButtonClickable;
    public bool leftButtonClickable;   
    public bool quickAttackClickable;  
    public bool normalAttackClickable; 
    public bool heavyAttackClickable;   



        // variables for timer/delay
    public static float time;
    private float timeRemaining = 1;
    public bool delay;
    private bool firstTurn=true;
    public bool turnOnDelay = false;


    void Update()
    {        
        if(firstTurn){
            delay=false;
            firstTurn=false;
            return;
        }
        else{

            OneSecondTimer();
            
            // If its players turn:
            if(Actions.turnAction==Player && Actions.gameFinished == false && delay == false){

                // Disable buttons if player is on the edge of the map
                if(Player.transform.position.x == -(Actions.xBound)){
                    leftButtonClickable = false;
                }
                else
                {
                    leftButtonClickable = true;
                }

                if(Player.transform.position.x == Actions.xBound){
                    rightButtonClickable = false;
                }
                else
                {
                    rightButtonClickable = true;
                }


                if(Actions.inRange==true){
                    quickAttackClickable = true; 
                    normalAttackClickable = true; 
                    heavyAttackClickable = true;
                }
                else{
                    quickAttackClickable = false; 
                    normalAttackClickable = false; 
                    heavyAttackClickable = false;
                }
            }
            else
            //If its AI's turn: (turn off every button)
            {
                DisableAllButtons();
            }
        }
    }

    private void TurnDelay()
    {
        if (time > 1)
        {
            if (time % 2 == 0)
            {
                delay = false;
            }
        }
    }

    void OneSecondTimer(){

        if(turnOnDelay){
            delay=false;
            return;
        }


        if (timeRemaining>0)
        {
            timeRemaining-=Time.deltaTime;
        }
        else{
            time+=1;
            timeRemaining =1;
            //Debug.Log(time);
            TurnDelay();
        }
    }

    public void DisableAllButtons(){
        leftButtonClickable = false;
        rightButtonClickable = false;
        quickAttackClickable = false; 
        normalAttackClickable = false; 
        heavyAttackClickable = false;
    }
}
