using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CombatScreen.TurnType;
using System;
using UnityEditor.UI;

public class EnemyGenerator : MonoBehaviour
{
    // Enemy Type
    public enum enemyType{none, light, heavy}
    private int enemyTypeCount = Enum.GetNames(typeof(enemyType)).Length;
    // Enemy class
    public GameObject enemy;

    //enemy
    GameObject hostile;

    // force type of enemy spawned
    public enemyType forcetype;

    // Start is called before the first frame update
    void Start()
    {
        createEnemy();
    }

    void createEnemy()
    {
        Transform pos = gameObject.transform;
        hostile = Instantiate(enemy, pos); // Add Vector2(x, y) for the position of the newly generated enemy

        enemyType enemyType = (enemyType)UnityEngine.Random.Range(1, enemyTypeCount); // no need to subtract 1 from upper bound as the none type does this for us
        if(forcetype != enemyType.none)
        {
            enemyType = forcetype;
        }

        switch(enemyType) // every enemy needs a 0 cost skill for when they run out of mana
        {
            case enemyType.light:
                hostile.GetComponent<EnemyStats>().setType(enemyType.light);
                hostile.GetComponent<EnemyStats>().setSPD(UnityEngine.Random.Range(5, 11));
                hostile.GetComponent<EnemyStats>().setMaxHP(UnityEngine.Random.Range(400, 600));
                hostile.GetComponent<EnemyStats>().setHP(hostile.GetComponent<EnemyStats>().getMaxHP());
                hostile.GetComponent<EnemyStats>().setMaxMP(UnityEngine.Random.Range(100, 150));
                hostile.GetComponent<EnemyStats>().setMP(hostile.GetComponent<EnemyStats>().getMaxMP());
                hostile.GetComponent<EnemyStats>().setATK(UnityEngine.Random.Range(50, 100));
                hostile.GetComponent<EnemySkills>().SetSkills(LightAttack, LightAttackCost, DoTA, DoTACost, DoTA, DoTACost);
                break;
            case enemyType.heavy:
                hostile.GetComponent<EnemyStats>().setType(enemyType.heavy);
                hostile.GetComponent<EnemyStats>().setSPD(UnityEngine.Random.Range(1, 5));
                hostile.GetComponent<EnemyStats>().setMaxHP(UnityEngine.Random.Range(750, 1000));
                hostile.GetComponent<EnemyStats>().setHP(hostile.GetComponent<EnemyStats>().getMaxHP());
                hostile.GetComponent<EnemyStats>().setMaxMP(UnityEngine.Random.Range(100, 150));
                hostile.GetComponent<EnemyStats>().setMP(hostile.GetComponent<EnemyStats>().getMaxMP());
                hostile.GetComponent<EnemyStats>().setATK(UnityEngine.Random.Range(80, 180));
                hostile.GetComponent<EnemySkills>().SetSkills(LightAttack, LightAttackCost, HeavyAttack, HeavyAttackCost, HeavyAttack, HeavyAttackCost);
                break;
        }

    }


    // Template Skills
    public void DoTA(GameObject target)
    {
        Debug.Log("Enemy Used DoTA Attack On "+ target.name);
        Condition DDoS = new Condition("DoTA", 5, CombatScreen.TurnType.playerTurn, 10.0f);
        target.GetComponent<PlayerStats>().AddCondition(DDoS);
        hostile.GetComponent<EnemyStats>().spendMP(50);
    }
    private int DoTACost = 50;
    public void DoTI(GameObject target)
    {
        Debug.Log("Enemy Used DoTI Attack On "+ target.name);
        Condition FileDeletionWorm = new Condition("DoTI", 5, CombatScreen.TurnType.playerTurn, 10.0f);
        target.GetComponent<PlayerStats>().AddCondition(FileDeletionWorm);
        hostile.GetComponent<EnemyStats>().spendMP(50);
    }
    private int DoTICost = 50;
    public void DoTC(GameObject target)
    {
        Debug.Log("Enemy Used DoTA Attack On "+ target.name);
        Condition DownloadingPersonalData = new Condition("DoTC", 5, CombatScreen.TurnType.playerTurn, 10.0f);
        target.GetComponent<PlayerStats>().AddCondition(DownloadingPersonalData);
        hostile.GetComponent<EnemyStats>().spendMP(50);
    }
    private int DoTCCost = 50;

    public void HeavyAttack(GameObject target)
    {
        Debug.Log("Enemy Used Heavy Attack On "+ target.name);
        hostile.GetComponent<EnemyStats>().spendMP(100);
        float amount = hostile.GetComponent<EnemyStats>().getATK();
        float MULT = 2;
        target.GetComponent<PlayerStats>().DamageC(amount*MULT);
        target.GetComponent<PlayerStats>().DamageI(amount*MULT);
        target.GetComponent<PlayerStats>().DamageA(amount*MULT);
    }
    private int HeavyAttackCost = 100;
    public void LightAttack(GameObject target)
    {
        Debug.Log("Enemy Used Light Attack On "+ target.name);
        float amount = hostile.GetComponent<EnemyStats>().getATK();
        target.GetComponent<PlayerStats>().DamageC(amount);
        target.GetComponent<PlayerStats>().DamageI(amount);
        target.GetComponent<PlayerStats>().DamageA(amount);
    }
    private int LightAttackCost = 0;
}

