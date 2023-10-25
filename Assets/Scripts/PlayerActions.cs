using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class PlayerActions : MonoBehaviour
{
    [SerializeField] Actions Actions;
    [SerializeField] GameObject Player;
    [SerializeField] GameObject AI;


    // Movement buttons
    [SerializeField] public Button leftButton;
    [SerializeField] public Button rightButton;
    [SerializeField] public Button quickAttackButton;
    [SerializeField] public Button normalAttackButton;  
    [SerializeField] public Button heavyAttackButton;  

    void Update()
    {       
        // If its players turn:
        if(Actions.turnAction==Player && Actions.gameFinished == false){
            // Disable buttons if player is on the edge of the map
            if(Player.transform.position.x == -(Actions.xBound)){
                leftButton.interactable = false;
            }
            else
            {
                leftButton.interactable = true;
            }

            if(Player.transform.position.x == Actions.xBound){
                rightButton.interactable = false;
            }
            else
            {
                rightButton.interactable = true;
            }


            if(Actions.inRange==true){
                quickAttackButton.interactable = true;
                normalAttackButton.interactable = true;
                heavyAttackButton.interactable = true;
            }
            else{
                quickAttackButton.interactable = false;
                normalAttackButton.interactable = false;
                heavyAttackButton.interactable = false;
            }
        }
        else
        // If its AI's turn: (turn off every button)
        {
            DisableAllButtons();
        }
    }

    public void DisableAllButtons(){
        leftButton.interactable = false;
        rightButton.interactable = false;
        quickAttackButton.interactable = false;
        normalAttackButton.interactable = false;
        heavyAttackButton.interactable = false;
    }
}
