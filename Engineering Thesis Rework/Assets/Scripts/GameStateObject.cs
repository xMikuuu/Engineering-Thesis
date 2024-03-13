using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateObject
{
    public int playerHealth;
    public int aiHealth;

    private void Awake()
    {
        playerHealth = 100;
        aiHealth = 100;
    }
}