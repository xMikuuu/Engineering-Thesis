using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI playerHealthTxt;
    [SerializeField] TextMeshProUGUI aiHealthTxt;

    [SerializeField] GameStateManager gameStateManager;

    // Update is called once per frame
    void Update()
    {
        playerHealthTxt.text = gameStateManager.currentState.playerHealth.ToString();
        aiHealthTxt.text = gameStateManager.currentState.aiHealth.ToString();
    }
}
