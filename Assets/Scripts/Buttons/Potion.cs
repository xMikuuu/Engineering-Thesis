using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Potion : MonoBehaviour
{

    [SerializeField] Actions Actions;
    [SerializeField] PlayerActions PlayerActions;    
    [SerializeField] private TMP_Text actionInfo;
    [SerializeField] private TMP_Text actionDetails;
    [SerializeField] private GameObject book;
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] PlayerStats PlayerStats;

    void Update(){

        if(PlayerActions.healPotionClickable==true){
            sprite.color = Color.white;
        }
        else{
            sprite.color = Color.black;
        }
    }

    void OnMouseOver()
    {
        actionInfo.text = "Heal value:";
        actionDetails.text = Actions.healingPotionValue.ToString();
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
        if(!PlayerActions.healPotionClickable==true){
            return;
        }
        Actions.HealPotion();
    }


}
