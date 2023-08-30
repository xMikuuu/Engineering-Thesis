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

    private float speed = 2f; // movement speed
    private Vector2 target; // target position
    private float step; // movement step

    private static bool isMovingLeft;
    private static bool isMovingRight;

    // X bound is: <-6.5;6.5>
    private static double xBound;

    void Awake(){
        CheckTurn();
        step = speed * Time.deltaTime;
    }

    void Update(){
        // Check if player is currently moving if so, do this fancy functions
        if(isMovingLeft){
            Debug.Log(target.x);
            turnAction.transform.position = Vector2.MoveTowards(turnAction.transform.position,target,step);
            if(target.x==turnAction.transform.position.x){
                isMovingLeft = false;
                CheckTurn();
            }
        }
        if(isMovingRight){
            Debug.Log(target.x);
            turnAction.transform.position = Vector2.MoveTowards(turnAction.transform.position,target,step);
            if(target.x==turnAction.transform.position.x){
                isMovingRight = false;
                CheckTurn();
            }
        }
    }

    public void MoveLeft(){ // functions to move left or right (from player perspective they are both called by button in game object)
        target = new Vector2(turnAction.transform.position.x-1.5f,turnAction.transform.position.y);
        isMovingLeft = true;
    }

    public void MoveRight(){
        target = new Vector2(turnAction.transform.position.x+1.5f,turnAction.transform.position.y);
        isMovingRight = true;
    }

    void CheckTurn(){ // Switch turn after every action, also it checks whos turn it is 
        if(turnFlag==true){
            turnAction = AI;
        }
        else{
            turnAction = Player;
        }
        turnFlag = !turnFlag;
    }
}
