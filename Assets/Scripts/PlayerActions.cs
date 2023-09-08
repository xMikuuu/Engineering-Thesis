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

    // Movement buttons
    [SerializeField] public Button leftButton;
    [SerializeField] public Button rightButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {       
        // If its players turn:
        if(Actions.turnAction==Player){
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

        }
        else
        // If its AI's turn: (turn off every button)
        //if(Actions.turnAction!=Player)
        {
            leftButton.interactable = false;
            rightButton.interactable = false;
        }


    }
}
