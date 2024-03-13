using System.Collections;
using System.Collections.Generic;
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

    [SerializeField] public GameStateManager gameState;

    [SerializeField] public List<int> quickDamages = new List<int>();
    [SerializeField] public List<int> normalDamages = new List<int>();
    [SerializeField] public List<int> heavyDamages = new List<int>();

    [SerializeField] public int quickThreshold;
    [SerializeField] public int heavyThreshold;

    public int damage;

    //public int hitOrMiss;

    public bool turnflag; // true: playersTurn | false: AiTurn
    public bool endgame;

    public List<Attacks> listOfActions = new List<Attacks>();

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

    public void Awake()
    {
        playerObject = GameObjects.Instance.PlayerObject;
        aiObject = GameObjects.Instance.AiObject;
        
        ChangeTurn();

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
    }

    public void Attack(int damage, GameObject target, GameState state)
    {
        if(target.gameObject.TryGetComponent(out IDamageable damageableObject))
        {
            damageableObject.Damage(damage,state);
        }
    }

    public void QuickAttack(GameObject target, GameState state)
    {
        Debug.Log(target);
        damage = 10;
        if(target == GameObjects.Instance.AiObject)
        {
            if (state.aiHealth >= quickThreshold)
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
            Debug.Log(".");
            if (state.playerHealth >= quickThreshold)
            {
                damage = quickDamages[1];
            }
            else
            {
                damage = quickDamages[0];
            }
        }
        Debug.Log("Quick attack target:" + target);
        Attack(damage, target, state);
    }

    public void NormalAttack(GameObject target, GameState state)
    {
        if (target == GameObjects.Instance.AiObject)
        {
            if (state.aiHealth < quickThreshold && state.aiHealth > heavyThreshold)
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
            if (state.playerHealth < quickThreshold && state.playerHealth > heavyThreshold)
            {
                damage = normalDamages[1];
            }
            else
            {
                damage = normalDamages[0];
            }
        }
        Debug.Log("Normal attack target:" + target);
        Attack(damage, target, state);
    }
    public void HeavyAttack(GameObject target, GameState state)
    {
        if (target == GameObjects.Instance.AiObject)
        {
            if (state.aiHealth <= heavyThreshold)
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
            if (state.playerHealth <= heavyThreshold)
            {
                damage = heavyDamages[1];
            }
            else
            {
                damage = heavyDamages[0];
            }
        }
        Debug.Log("Heavy attack target:" + target);
        Attack(damage, target, state);
    }

    public void ChangeTurn()
    {
        turnflag = !turnflag;
    }

    public void EndGame(GameObject loser, GameState state)
    {
        Debug.Log(loser.name + " lost!");
        if(state == gameState.currentState)
        {
            endgame = true;
        }
    }

}
