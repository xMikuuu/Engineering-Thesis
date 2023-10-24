using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Right : MonoBehaviour
{
    [SerializeField] public TMP_Text textElement;
    [SerializeField] GameObject background;

    void OnMouseOver()
    {
        textElement.text = "Move right";
        background.GetComponent<SpriteRenderer>().enabled = true;
    }
    void OnMouseExit()
    {
        textElement.text = "";
        background.GetComponent<SpriteRenderer>().enabled = false;
    }
}
