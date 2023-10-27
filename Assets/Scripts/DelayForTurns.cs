using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayForTurns : MonoBehaviour
{

    public bool turnOnDelay = false; 
    [SerializeField] PlayerActions PlayerActions;
    [SerializeField] AIActions AIActions;  
    [SerializeField] Actions Actions;     
  //  [SerializeField] GameObject Player;
   // [SerializeField] GameObject AI;  

    // public bool playerDelay;
    // public bool aiDelay;


    // public static float time;
    // private float timeRemaining = 1;

    void Update(){

        if(turnOnDelay==true){
            PlayerActions.turnOnDelay = true;
            AIActions.turnOnDelay = true;
            return;
        }
        

        else{
            PlayerActions.turnOnDelay = false;
            AIActions.turnOnDelay = false;
        }


    }

    // public void TurnDelay()
    // {
    //     if (time > 1)
    //     {
    //         if (time % 2 == 0)
    //         {


    //             if(Actions.turnAction == Player){
    //                 playerDelay = false;
    //             }
    //             else{
    //                 aiDelay = false;
    //             }
    //         }
    //     }
    // }

    // public void OneSecondTimer(){

    //     if(turnOnDelay){
    //         playerDelay=false;
    //         aiDelay = false;
    //         return;
    //     }


    //     if (timeRemaining>0)
    //     {
    //         timeRemaining-=Time.deltaTime;
    //     }
    //     else{
    //         time+=1;
    //         timeRemaining =1;
    //         Debug.Log(time);
    //         TurnDelay();
    //     }
    // }




}
