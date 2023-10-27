using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NormalAttack : MonoBehaviour
{
    [SerializeField] private TMP_Text actionInfo;
    [SerializeField] private TMP_Text actionDetails;
    [SerializeField] private GameObject book;
    [SerializeField] Actions Actions;
    [SerializeField] PlayerActions PlayerActions;
    [SerializeField] SpriteRenderer sprite;

    void Update(){

        if(PlayerActions.normalAttackClickable==true){
            sprite.color = Color.yellow;
        }
        else{
            sprite.color = Color.black;
        }
    }
    void OnMouseOver()
    {
        actionInfo.text = "Attack:\n"+"DMG:\n"+"% to hit:";
        actionDetails.text = "Normal\n"+Actions.normalDamage+"\n"+Actions.normalProcent;
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
        if(!PlayerActions.normalAttackClickable){
            return;
        }
        Actions.NormalAttack();
    }
}
