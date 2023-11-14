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
    [SerializeField] AIActions AIActions;          

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

    [SerializeField] public int healingPotionValue;     

    // health for both players
    [SerializeField] PlayerStats PlayerStats;
    [SerializeField] AIStats AIStats;   

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
                AIStats.currentHealth -= damage;
            }
            else{
                PlayerStats.currentHealth -= damage;
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

    // basic attacks
    public void QuickAttack(){
        consoleText.text = turnAction.name+" used Quick Attack!";
        Attack(quickDamage,quickProcent);
    }

    public void NormalAttack(){
        consoleText.text = turnAction.name+" used Normal Attack!";
        Attack(normalDamage,normalProcent);
    }

    public void HeavyAttack(){
        consoleText.text = turnAction.name+" used Heavy Attack!";
        Attack(heavyDamage,heavyProcent);
    }




    // heal potion
    public void HealPotion(){
        consoleText.text = turnAction.name+" used Healing Potion!";
        //AIHealth.currentHealth -= damage;
        //turnAction.currentHealth+=50;
        if(turnAction == Player){
            PlayerStats.currentHealth += healingPotionValue;
            if(PlayerStats.currentHealth>PlayerStats.maxHealth){
                PlayerStats.currentHealth=PlayerStats.maxHealth;
            }
        }
        else{
            AIStats.currentHealth += healingPotionValue;
            if(AIStats.currentHealth>AIStats.maxHealth){
                AIStats.currentHealth=AIStats.maxHealth;
            }
        }

        CheckTurn();
        AIActions.turnMade=false;
    }





    private void CheckWin(){
        // Add ending screen or smth idk 💀
        if (AIStats.currentHealth<=0){
            AIStats.currentHealth = 0;
            consoleText.text = turnAction.name+" Won! Fatality";
            turnAction = Player;
            gameFinished = true;
            PlayerActions.DisableAllButtons();
        }
        if (PlayerStats.currentHealth<=0){
            PlayerStats.currentHealth = 0;
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
        consoleText.text = turnAction.name+" moved Left";
    }

    public void MoveRight(){     
        target = new Vector2(turnAction.transform.position.x+(float)DistanceToMove,turnAction.transform.position.y);
        isMovingRight = true;
        consoleText.text = turnAction.name+" moved Right";
    }

    public void CheckTurn(){ // Switch turn after every action, also it checks whos turn it is 
                if(turnFlag==true){
                    AIActions.delay = true;
                    AIActions.time = 0;
                    turnAction = AI;
                }
                else{
                    PlayerActions.delay = true;
                    PlayerActions.time = 0;
                    turnAction = Player;
                }
                turnFlag = !turnFlag;    
    }
}
