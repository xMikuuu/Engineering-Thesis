using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Normal : MonoBehaviour
{
    [SerializeField] public TMP_Text textElement;
    [SerializeField] GameObject background;

    [SerializeField] Actions stats;

    void OnMouseOver()
    {
        textElement.text = "Normal Attack\n"+"Deal: "+stats.normalDamage+"dmg\n"+stats.normalProcent+"% to hit";
        background.GetComponent<SpriteRenderer>().enabled = true;
    }
    void OnMouseExit()
    {
        textElement.text = "";
        background.GetComponent<SpriteRenderer>().enabled = false;
    }
}
