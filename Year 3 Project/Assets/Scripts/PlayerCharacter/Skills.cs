using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Skills : MonoBehaviour
{
    GameObject player;
    public String skill1Name;
    public float skill1cost;
    public System.Action<GameObject> skill1;
    public String skill2Name;
    public float skill2cost;
    public System.Action<GameObject> skill2;
    public String skill3Name;
    public float skill3cost;
    public System.Action<GameObject> skill3;
    void Start()
    {
        player = GameObject.Find("PlayerCharacter");
        skill1Name = "Worm";
        skill1cost = 0;
        skill1 = LightAttack;
        skill2Name = "Trojan";
        skill2cost = 20;
        skill2 = HeavyAttack;
        skill3Name = "Revert";
        skill3cost = 50;
        skill3 = SelfHeal;
    }
    
    public void SelfHeal(GameObject target)
    {
        Debug.Log("Self Heal Used By Player");
        // get player attack value
        float amount = player.GetComponent<PlayerStats>().getATK();
        float MULT = 4;
        // heal player
        player.GetComponent<PlayerStats>().HealC(amount*MULT);
        player.GetComponent<PlayerStats>().HealI(amount*MULT);
        player.GetComponent<PlayerStats>().HealA(amount*MULT);
        // reduce player MP
        player.GetComponent<PlayerStats>().spendMP(50);
    }


    public void DoT(GameObject target)
    {
        Debug.Log("Player Used DoT Attack On "+ target.name);
        Condition DamageOverTime = new Condition("DoT", 5, CombatScreen.TurnType.enemyTurn, 10.0f);
        target.GetComponent<EnemyStats>().AddCondition(DamageOverTime);
    }

    public void HeavyAttack(GameObject target)
    {
        Debug.Log("Heavy Attack Used By Player");
        // get player attack value
        float amount = player.GetComponent<PlayerStats>().getATK();
        float MULT = 2;
        // damage enemy
        target.GetComponent<EnemyStats>().Damage(amount*MULT);
        // reduce player MP
        player.GetComponent<PlayerStats>().spendMP(20);
    }

    public void LightAttack(GameObject target)
    {
        Debug.Log("Light Attack Used By Player");
        // get player attack value
        float amount = player.GetComponent<PlayerStats>().getATK();
        // damage enemy
        target.GetComponent<EnemyStats>().Damage(amount);
    }
}
