using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CombatScreen.TurnType;
using System;

public class BossGenerator : MonoBehaviour
{
    // Enemy class
    public GameObject boss;

    //enemy
    GameObject hostile;

    // Start is called before the first frame update
    void Start()
    {
        createBoss();
    }

    void createBoss()
    {
        Transform pos = gameObject.transform;
        hostile = Instantiate(boss); // Add Vector2(x, y) for the position of the newly generated boss
        hostile.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -1);
        hostile.GetComponent<EnemyStats>().setBoss();
        hostile.GetComponent<EnemyStats>().setSPD(UnityEngine.Random.Range(11, 15));
        hostile.GetComponent<EnemyStats>().setMaxHP(UnityEngine.Random.Range(800, 1000));
        hostile.GetComponent<EnemyStats>().setHP(hostile.GetComponent<EnemyStats>().getMaxHP());
        hostile.GetComponent<EnemyStats>().setMaxMP(UnityEngine.Random.Range(200, 250));
        hostile.GetComponent<EnemyStats>().setMP(hostile.GetComponent<EnemyStats>().getMaxMP());
        hostile.GetComponent<EnemyStats>().setATK(UnityEngine.Random.Range(120, 150));
        hostile.GetComponent<EnemySkills>().SetSkills("Steal Data", LightAttack, LightAttackCost,"DDoS" , DoTA, DoTACost,"Corrupt Files", HeavyAttack, HeavyAttackCost);
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

