using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Normal : MonoBehaviour
{
    [SerializeField] private TMP_Text actionInfo;
    [SerializeField] private TMP_Text actionDetails;
    [SerializeField] private GameObject book;

    [SerializeField] Actions stats;

    void OnMouseOver()
    {
        actionInfo.text = "Attack:\n"+"DMG:\n"+"% to hit:";
        actionDetails.text = "Normal\n"+stats.normalDamage+"\n"+stats.normalProcent;
        book.GetComponent<SpriteRenderer>().enabled = true;
    }
    void OnMouseExit()
    {
        actionInfo.text = "";
        actionDetails.text = "";
        book.GetComponent<SpriteRenderer>().enabled = false;
    }
}