using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;
using System.Linq;

public class Minimax : MonoBehaviour
{
    [SerializeField] int depth; // how many moves in future should algorithm check
    [SerializeField] Actions Actions;

    // difficulty levels:
    // easy: ai moves randomly
    // medium: 2 moves ahead
    // hard: 5 moves ahead


    [SerializeField] AIActions AIActions;
    [SerializeField] AIStats AIStats;
    [SerializeField] PlayerStats PlayerStats;  


    private Dictionary<string, bool> ListOfAvailableActions = new Dictionary<string, bool>();


    private int healthDifference; // AIStats.currentHealt - PlayerStats.currentHealth;

    // private List<int> hejka = new List<int>{12,1,34,7,8,46,78};
    private int chosenAction;

    // void Update(){
    //     healthDifference = AIStats.currentHealth-PlayerStats.currentHealth;
    //     Debug.Log("Różnica w zdrowiu: "+healthDifference);
    //     Debug.Log("Ilość dostępnych ruchów dla AI: "+ListOfAvailableActions.Count);
    // }



    public int MinimaxFunction(int depth, int nodeIndex, bool isMax, List<int> score, int h){

        ListOfAvailableActions = AIActions.ListOfActions.Where(pair => pair.Value == true).ToDictionary(pair => pair.Key, pair => pair.Value);
        if (depth == h){      
            healthDifference = AIStats.currentHealth-PlayerStats.currentHealth;
            Debug.Log("Różnica w zdrowiu: "+healthDifference);
            Debug.Log("Ilość dostępnych ruchów dla AI: "+ListOfAvailableActions.Count);   
            return score[nodeIndex];
        }

        if(isMax){
            chosenAction = int.MinValue;
            for (int i = 0; i < ListOfAvailableActions.Count; i++) {
                chosenAction = Math.Max(chosenAction, MinimaxFunction(depth+1,i,false,score,h));
            }
            return chosenAction;
        }
        else{
            chosenAction = int.MaxValue;
            for (int i = 0; i < ListOfAvailableActions.Count; i++) {
                chosenAction = Math.Min(chosenAction, MinimaxFunction(depth+1,i,true,score,h));
            }
            return chosenAction;
        }
    }





        // chosenAction = 0; // change it if any one the actions could be below 0 somehow
        // for (int i = 0; i < ListOfAvailableActions.Count; i++) {
        //     // Math.Max(chosenAction,minimax(depth+1,i,false/true,scores,h);
        //     chosenAction = Math.Max(chosenAction,hejka[i]);
        // }

        // Debug.Log(chosenAction);

        // foreach (var pair in ListOfAvailableActions)
        // {
        //     Debug.Log($"Klucz: {pair.Key}, Wartość: {pair.Value}");
        // }



        // Debug.Log("Wybrana liczba "+chosenAction);
        // Debug.Log("-----");
    }


    // void Update(){
    //     Debug.Log(AIActions.ListOfActions.Count);
    // }




    // void Minimax(position,depth,player){
    //     if (depth == 0 || Actions.CheckWin() in position){
    //         return position //static Evaluate
    //     }

    //     if (player){
    //         maxEval = int.MinValue;
    //         foreach (child of position){
    //             eval = Minimax(child, depth -1, false)
    //             maxEval = max(maxEval,eval)
    //         }
    //         return maxEval;
    //     }
    //     else{
    //         minEval = int.MaxValue;
            
    //     }


//}

