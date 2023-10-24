using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Left : MonoBehaviour
{
    [SerializeField] public TMP_Text textElement;
    [SerializeField] GameObject background;

    void OnMouseOver()
    {
        textElement.text = "Move left";
        background.GetComponent<SpriteRenderer>().enabled = true;
    }
    void OnMouseExit()
    {
        textElement.text = "";
        background.GetComponent<SpriteRenderer>().enabled = false;
    }
}
