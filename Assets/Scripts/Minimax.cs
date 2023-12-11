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


    // [SerializeField] AIActions AIActions;
    // [SerializeField] AIStats AIStats;
    // [SerializeField] PlayerStats PlayerStats;  
    //[SerializeField] Actions Actions;  

    //private Dictionary<string, bool> ListOfAvailableActions = new Dictionary<string, bool>();

    int ListOfAvailableActions=2;
    //public int healthDifference; // AIStats.currentHealt - PlayerStats.currentHealth;

    // private List<int> hejka = new List<int>{12,1,34,7,8,46,78};
    private int temp;
    public int score = 0;
    // void Update(){
    //     healthDifference = AIStats.currentHealth-PlayerStats.currentHealth;
    //     Debug.Log("Różnica w zdrowiu: "+healthDifference);
    //     Debug.Log("Ilość dostępnych ruchów dla AI: "+ListOfAvailableActions.Count);
    // }


    // private List<Action> ActionsList = new List<Action>(){
    //     Actions.MoveLeft()
    // };

    // //public delegate void Delegate();
    // //private List<Action> listOfActions = new List<Action>();

    // Actions actions = new Actions();



    

    //public delegate void MoveLeftDelegate();


    //Actions actions = GameObject.AddComponent<Actions>();




    // private Delegate delegateMoveLeft = actions.MoveLeft();


    // private List<Delegate> listOfActions = new List<Delegate>(){
    //     delegateMoveLeft
    // };



// nowy plik z przypisanym AI/Players stats z statystykami aktualnymi
// lista z funkcjami Actions, w minimax odwoływać się do danej pozycji tej listy, <-
// tam stany każdej możliwej akcji będą zapisane, i w danym stanie liczony ten score


// w minimaxie 7 forów po liście Actions,
   // public void Invoke (Action method){}


    private List<int> test = new List<int>{
                 0,
    1,      2,       3,        4,
  5,6,7,  8,9,10, 11,12,13, 14,15,16};



    void Awake(){
        //Debug.Log(actions);
        // for(int i=0;i<test.Count;i++)
        // {
        // Debug.Log(test[i]);
        // }
        //Action a = () => Actions.MoveLeft();
        //Invoke(Actions.MoveLeft());
        // listOfActions.Add(Invoke(() => Actions.MoveLeft()));
    }

    // private void test2(){
    //     Debug.Log("test");
    // }



    public int MinimaxFunction(int depth, int nodeIndex, bool isMax, int h){

        // 1. liczenie indexu listy (depth,height,nodeindex tutaj jakieś działanie)
        // 2. liczenie indexu rodzica
        // 3. wczytanie stanu rodzica -> punkt drugi
        // 4. wykonanie akcji zależnej od nodeIndex, if nodeIndex= 0 to coś, zmiana stanu z punktu 1
        // 5.

        // new dictionary without currently unavailable options
        //ListOfAvailableActions = AIActions.ListOfActions.Where(pair => pair.Value == true).ToDictionary(pair => pair.Key, pair => pair.Value);


        // foreach (var pair in ListOfAvailableActions)
        // {
        //     Debug.Log($"Klucz: {pair.Key}, Wartość: {pair.Value}");
        // }
        //Debug.Log(ListOfAvailableActions);

        if (depth == h){      
            score = Actions.AIStats.currentHealth-Actions.PlayerStats.currentHealth; // nwm czy on tutaj powinien sie update'ować
            //Debug.Log("Available moves for AI: "+ListOfAvailableActions);   //.count
            return score;
            // dodać że returnuje też akcje daną żeby potem mógł ją wykonać

            //return score[nodeIndex];
        }

        //if (czy akcja moze byc wykonana) jak moze byc wykoonana to wykonuje

        if(isMax){
            temp = int.MinValue;
            for (int i = 0; i < test.Count; i++) { //.count zmienić test na ActionsList czy cos
                // tutaj dać score outcome'u danej akcji (?)
                 // dodać że returnuje też akcje daną żeby potem mógł ją wykonać
                //Debug.Log(i);
                
                temp = Math.Max(temp, MinimaxFunction(depth+1,i,false,h));
            }
            return temp;

        }
        else{
            temp = int.MaxValue;
            for (int i = 0; i < ListOfAvailableActions; i++) { //. count
                // tutaj dać score outcome'u danej akcji (?)

                temp = Math.Min(temp, MinimaxFunction(depth+1,i,true,h));

            }
            return temp;
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

}