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
    public bool gameFinished = false;

    [SerializeField] GameObject Player;
    [SerializeField] GameObject AI;  
    [SerializeField] PlayerActions PlayerActions;      

    private float speed = 2f; // movement speed
    private Vector2 target; // target position
    private float step; // movement step

    private static bool isMovingLeft;
    private static bool isMovingRight;

    // X bound is: <-6.5;6.5>
    [SerializeField] public double xBound;
    [SerializeField] public double DistanceToMove;

    // Distance for attacks
    private float distance; // check distance between players
    [SerializeField] double attackRange; // range of attacks 
    public bool inRange; // i think i dont have to comment that one 💀

    // variables for attacks
    private int hitOrMiss; // variable to check if u hit or miss
    private string hitOrMissString;  // variable to prompt miss or hit

    [SerializeField] public int quickDamage;
    [SerializeField] public int quickProcent;

    [SerializeField] public int normalDamage;
    [SerializeField] public int normalProcent;

    [SerializeField] public int heavyDamage;
    [SerializeField] public int heavyProcent;    

    // health for both players
    [SerializeField] PlayerStats PlayerHealth;
    [SerializeField] AIStats AIHealth;   

    // "console" to print AI actions
    [SerializeField] public TMP_Text consoleText;
    [SerializeField] GameObject consoleBackground;


    void Awake(){
        CheckTurn();
        step = speed * Time.deltaTime;
        //consoleBackground.GetComponent<SpriteRenderer>().enabled = true; // turn on background of the console
    }

    void Update(){
        
        CheckDistance(Player.transform.position,AI.transform.position);
        // Check if player is currently moving if so, do this fancy functions
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

    private void Attack(int damage,int chance){

        hitOrMiss = UnityEngine.Random.Range(1,101); // 1-100 range

        // hit
        if(hitOrMiss<=chance){
            if(turnAction == Player){
                AIHealth.currentHealth -= damage;
            }
            else{
                PlayerHealth.currentHealth -= damage;
            }
            consoleText.text += "\nHit!";
            CheckWin();
            AIActions.turnMade=false;
        }
        // miss
        else{
            consoleText.text += "\nMissed!";
            CheckTurn();
            AIActions.turnMade=false;
        }
    }

    public void QuickAttack(){
        if(turnAction==AI){
            consoleText.text = turnAction.name+" used Quick Attack!";
        }
        Attack(quickDamage,quickProcent);
    }

    public void NormalAttack(){
        if(turnAction==AI){
            consoleText.text = turnAction.name+" used Normal Attack!";
        }
        Attack(normalDamage,normalProcent);
    }

    public void HeavyAttack(){
        if(turnAction==AI){
            consoleText.text = turnAction.name+" used Heavy Attack!";
        }
        Attack(heavyDamage,heavyProcent);
    }

    private void CheckWin(){
        // Add ending screen or smth idk 💀
        if (AIHealth.currentHealth<=0){
            AIHealth.currentHealth = 0;
            consoleText.text = turnAction.name+" Won! Fatality";
            turnAction = Player;
            gameFinished = true;
            PlayerActions.DisableAllButtons();
        }
        if (PlayerHealth.currentHealth<=0){
            PlayerHealth.currentHealth = 0;
            consoleText.text = turnAction.name+" Won! Fatality";
            turnAction = Player;
            gameFinished = true;
            PlayerActions.DisableAllButtons();
        }
        else{
            CheckTurn();
        }
    }

    public void CheckDistance(Vector2 a, Vector2 b){ // check distance between players and switch inRange flag if distance in enough or not
        distance = Vector2.Distance(a, b);
        if (distance <= attackRange){
            inRange = true;
        }
        else{
            inRange = false;
        }
    }

    public void MoveLeft(){ // functions to move left or right (from player perspective they are both called by button in game object)
        target = new Vector2(turnAction.transform.position.x-(float)DistanceToMove,turnAction.transform.position.y);
        isMovingLeft = true;
        if(turnAction==AI){
            consoleText.text = turnAction.name+" moved Left";
        }
    }

    public void MoveRight(){     
        target = new Vector2(turnAction.transform.position.x+(float)DistanceToMove,turnAction.transform.position.y);
        isMovingRight = true;
        if(turnAction==AI){
            consoleText.text = turnAction.name+" moved Right";
        }
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
