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

    [SerializeField] public Button leftButton;
    [SerializeField] public Button rightButton;

    [SerializeField] public TMP_Text leftButtonText;
    [SerializeField] public TMP_Text rightButtonText;


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
            //Debug.Log(target.x);

            if(target.x<-6.5f){
                target.x = -6.5f;
            }

            turnAction.transform.position = Vector2.MoveTowards(turnAction.transform.position,target,step);
            if(target.x==turnAction.transform.position.x){
                isMovingLeft = false;
                CheckTurn();
            }
            // Turn off leftt movement button if player is at the end of the map
        }
        if(isMovingRight){
            //Debug.Log(target.x);

            if(target.x>6.5f){
                target.x = 6.5f;
            }

            turnAction.transform.position = Vector2.MoveTowards(turnAction.transform.position,target,step);

            if(target.x==turnAction.transform.position.x){
                isMovingRight = false;
                CheckTurn();
            }
        }

        // Turn off left movement button if player is at the left end of the map
        if(Player.transform.position.x == -6.5){
            leftButton.gameObject.SetActive(false);
        }
        else
        {
            leftButton.gameObject.SetActive(true);
        }


        // Turn off right movement button if player is at the right end of the map
        if(Player.transform.position.x == 6.5){
            rightButton.gameObject.SetActive(false);
        }
        else
        {
            rightButton.gameObject.SetActive(true);
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
        //turnFlag = !turnFlag;
    }
}
