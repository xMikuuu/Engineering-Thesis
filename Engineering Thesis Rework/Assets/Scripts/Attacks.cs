using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacks : MonoBehaviour
{
    [SerializeField] public int quickDamage;
    [SerializeField] public int quickProcent;

    [SerializeField] public int normalDamage;
    [SerializeField] public int normalProcent;

    [SerializeField] public int heavyDamage;
    [SerializeField] public int heavyProcent;

    [SerializeField] public GameObject playerObject;
    [SerializeField] public GameObject aiObject;

    public int hitOrMiss;

    public bool turnflag; // true: playersTurn | false: AiTurn
    public bool endgame;

    public List<Attacks> listOfActions = new List<Attacks>();

    public virtual void ExecuteAction(GameObject target)
    {
    }

    public class QuickAttackAction : Attacks
    {
        public override void ExecuteAction(GameObject target)
        {
            QuickAttack(target);
            base.ExecuteAction(target);
        }
    }

    public class NormalAttackAction : Attacks
    {
        public override void ExecuteAction(GameObject target)
        {
            NormalAttack(target);
            base.ExecuteAction(target);
        }
    }

    public class HeavyAttackAction : Attacks
    {
        public override void ExecuteAction(GameObject target)
        {
            HeavyAttack(target);
            base.ExecuteAction(target);
        }
    }

    public void Awake()
    {
        ChangeTurn();

        QuickAttackAction quickAttackObj = new QuickAttackAction();
        quickAttackObj.quickDamage = quickDamage;
        quickAttackObj.quickProcent = quickProcent;

        NormalAttackAction normalAttackObj = new NormalAttackAction();
        normalAttackObj.normalDamage = normalDamage;
        normalAttackObj.normalDamage = normalDamage;

        HeavyAttackAction heavyAttackObj = new HeavyAttackAction();
        heavyAttackObj.heavyDamage = heavyDamage;
        heavyAttackObj.heavyProcent = heavyProcent;

        listOfActions.Add(quickAttackObj);
        listOfActions.Add(normalAttackObj);
        listOfActions.Add(heavyAttackObj);
    }

    public void Attack(int damage, int procent, GameObject target)
    {
        hitOrMiss = Random.Range(1, 101);
        if (hitOrMiss <= procent)
        {
            if(target.gameObject.TryGetComponent(out IDamageable damageableObject))
            {
                damageableObject.Damage(damage);
            }
        }
        else
        {
            Debug.Log("Missed");
        }
    }

    public void QuickAttack(GameObject target)
    {
        Debug.Log("Quick attack target:" + target);
        Attack(quickDamage, quickProcent, target);
    }

    public void NormalAttack(GameObject target)
    {
        Debug.Log("Normal attack target:" + target);
        Attack(normalDamage, normalProcent, target);
    }
    public void HeavyAttack(GameObject target)
    {
        Debug.Log("Heavy attack target:" + target);
        Attack(heavyDamage, heavyProcent, target);
    }

    public void ChangeTurn()
    {
        turnflag = !turnflag;
    }

    public void EndGame(GameObject loser)
    {
        Debug.Log(loser.name + " lost!");
        endgame = true;
    }

}
