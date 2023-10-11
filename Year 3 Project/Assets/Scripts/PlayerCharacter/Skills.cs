using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Skills : MonoBehaviour
{
    GameObject player;
    void Start()
    {
        player = GameObject.Find("PlayerCharacter");
        skill1Name = "Worm";
        skill2Name = "Trojan";
        skill3Name = "Revert";
        skill1cost = 0;
        skill2cost = 20;
        skill3cost = 50;
    }

    public String skill1Name; //worm
    public float skill1cost; // 0
    public void skill1(GameObject target)
    {
        Debug.Log(skill1Name+" Used By Player");
        // get player attack value
        float amount = player.GetComponent<PlayerStats>().getATK();
        // damage enemy
        target.GetComponent<EnemyStats>().Damage(amount);
    }

    public String skill2Name; // trojan
    public float skill2cost; // 20
    public void skill2(GameObject target)
    {
        Debug.Log(skill2Name+" Used By Player");
        // get player attack value
        float amount = player.GetComponent<PlayerStats>().getATK();
        float MULT = 2;
        // damage enemy
        target.GetComponent<EnemyStats>().Damage(amount*MULT);
        // reduce player MP
        player.GetComponent<PlayerStats>().spendMP(20);
    }

    public String skill3Name; // revert
    public float skill3cost; // 50
    public void skill3(GameObject target)
    {
        Debug.Log(skill3Name+" Used By Player");
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
}
