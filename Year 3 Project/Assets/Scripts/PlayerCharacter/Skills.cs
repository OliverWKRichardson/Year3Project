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
        skill1Name = "Light";
        skill2Name = "Heavy";
        skill3Name = "Heal";
        skill1cost = 0;
        skill2cost = 20;
        skill3cost = 50;
    }

    public String skill1Name; //Light
    public float skill1cost; // 0
    public void skill1(GameObject target)
    {
        Debug.Log(skill1Name+" Used By Player");
        // get player attack value
        float amount = player.GetComponent<Stats>().getATK();
        // damage enemy
        target.GetComponent<Stats>().Damage(amount);
    }

    public String skill2Name; // Heavy
    public float skill2cost; // 20
    public void skill2(GameObject target)
    {
        Debug.Log(skill2Name+" Used By Player");
        // get player attack value
        float amount = player.GetComponent<Stats>().getATK();
        float MULT = 2;
        // damage enemy
        target.GetComponent<Stats>().Damage(amount*MULT);
        // reduce player MP
        player.GetComponent<Stats>().spendMP(20);
    }

    public String skill3Name; // Heal
    public float skill3cost; // 50
    public void skill3(GameObject target)
    {
        Debug.Log(skill3Name+" Used By Player");
        // get player attack value
        float amount = player.GetComponent<Stats>().getATK();
        float MULT = 4;
        // heal player
        player.GetComponent<Stats>().Heal(amount*MULT);
        // reduce player MP
        player.GetComponent<Stats>().spendMP(50);
    }
}
