using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;


public class Actions : MonoBehaviour
{
    // 0 = Player
    // 1 = AI
    public static bool turnFlag;
    public static GameObject turnAction; // variable to which it assigns the current object

    [SerializeField] GameObject Player;
    [SerializeField] GameObject AI;  
   // [SerializeField] GameObject AIActions;

    private float speed = 2f; // movement speed
    private Vector2 target; // target position
    private float step; // movement step

    private static bool isMovingLeft;
    private static bool isMovingRight;

    // X bound is: <-6.5;6.5>
    [SerializeField] public double xBound;
    [SerializeField] public double DistanceToMove;


    private float distance;


    void Awake(){
        CheckTurn();
        step = speed * Time.deltaTime;
    }

    void Update(){
        // Check if player is currently moving if so, do this fancy functions

        
        CheckDistance(Player.transform.position,AI.transform.position);



        if(isMovingLeft){
            if(target.x<-6.5f){
                target.x = -6.5f;
            }

            turnAction.transform.position = Vector2.MoveTowards(turnAction.transform.position,target,step);
            if(target.x==turnAction.transform.position.x){
                CheckTurn();
                isMovingLeft = false;
                AIActions.turnMade=false;
            }
            
        }
        if(isMovingRight){
            if(target.x>6.5f){
                target.x = 6.5f;
            }
            turnAction.transform.position = Vector2.MoveTowards(turnAction.transform.position,target,step);
            if(target.x==turnAction.transform.position.x){
                CheckTurn();
                isMovingRight = false;
                AIActions.turnMade=false;
            }       
        }
    }

    public void CheckDistance(Vector2 a, Vector2 b){ // check distance between players
        distance = Vector2.Distance(a, b);
        Debug.Log(distance);
        // if distance <= 3 to można sie bitkować
    }


    public void MoveLeft(){ // functions to move left or right (from player perspective they are both called by button in game object)
        target = new Vector2(turnAction.transform.position.x-(float)DistanceToMove,turnAction.transform.position.y);
        isMovingLeft = true;
    }

    public void MoveRight(){     
        target = new Vector2(turnAction.transform.position.x+(float)DistanceToMove,turnAction.transform.position.y);
        isMovingRight = true;
    }

    public void CheckTurn(){ // Switch turn after every action, also it checks whos turn it is 
        if(turnFlag==true){
            turnAction = AI;
        }
        else{
            turnAction = Player;
        }
        turnFlag = !turnFlag;
    }
}
