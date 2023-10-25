using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LeftButton : MonoBehaviour
{

    [SerializeField] Actions Actions;
    [SerializeField] public TMP_Text textElement;
    [SerializeField] GameObject background;
    [SerializeField] PlayerActions PlayerActions;    

    void OnMouseOver()
    {
        textElement.text = "  Move:      Left";
        background.GetComponent<SpriteRenderer>().enabled = true;
    }
    void OnMouseExit()
    {
        textElement.text = "";
        background.GetComponent<SpriteRenderer>().enabled = false;
    }
    void OnMouseDown()
    {
        if(!PlayerActions.leftButtonClickable){
            return;
        }
        Actions.MoveLeft();
    }
}
