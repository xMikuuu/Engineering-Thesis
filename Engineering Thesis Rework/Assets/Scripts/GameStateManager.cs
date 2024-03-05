using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState
{
    public Attacks attacks;
    public List<Attacks> listOfActions;
    public GameObject player;
    public GameObject ai;
    public int score;
}
public class GameStateManager : MonoBehaviour
{
    [SerializeField] public Attacks attacks;
    public GameState currentState;

    private void Start()
    {
        currentState = new GameState()
        {
            attacks = this.attacks,
            listOfActions = this.attacks.listOfActions,
            player = this.attacks.playerObject,
            ai = this.attacks.aiObject
        };
    }
    public GameState CopyAndModifyState()
    {
        string serializedState = JsonUtility.ToJson(currentState);
        GameState copiedState = JsonUtility.FromJson<GameState>(serializedState);

        Debug.Log(copiedState.ai.name);

        return copiedState;
    }

}
