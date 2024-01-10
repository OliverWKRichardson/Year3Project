using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;
using System;

public class EnemySkills : MonoBehaviour
{
    private System.Action<GameObject> skill1;
    private System.Action<GameObject> skill2;
    private System.Action<GameObject> skill3;
    private int Skill1Cost;
    private int Skill2Cost;
    private int Skill3Cost;
    
    public String skill1Name;
    
    public String skill2Name;
    
    public String skill3Name;
   
    public void SetSkills(String name1, System.Action<GameObject> one, int oneCost, String name2, System.Action<GameObject> two, int twoCost, String name3, System.Action<GameObject> three, int threeCost)
    {
        skill1Name = name1;
        skill2Name = name2;
        skill3Name = name3;
        skill1 = one;
        skill2 = two;
        skill3 = three;
        Skill1Cost = oneCost;
        Skill2Cost = twoCost;
        Skill3Cost = threeCost;
    }

    public void UseSkill1(GameObject target)
    {
        skill1(target);
    }
    public void UseSkill2(GameObject target)
    {
        skill2(target);
    }
    public void UseSkill3(GameObject target)
    {
        skill3(target);
    }

    public int DecideMove()
    {
        // can be tweaked to change likely hood of different moves
        // return the following to trigger certain skills: 
        // 1 = skill1, 2 = skill2, 3 = skill3 
        int picked = 1;
        bool accept = false;
        while(accept == false)
        {
            // if only 1 possible skill to use
            if(GetComponent<EnemyStats>().getMP() < Skill2Cost && GetComponent<EnemyStats>().getMP() < Skill3Cost)
            {
                picked = 1;
                accept = true;
            }
            else if(GetComponent<EnemyStats>().getMP() < Skill1Cost && GetComponent<EnemyStats>().getMP() < Skill3Cost)
            {
                picked = 2;
                accept = true;
            }
            else if(GetComponent<EnemyStats>().getMP() < Skill1Cost && GetComponent<EnemyStats>().getMP() < Skill2Cost)
            {
                picked = 3;
                accept = true;
            }
            else
            {
                // if multiple possible skills to use
                picked = UnityEngine.Random.Range(1,4);
                switch (picked)
                {
                    case 1:
                        if(Skill1Cost <= GetComponent<EnemyStats>().getMP())
                        {
                            accept = true;
                        }
                        break;
                    case 2:
                        if(Skill2Cost <= GetComponent<EnemyStats>().getMP())
                        {
                            accept = true;
                        }
                        break;
                    case 3:
                        if(Skill3Cost <= GetComponent<EnemyStats>().getMP())
                        {
                            accept = true;
                        }
                        break;
                }
            }
        }
        return picked;
    }
}
