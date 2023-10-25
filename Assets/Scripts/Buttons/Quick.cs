using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quick : MonoBehaviour
{
    [SerializeField] public TMP_Text textElement;
    [SerializeField] GameObject background;

    [SerializeField] Actions stats;

    void OnMouseOver()
    {
        //textElement.text = "Quick Attack\n"+"Deal: "+stats.quickDamage+"dmg\n"+stats.quickProcent+"% to hit";
        textElement.text = "Attack:      Quick\n"+"DMG:          "+stats.quickDamage+"\n"+"% to hit:      "+stats.quickProcent;
        background.GetComponent<SpriteRenderer>().enabled = true;
    }
    void OnMouseExit()
    {
        textElement.text = "";
        background.GetComponent<SpriteRenderer>().enabled = false;
    }
}
