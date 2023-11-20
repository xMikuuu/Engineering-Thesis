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
    [SerializeField] Minimax Minimax;
    [SerializeField] GameObject consoleBackground;

    private int randomMove;

    public static bool turnMade=false;
    // variables for timer/delay
    public static float time;
    private float timeRemaining = 1;
    public bool delay;
    public bool turnOnDelay = false;

    private List<int> hejka = new List<int>{12,1,34,7,8,10,78};
    private int chosenAction;

    //private List<ActionClass> ListOfActionsv2;

    // Movement buttons and attack buttons
    // public bool moveRight;
    // public bool moveLeft;   
    // public bool quickAttack;  
    // public bool normalAttack; 
    // public bool heavyAttack;
    // public bool healPotion;
    // public bool defensivestance;

    public Dictionary<string, bool> ListOfActions = new Dictionary<string, bool>(){
        {"moveRight",false},
        {"moveLeft",false},
        {"quickAttack",false},
        {"normalAttack",false},
        {"heavyAttack",false},
        {"healPotion",false},
        {"defensivestance",false}
    };


// public class ActionClass{
//     public string Name;
//     public bool IsAvailable;
//     public int Damage;
//     public int HitChance;
//     public int Healing;
//     public bool IsMovement;

//     public ActionClass(string name, int damage, int hitChance, int healing = 0, bool isMovement = false, bool isAvailable = false){
//         Name = name;
//         Damage = damage;
//         HitChance = hitChance;
//         Healing = healing;
//         IsMovement = isMovement;
//         IsAvailable = isAvailable;
//     }
// }

//     void Awake(){
//         ListOfActionsv2 = new List<ActionClass>();

//         ListOfActionsv2.Add(new ActionClass("moveLeft",0,100,0,true,false));
//         ListOfActionsv2.Add(new ActionClass("moveRight",0,100,0,true,false));

//         ListOfActionsv2.Add(new ActionClass("quickAttack",Actions.quickDamage,Actions.quickProcent,0,false,false));
//         ListOfActionsv2.Add(new ActionClass("normalAttack",Actions.normalDamage,Actions.normalProcent,0,false,false));
//         ListOfActionsv2.Add(new ActionClass("heavyAttack",Actions.heavyDamage,Actions.heavyProcent,0,false,false));  


//     }
    
    void Update()
    {
 
        OneSecondTimer();
        //Disable actions if AI is on the edge of the map
        if(AI.transform.position.x == -(Actions.xBound)){
            ListOfActions["moveLeft"] = false;
        }
        else
        {
            ListOfActions["moveLeft"] = true;
        }

        if(AI.transform.position.x == Actions.xBound){
             ListOfActions["moveRight"] = false;
        }
        else
        {
            ListOfActions["moveRight"] = true;
        }

        //Debug.Log(ListOfActions["moveRight"]);

        // // Disable attacks if AI is not in range
        if(Actions.inRange==true){
            ListOfActions["quickAttack"] = true; 
            ListOfActions["normalAttack"] = true; 
            ListOfActions["heavyAttack"] = true;
            ListOfActions["defensivestance"] = true;
        }
        else{
            ListOfActions["quickAttack"] = false; 
            ListOfActions["normalAttack"] = false; 
            ListOfActions["heavyAttack"] = false;
            ListOfActions["defensivestance"] = false;
        }

        // // Disable potion if AI has full health
        if(AIStats.currentHealth<AIStats.maxHealth){
            ListOfActions["healPotion"] = true;
        }
        else{
            ListOfActions["healPotion"] = false;
        }



        // Take turn
        if(Actions.turnAction==AI && !turnMade && Actions.gameFinished == false && delay == false){
            AIStats.isDefensive = false;

            chosenAction = Minimax.MinimaxFunction(0,0,true,hejka,1);

            Actions.CheckTurn();


            Debug.Log(chosenAction);
            Debug.Log("------------");


            turnMade=true;
            // if (Actions.inRange == true){
            //     randomMove = UnityEngine.Random.Range(0,5);
            // }
            // else{
            //     randomMove = UnityEngine.Random.Range(0,2);
            // }

            // if(randomMove==0){
            //     if(AI.transform.position.x==-(Actions.xBound)){
            //         Actions.MoveRight();
            //     }
            //     else{
            //         Actions.MoveLeft();
            //     }
            // }
            // if(randomMove==1){
            //     if(AI.transform.position.x==(Actions.xBound)){
            //         Actions.MoveLeft();
            //     }
            //     else{
            //         Actions.MoveRight();
            //     }
            // }
            // if(randomMove==2){
            //     Actions.QuickAttack();
            // }    
            // if(randomMove==3){
            //     Actions.NormalAttack();
            // } 
            // if(randomMove==4){
            //     Actions.HeavyAttack();
            // } 


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
