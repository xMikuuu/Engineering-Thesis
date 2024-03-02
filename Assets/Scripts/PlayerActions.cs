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
    [SerializeField] PlayerStats PlayerStats;
    [SerializeField] GameObject consoleBackground;
    [SerializeField] GameStateManager gameStateManager;


    // Movement buttons and attack buttons
    public bool rightButtonClickable;
    public bool leftButtonClickable;   
    public bool quickAttackClickable;  
    public bool normalAttackClickable; 
    public bool heavyAttackClickable;
    public bool healPotionClickable;
    public bool defensivestanceClickable;



    public bool moveRightAction;
    public bool moveLeftAction;   
    public bool quickAttackAction;  
    public bool normalAttackAction; 
    public bool heavyAttackAction;
    public bool healPotionAction;
    public bool defensivestanceAction;




    // variables for timer/delay
    public static float time;
    private float timeRemaining = 1;
    public bool delay;
    private bool firstTurn=true;
    public bool turnOnDelay = false;

    public List<bool> PlayerAvailableActions = new List<bool>();



    void Start(){
        PlayerAvailableActions.Add(moveRightAction);
        PlayerAvailableActions.Add(moveLeftAction);

        PlayerAvailableActions.Add(quickAttackAction);
        PlayerAvailableActions.Add(normalAttackAction);
        PlayerAvailableActions.Add(heavyAttackAction);       

        PlayerAvailableActions.Add(healPotionAction);
        PlayerAvailableActions.Add(defensivestanceAction);        
    }


    public void CheckPlayerActions(){
        if(Player.transform.position.x == -(Actions.xBound)){
                    PlayerAvailableActions[1] = false;
                }
                else
                {
                    PlayerAvailableActions[1] = true;
                }

                if(Player.transform.position.x == Actions.xBound){
                    PlayerAvailableActions[0] = false;
                }
                else
                {
                    PlayerAvailableActions[0] = true;
                }


                if(Actions.inRange==true){
                    PlayerAvailableActions[2] = true; 
                    PlayerAvailableActions[3] = true; 
                    PlayerAvailableActions[4] = true;
                    PlayerAvailableActions[6] = true;
                }
                else{
                    PlayerAvailableActions[2] = false; 
                    PlayerAvailableActions[3] = false; 
                    PlayerAvailableActions[4] = false;
                    PlayerAvailableActions[6] = false;
                }


                if(PlayerStats.currentHealth<PlayerStats.maxHealth){
                    PlayerAvailableActions[5] = true;
                }
                else{
                    PlayerAvailableActions[5] = false;
                }

    }

    void Update()
    {        

        CheckPlayerActions();

        if(firstTurn){
            delay=false;
            firstTurn=false;
            return;
        }
        else{

            OneSecondTimer();
            
            // If its players turn:
            if(Actions.turnAction==Player && Actions.gameFinished == false && delay == false){


                //GameState state2 = gameStateManager.CopyAndModifyState();

                //Actions.listOfActions[0].ExecuteAction();

                PlayerStats.isDefensive = false;
                consoleBackground.GetComponent<SpriteRenderer>().enabled = true;

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
                    defensivestanceClickable = true;
                }
                else{
                    quickAttackClickable = false; 
                    normalAttackClickable = false; 
                    heavyAttackClickable = false;
                    defensivestanceClickable = false;
                }


                if(PlayerStats.currentHealth<PlayerStats.maxHealth){
                    healPotionClickable = true;
                }
                else{
                    healPotionClickable = false;
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
        healPotionClickable = false;
        defensivestanceClickable = false;
    }
}
