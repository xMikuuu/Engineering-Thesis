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
    private int randomMove;

    public static bool turnMade=false;

    [SerializeField] GameObject consoleBackground;
    void Update()
    {
        // Random movement left or right
        if(Actions.turnAction==AI && !turnMade && Actions.gameFinished == false){

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
}
