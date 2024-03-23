using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class Attacks : MonoBehaviour
{
    //[SerializeField] public int quickDamage;
    //[SerializeField] public int quickProcent;

    //[SerializeField] public int normalDamage;
    //[SerializeField] public int normalProcent;

    //[SerializeField] public int heavyDamage;
    //[SerializeField] public int heavyProcent;

    private GameObject playerObject;
    private GameObject aiObject;

    private GameStateManager gameState;

    [SerializeField] public List<int> quickDamages = new List<int>();
    [SerializeField] public List<int> normalDamages = new List<int>();
    [SerializeField] public List<int> heavyDamages = new List<int>();

    [SerializeField] public int quickThreshold;
    [SerializeField] public int heavyThreshold;

    [SerializeField] public int healValue;

    public int damage;
    public bool menu;

    //public int hitOrMiss;

    public bool turnflag; // true: playersTurn | false: AiTurn
    public bool endgame;

    public List<Attacks> listOfActions = new List<Attacks>();

    public List<Attacks> listOfPlayerActions = new List<Attacks>();
    public List<Attacks> listOfAIActions = new List<Attacks>();

    public TextMeshProUGUI console;

    [SerializeField] private endingScreen endingScreen;

    public virtual void ExecuteAction(GameObject target, GameState state)
    {
    }

    public class QuickAttackAction : Attacks
    {
        public override void ExecuteAction(GameObject target, GameState state)
        {
            QuickAttack(target, state);
            base.ExecuteAction(target, state);
        }
    }

    public class NormalAttackAction : Attacks
    {
        public override void ExecuteAction(GameObject target, GameState state)
        {
            NormalAttack(target, state);
            base.ExecuteAction(target, state);
        }
    }

    public class HeavyAttackAction : Attacks
    {
        public override void ExecuteAction(GameObject target, GameState state)
        {
            HeavyAttack(target, state);
            base.ExecuteAction(target, state);
        }
    }

    public class PotionAction : Attacks
    {
        public override void ExecuteAction(GameObject target, GameState state)
        {
            Potion(target, state);
            base.ExecuteAction(target, state);
        }
    }


    public void Start()
    {
        gameState = GameObjects.Instance.StateManager;
        playerObject = GameObjects.Instance.PlayerObject;
        aiObject = GameObjects.Instance.AiObject;
        
        ChangeTurn();

        PotionAction potionActionObj = new PotionAction();
        potionActionObj.healValue = healValue;

        QuickAttackAction quickAttackObj = new QuickAttackAction();
        quickAttackObj.quickDamages = quickDamages;
        //quickAttackObj.quickProcent = quickProcent;

        NormalAttackAction normalAttackObj = new NormalAttackAction();
        normalAttackObj.normalDamages = normalDamages;
        //normalAttackObj.normalDamage = normalDamage;

        HeavyAttackAction heavyAttackObj = new HeavyAttackAction();
        heavyAttackObj.heavyDamages = heavyDamages;
        //heavyAttackObj.heavyProcent = heavyProcent;




        listOfActions.Add(quickAttackObj);
        listOfActions.Add(normalAttackObj);
        listOfActions.Add(heavyAttackObj);
        listOfActions.Add(potionActionObj);


        listOfPlayerActions.Add(quickAttackObj);
        listOfPlayerActions.Add(normalAttackObj);
        listOfPlayerActions.Add(heavyAttackObj);
        listOfPlayerActions.Add(potionActionObj);

        listOfAIActions.Add(quickAttackObj);
        listOfAIActions.Add(normalAttackObj);
        listOfAIActions.Add(heavyAttackObj);
        listOfAIActions.Add(potionActionObj);
    }

    public void Attack(int damage, GameObject target, GameState state)
    {
        if(target.gameObject.TryGetComponent(out IDamageable damageableObject))
        {
            damageableObject.Damage(damage,state);
        }
    }

    public void Potion(GameObject target, GameState state)
    {
        if(target == GameObjects.Instance.AiObject)
        {
            if(GameObjects.Instance.PlayerObject.TryGetComponent(out IDamageable damageableObject))
            {
                damageableObject.Heal(GameObjects.Instance.Attacks.healValue, state);
            }
        }
        if (target == GameObjects.Instance.PlayerObject)
        {
            if (GameObjects.Instance.AiObject.TryGetComponent(out IDamageable damageableObject))
            {
                damageableObject.Heal(GameObjects.Instance.Attacks.healValue, state);
            }
        }
        if (state == GameObjects.Instance.StateManager.currentState)
        {
            if (target == GameObjects.Instance.AiObject)
            {
                GameObjects.Instance.Attacks.console.SetText("Player used healing potion!");
            }
            if (target == GameObjects.Instance.PlayerObject)
            {
                GameObjects.Instance.Attacks.console.SetText("AI used healing potion!");
            }
        }

    }




    public void QuickAttack(GameObject target, GameState state)
    {
        damage = 10;
        if(target == GameObjects.Instance.AiObject)
        {
            if (state.aiHealth >= GameObjects.Instance.Attacks.quickThreshold)
            {
                damage = quickDamages[1];
            }
            else
            {
                damage = quickDamages[0];
            }
        }
        if (target == GameObjects.Instance.PlayerObject)
        {
            if (state.playerHealth >= GameObjects.Instance.Attacks.quickThreshold)
            {
                damage = quickDamages[1];
            }
            else
            {
                damage = quickDamages[0];
            }
        }
        // Debug.Log("Quick attack target:" + target);
        if (state == GameObjects.Instance.StateManager.currentState)
        {
            if (target == GameObjects.Instance.PlayerObject)
            {
                if (state.playerHealth >= GameObjects.Instance.Attacks.quickThreshold)
                {
                    GameObjects.Instance.Attacks.console.SetText("AI used Quick Attack!\nVery Effective!");
                }
                else
                {
                    GameObjects.Instance.Attacks.console.SetText("AI used Quick Attack!\nNot Effective!");
                }
            }
            if (target == GameObjects.Instance.AiObject)
            {
                if (state.aiHealth >= GameObjects.Instance.Attacks.quickThreshold)
                {
                    GameObjects.Instance.Attacks.console.SetText("Player used Quick Attack!\nVery Effective!");
                }
                else
                {
                    GameObjects.Instance.Attacks.console.SetText("Player used Quick Attack!\nNot Effective!");
                }
            }
        }
            Attack(damage, target, state);
    }

    public void NormalAttack(GameObject target, GameState state)
    {
        if (target == GameObjects.Instance.AiObject)
        {
            if (state.aiHealth < GameObjects.Instance.Attacks.quickThreshold && state.aiHealth > GameObjects.Instance.Attacks.heavyThreshold)
            {
                damage = normalDamages[1];
            }
            else
            {
                damage = normalDamages[0];
            }
        }
        if (target == GameObjects.Instance.PlayerObject)
        {
            if (state.playerHealth < GameObjects.Instance.Attacks.quickThreshold && state.playerHealth > GameObjects.Instance.Attacks.heavyThreshold)
            {
                damage = normalDamages[1];
            }
            else
            {
                damage = normalDamages[0];
            }
        }
        //Debug.Log("Normal attack target:" + target);
        if (state == GameObjects.Instance.StateManager.currentState)
        {
            if (target == GameObjects.Instance.PlayerObject)
            {
                if (state.playerHealth < GameObjects.Instance.Attacks.quickThreshold && state.playerHealth > GameObjects.Instance.Attacks.heavyThreshold)
                {
                    GameObjects.Instance.Attacks.console.SetText("AI used Normal Attack!\nVery Effective!");
                }
                else
                {
                    GameObjects.Instance.Attacks.console.SetText("AI used Normal Attack!\nNot Effective!");
                }
            }
            if (target == GameObjects.Instance.AiObject)
            {
                if (state.aiHealth < GameObjects.Instance.Attacks.quickThreshold && state.aiHealth > GameObjects.Instance.Attacks.heavyThreshold)
                {
                    GameObjects.Instance.Attacks.console.SetText("Player used Normal Attack!\nVery Effective!");
                }
                else
                {
                    GameObjects.Instance.Attacks.console.SetText("Player used Normal Attack!\nNot Effective!");
                }
            }
        }
        Attack(damage, target, state);
    }
    public void HeavyAttack(GameObject target, GameState state)
    {
        if (target == GameObjects.Instance.AiObject)
        {
            if (state.aiHealth <= GameObjects.Instance.Attacks.heavyThreshold)
            {
                damage = heavyDamages[1];
            }
            else
            {
                damage = heavyDamages[0];
            }
        }
        if (target == GameObjects.Instance.PlayerObject)
        {
            if (state.playerHealth <= GameObjects.Instance.Attacks.heavyThreshold)
            {
                damage = heavyDamages[1];
            }
            else
            {
                damage = heavyDamages[0];
            }
        }
        //Debug.Log("Heavy attack target:" + target);
        if (state == GameObjects.Instance.StateManager.currentState)
        {
            if (target == GameObjects.Instance.PlayerObject)
            {
                if (state.playerHealth <= GameObjects.Instance.Attacks.heavyThreshold)
                {
                    GameObjects.Instance.Attacks.console.SetText("AI used Heavy Attack!\nVery Effective!");
                }
                else
                {
                    GameObjects.Instance.Attacks.console.SetText("AI used Heavy Attack!\nNot Effective!");
                }
            }
            if (target == GameObjects.Instance.AiObject)
            {
                if (state.aiHealth <= GameObjects.Instance.Attacks.heavyThreshold)
                {
                    GameObjects.Instance.Attacks.console.SetText("Player used Heavy Attack!\nVery Effective!");
                }
                else
                {
                    GameObjects.Instance.Attacks.console.SetText("Player used Heavy Attack!\nNot Effective!");
                }
            }
        }
        Attack(damage, target, state);
    }



    public void ChangeTurn()
    {
        turnflag = !turnflag;
    }

    public void EndGame(GameObject loser, GameState state)
    {
        if(state == gameState.currentState)
        {
            if(loser == GameObjects.Instance.PlayerObject)
            {
                GameObjects.Instance.StateManager.currentState.playerHealth = 0;
            }

            if (loser == GameObjects.Instance.AiObject)
            {
                GameObjects.Instance.StateManager.currentState.aiHealth = 0;
            }
            GameObjects.Instance.Attacks.console.SetText(loser.name + " Lost!\n Fatality");
            endgame = true;
            endingScreen.endingScreenObject.active = true;
        }
    }

}
