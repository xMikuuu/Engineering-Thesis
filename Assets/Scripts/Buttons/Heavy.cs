using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Heavy : MonoBehaviour
{
    [SerializeField] public TMP_Text textElement;
    [SerializeField] GameObject background;

    [SerializeField] Actions stats;

    void OnMouseOver()
    {
        textElement.text = "Attack:     Heavy\n"+"DMG:          "+stats.heavyDamage+"\n"+"% to hit:      "+stats.heavyProcent;
        background.GetComponent<SpriteRenderer>().enabled = true;
    }
    void OnMouseExit()
    {
        textElement.text = "";
        background.GetComponent<SpriteRenderer>().enabled = false;
    }
}
