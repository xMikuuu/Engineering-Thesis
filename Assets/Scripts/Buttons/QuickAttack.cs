using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QuickAttack : MonoBehaviour
{
    [SerializeField] private TMP_Text actionInfo;
    [SerializeField] private TMP_Text actionDetails;
    [SerializeField] private GameObject book;
    [SerializeField] Actions Actions;
    [SerializeField] PlayerActions PlayerActions;
    [SerializeField] SpriteRenderer sprite;

    void Update(){

        if(PlayerActions.quickAttackClickable==true){
            sprite.color = Color.green;
        }
        else{
            sprite.color = Color.black;
        }
    }
    void OnMouseOver()
    {
        actionInfo.text = "Attack:\n"+"DMG:\n"+"% to hit:";
        actionDetails.text = "Quick\n"+Actions.quickDamage+"\n"+Actions.quickProcent;
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
        if(!PlayerActions.quickAttackClickable){
            return;
        }
        Actions.QuickAttack();
    }
}
