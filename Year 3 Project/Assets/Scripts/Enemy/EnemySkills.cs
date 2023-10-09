using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;

public class EnemySkills : MonoBehaviour
{
    private System.Action<GameObject> skill1;
    private System.Action<GameObject> skill2;
    private System.Action<GameObject> skill3;
   
    public void SetSkills(System.Action<GameObject> one, System.Action<GameObject> two,System.Action<GameObject> three)
    {
        skill1 = one;
        skill2 = two;
        skill3 = three;
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
        return Random.Range(1,4);
    }
}
