using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class AIActions : MonoBehaviour
{
    [SerializeField] Actions Actions;
    [SerializeField] GameObject AI;
    [SerializeField] AIStats AIStats;
    private int randomMove;

    public static bool turnMade=false;

    [SerializeField] GameObject consoleBackground;


    // variables for timer/delay
    public static float time;
    private float timeRemaining = 1;
    public bool delay;
    public bool turnOnDelay = false;


    void Update()
    {


        OneSecondTimer();

        // Random movement left or right
        if(Actions.turnAction==AI && !turnMade && Actions.gameFinished == false && delay == false){

            AIStats.isDefensive = false;

            consoleBackground.GetComponent<SpriteRenderer>().enabled = true;

            if (Actions.inRange == true){
                randomMove = UnityEngine.Random.Range(0,5);
            }
            else{
                randomMove = UnityEngine.Random.Range(0,2);
            }

            if(randomMove==0){
                if(AI.transform.position.x==-(Actions.xBound)){
                    Actions.MoveRight();
                }
                else{
                    Actions.MoveLeft();
                }
            }
            if(randomMove==1){
                if(AI.transform.position.x==(Actions.xBound)){
                    Actions.MoveLeft();
                }
                else{
                    Actions.MoveRight();
                }
            }
            if(randomMove==2){
                Actions.QuickAttack();
            }    
            if(randomMove==3){
                Actions.NormalAttack();
            } 
            if(randomMove==4){
                Actions.HeavyAttack();
            } 


            turnMade=true;
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
}
