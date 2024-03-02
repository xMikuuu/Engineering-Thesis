using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;



[System.Serializable]
public class GameState
{
    public Actions actions;

    public List<Actions> listOfActions; // list of all actions
    public List<bool> aiAvailableActions; // list of AI actions current available
    public List<bool> playerAvailableActions; // same as above but for player

    // player and AI health
    public int playerHealth;
    public int aiHealth;
    public int score;


    // brakuje zmiennych:
    // - isDefensive
    // 

    public void UpdateScore()
    {
        score += 101;
    }


}

public class GameStateManager : MonoBehaviour
{
    public GameState currentState;
    [SerializeField] public Actions actions;

    private void Start()
    {
        currentState = new GameState()
        {
            actions = this.actions,
            listOfActions = this.actions.listOfActions,
            aiAvailableActions = this.actions.AIActions.AIAvailableActions,
            playerAvailableActions = this.actions.PlayerActions.PlayerAvailableActions,
            playerHealth = this.actions.PlayerStats.currentHealth,
            aiHealth = this.actions.AIStats.currentHealth
        };
    }

    public GameState CopyAndModifyState()
    {
        string serializedState = JsonUtility.ToJson(currentState);
        GameState copiedState = JsonUtility.FromJson<GameState>(serializedState);
        Debug.Log(copiedState.actions.turnAction);
        copiedState.actions.listOfActions[2].ExecuteAction(true, copiedState);

        Debug.Log("Player copiedState health:"+copiedState.playerHealth);
        Debug.Log("AI copiedState health:" + copiedState.aiHealth);

        return copiedState;
    }



    //public List<Actions> listOfActions = new List<Actions>(); // list of all actions
    //public List<bool> aiAvailableActions = new List<bool>(); // list of AI actions current available
    //public List<bool> playerAvailableActions = new List<bool>(); // same as above but for player

    //// player and AI health
    //public int playerHealth;
    //public int aiHealth;
    //public int score;

    //public GameState CopyState()
    //{
    //    playerHealth = actions.PlayerStats.currentHealth;
    //    aiHealth = actions.AIStats.currentHealth;

    //    score = aiHealth - playerHealth;

    //    listOfActions = actions.listOfActions;
    //    playerAvailableActions = actions.PlayerActions.PlayerAvailableActions;
    //    aiAvailableActions = actions.AIActions.AIAvailableActions;

    //    currentState = new GameState()
    //    {
    //        actions = this.actions,
    //        listOfActions = this.listOfActions,
    //        aiAvailableActions = this.aiAvailableActions,
    //        playerAvailableActions = this.playerAvailableActions,
    //        playerHealth = this.playerHealth,
    //        aiHealth = this.aiHealth,
    //        score = this.score,
    //    };
    //    //Debug.Log("Initial state score:"+currentState.playerHealth);
    //    //currentState.listOfActions[0].ExecuteAction();
    //    return currentState;
    //    //currentState = new GameState() { };
    //}

    //public GameState ModifyState(GameState currentState)
    //{
    //    // G³êbokie kopiowanie przez serializacjê i deserializacjê
    //    string serializedState = JsonUtility.ToJson(currentState);
    //    GameState copiedState = JsonUtility.FromJson<GameState>(serializedState);

    //    //copiedState.score += 10;
    //    //Debug.Log(copiedState.score);//listOfActions[3].ExecuteAction();
    //    copiedState.actions.listOfActions[3].ExecuteAction();

    //    return copiedState;
    //}
}
