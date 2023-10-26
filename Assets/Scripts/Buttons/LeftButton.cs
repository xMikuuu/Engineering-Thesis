using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LeftButton : MonoBehaviour
{

    [SerializeField] Actions Actions;
    [SerializeField] PlayerActions PlayerActions;    
    [SerializeField] private TMP_Text actionInfo;
    [SerializeField] private TMP_Text actionDetails;
    [SerializeField] private GameObject book;

    void OnMouseOver()
    {
        actionInfo.text = "Move:";
        actionDetails.text = "Left";
        book.GetComponent<SpriteRenderer>().enabled = true;
    }
    void OnMouseExit()
    {
        actionInfo.text = "";
        actionDetails.text = "";
        book.GetComponent<SpriteRenderer>().enabled = false;
    }
    void OnMouseDown()
    {
        if(!PlayerActions.leftButtonClickable){
            return;
        }
        Actions.MoveLeft();
    }
}