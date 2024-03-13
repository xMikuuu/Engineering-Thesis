using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class GameObjects : MonoBehaviour
{
    private static GameObjects instance;
    public static GameObjects Instance { get { return instance; } }

    [SerializeField] private GameObject aiObject;
    [SerializeField] private GameObject playerObject;
    [SerializeField] private Attacks attacks;
    [SerializeField] private GameStateManager stateManager;

    public GameStateManager StateManager { get { return stateManager; } }
    public Attacks Attacks { get { return attacks; } }
    public GameObject PlayerObject { get { return playerObject; } }
    public GameObject AiObject { get { return aiObject;} }

    private void Awake()
    {
        instance = this;
    }
}