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
        textElement.text = "Attack:    Normal\n"+"DMG:          "+stats.normalDamage+"\n"+"% to hit:      "+stats.normalProcent;
        background.GetComponent<SpriteRenderer>().enabled = true;
    }
    void OnMouseExit()
    {
        textElement.text = "";
        background.GetComponent<SpriteRenderer>().enabled = false;
    }
}
