using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayForTurns : MonoBehaviour
{

    public bool turnOnDelay = false; 
    [SerializeField] PlayerActions PlayerActions;
    [SerializeField] AIActions AIActions;  
    


    void Update(){

        if(turnOnDelay==true){
            PlayerActions.turnOnDelay = false;
            AIActions.turnOnDelay = false;
            return;
        }
        

        else{
            PlayerActions.turnOnDelay = true;
            AIActions.turnOnDelay = true;
        }


    }

}
