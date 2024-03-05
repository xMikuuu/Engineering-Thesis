using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class Minimax : MonoBehaviour
{
    [SerializeField] int depth; // how many moves in future should algorithm check
    [SerializeField] Attacks attacks;


    // difficulty levels:
    // easy: ai moves randomly
    // medium: 2 moves ahead
    // hard: 5 moves ahead


    private int temp;
    public int score = 0;


    // nowy plik z przypisanym AI/Players stats z statystykami aktualnymi
    // lista z funkcjami Actions, w minimax odwo³ywaæ siê do danej pozycji tej listy, <-
    // tam stany ka¿dej mo¿liwej akcji bêd¹ zapisane, i w danym stanie liczony ten score


    // w minimaxie 7 forów po liœcie Actions,
    // public void Invoke (Action method){}


    private List<int> test = new List<int>{
                 0,
    1,      2,       3,        4,
  5,6,7,  8,9,10, 11,12,13, 14,15,16};


    private int playerHealthtmp;
    private int aiHealthtmp;


    //private void Start(){
    //    Debug.Log(Actions.listOfActions.Count);
    //}


    //private void Awake(){
    //    foreach (Actions hej in Actions.listOfActions)
    //    {
    //        //hej.ExecuteAction();
    //        Debug.Log(hej);
    //    }

    //    //Debug.Log(actions);
    //    // for(int i=0;i<test.Count;i++)
    //    // {
    //    // Debug.Log(test[i]);
    //    // }
    //    //Action a = () => Actions.MoveLeft();
    //    //Invoke(Actions.MoveLeft());
    //    // listOfActions.Add(Invoke(() => Actions.MoveLeft()));
    //}

    // private void test2(){
    //     Debug.Log("test");
    // }



    public int MinimaxFunction(int depth, int nodeIndex, bool isMax, int h, GameState gameState)
    {

        // 1. liczenie indexu listy (depth,height,nodeindex tutaj jakieœ dzia³anie)
        // 2. liczenie indexu rodzica
        // 3. wczytanie stanu rodzica -> punkt drugi
        // 4. wykonanie akcji zale¿nej od nodeIndex, if nodeIndex= 0 to coœ, zmiana stanu z punktu 1
        // 5.
        Debug.Log("Minimax Start");

        Debug.Log("Initial state score:" + gameState.score);

        if (depth == h)
        {
            //score = Actions.AIStats.currentHealth - Actions.PlayerStats.currentHealth; // nwm czy on tutaj powinien sie update'owaæ
            //Debug.Log("Available moves for AI: "+ListOfAvailableActions);   //.count
            return score;
            // dodaæ ¿e returnuje te¿ akcje dan¹ ¿eby potem móg³ j¹ wykonaæ

            //return score[nodeIndex];
        }

        //if (czy akcja moze byc wykonana) jak moze byc wykoonana to wykonuje ???

        //if (isMax)
        //{
        //    temp = int.MinValue;

        //    for (int i = 0; i < attacks.listOfActions.Count; i++)
        //    { //.count zmieniæ test na ActionsList czy cos
        //      //Actions actions = gameState.MemberwiseClone(); //.clone sklonowaæ wszystko do nowego obiektu poprzez metode now¹ najlepiej


        //        //Actions actions = new Actions();
        //        //actions.listOfActions[i].ExecuteAction();
        //        //score = ....

        //        // tutaj daæ score outcome'u danej akcji (?)
        //        // dodaæ ¿e returnuje te¿ akcje dan¹ ¿eby potem móg³ j¹ wykonaæ
        //        //Debug.Log(i);

        //        //temp = Math.Max(temp, MinimaxFunction(depth+1,i,false,h,actions));
        //    }
        //    return temp;
        //}
        else
        {
            //temp = int.MaxValue;
            //for (int i = 0; i < ListOfAvailableActions; i++) { //. count
            //    // tutaj daæ score outcome'u danej akcji (?)

            //    temp = Math.Min(temp, MinimaxFunction(depth+1,i,true,h));
            //}
            return temp;
        }
    }


    private void CopyActionClass()
    {
        string xd;
    }


    // chosenAction = 0; // change it if any one the actions could be below 0 somehow
    // for (int i = 0; i < ListOfAvailableActions.Count; i++) {
    //     // Math.Max(chosenAction,minimax(depth+1,i,false/true,scores,h);
    //     chosenAction = Math.Max(chosenAction,hejka[i]);
    // }

    // Debug.Log(chosenAction);

    // foreach (var pair in ListOfAvailableActions)
    // {
    //     Debug.Log($"Klucz: {pair.Key}, Wartoœæ: {pair.Value}");
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