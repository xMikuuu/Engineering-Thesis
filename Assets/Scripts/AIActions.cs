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

    public int randomMove;

    public static bool turnMade=false;
    // variables for timer/delay
    public static float time;
    public static float timeRemaining = 1;
    public static bool delay;
    public static bool turnOnDelay = false;

    public List<int> hejka = new List<int>{12,1,34,7,8,10,78};
    public int chosenAction;

    //private List<ActionClass> ListOfActionsv2;

    // Movement buttons and attack buttons
    public bool moveRightAction;
    public bool moveLeftAction;   
    public bool quickAttackAction;  
    public bool normalAttackAction; 
    public bool heavyAttackAction;
    public bool healPotionAction;
    public bool defensivestanceAction;

    // public Dictionary<string, bool> ListOfActions = new Dictionary<string, bool>(){
    //     {"moveRight",false},
    //     {"moveLeft",false},
    //     {"quickAttack",false},
    //     {"normalAttack",false},
    //     {"heavyAttack",false},
    //     {"healPotion",false},
    //     {"defensivestance",false}
    // };


    public List<bool> AIAvailableActions = new List<bool>();


    void Start(){
        AIAvailableActions.Add(moveRightAction);
        AIAvailableActions.Add(moveLeftAction);

        AIAvailableActions.Add(quickAttackAction);
        AIAvailableActions.Add(normalAttackAction);
        AIAvailableActions.Add(heavyAttackAction);       

        AIAvailableActions.Add(healPotionAction);
        AIAvailableActions.Add(defensivestanceAction);        
    }



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
        CheckAIActions();


        // Take turn
        if(Actions.turnAction==AI && !turnMade && Actions.gameFinished == false && delay == false){
            AIStats.isDefensive = false;

            Debug.Log("hej");
            //Actions.listOfActions[0].ExecuteAction();
            Actions.listOfActions[1].ExecuteAction();

            //chosenAction = Minimax.MinimaxFunction(0,0,true,1,Actions);
            //Minimax

            //Actions.CheckTurn();


            //Debug.Log(chosenAction);
            //Debug.Log(Actions.AIStats.currentHealth);
            //Debug.Log("Difference in health/Score: "+Minimax.score +"\n (0: draw, -X: Player is winning, +X: AI is winning)");
            Debug.Log("\n");


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


    public void CheckAIActions(){
        if(AI.transform.position.x == -(Actions.xBound)){
                AIAvailableActions[1] = false;
            }
            else
            {
                AIAvailableActions[1] = true;
            }

            if(AI.transform.position.x == Actions.xBound){
                AIAvailableActions[0] = false;
            }
            else
            {
                AIAvailableActions[0] = true;
            }

            // // Disable attacks if AI is not in range
            if(Actions.inRange==true){
                AIAvailableActions[2] = true; 
                AIAvailableActions[3] = true; 
                AIAvailableActions[4] = true;
                AIAvailableActions[6] = true;
            }
            else{
                AIAvailableActions[2] = false; 
                AIAvailableActions[3] = false; 
                AIAvailableActions[4] = false;
                AIAvailableActions[6] = false;
            }

            // // Disable potion if AI has full health
            if(AIStats.currentHealth<AIStats.maxHealth){
                AIAvailableActions[5] = true;
            }
            else{
                AIAvailableActions[5] = false;
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
