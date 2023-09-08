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







    // Update is called once per frame
    void Update()
    {
        // Random movement left or right
        if(Actions.turnAction==AI && !turnMade){
            randomMove = UnityEngine.Random.Range(0,2);

            if(randomMove==1){
                if(AI.transform.position.x==-(Actions.xBound)){
                    Actions.MoveRight();
                }
                else{
                    Actions.MoveLeft();
                }
            }

            else{
                if(AI.transform.position.x==(Actions.xBound)){
                    Actions.MoveLeft();
                }
                else{
                    Actions.MoveRight();
                }
            }
            turnMade=true;
        }

    }
}
