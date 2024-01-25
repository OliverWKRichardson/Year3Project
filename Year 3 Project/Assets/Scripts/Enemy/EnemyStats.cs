using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EnemyGenerator.enemyType;
using static CombatScreen.TurnType;
using System;
using UnityEditor;

public class EnemyStats : MonoBehaviour
{
    // Type of enemy
    public EnemyGenerator.enemyType type;
    // Speed of enemy
    public float SPD;
    // Health of enemy
    public float HP;
    // Max Health of enemy
    public float MaxHP;
    // Mana of enemy
    public float MP;
    // Max Mana of enemy
    public float MaxMP;
    // Attack of enemy
    public float ATK;
    // Enemy type (for tutorial only)
    public bool tutorialEnemy;

    // Sets MaxHP of enemy
    public void setMaxHP(float setMaxHP)
    {
        MaxHP = setMaxHP;
    }
    // Gets MaxHP of enemy
    public float getMaxHP()
    {
        return MaxHP;
    }
    // Sets MaxMP of enemy
    public void setMaxMP(float setMaxMP)
    {
        MaxMP = setMaxMP;
    }
    // Gets MaxMP of enemy
    public float getMaxMP()
    {
        return MaxMP;
    }
    // Sets type of enemy
    public void setType(EnemyGenerator.enemyType setType)
    {
        type = setType;
    }
    // Gets type of enemy
    public EnemyGenerator.enemyType getType()
    {
        return type;
    }
    // Sets speed of enemy
    public void setSPD(float speed)
    {
        SPD = speed;
    }
    // Gets speed of enemy
    public float getSPD()
    {
        return SPD;
    }
    // Sets health of enemy
    public void setHP(float health)
    {
        HP = Mathf.Clamp(health, 0, MaxHP);
    }
    // deal damage to self
    public void Damage(float amount)
    {
        // no negative damage
        if(amount < 0)
        {
            return;
        }
        // reduce hp by amount 
        HP = Mathf.Clamp(HP - amount, 0, MaxHP);
    }
    // heal self
    public void Heal(float amount)
    {
        if(amount < 0)
        {
            return;
        }
        HP = Mathf.Clamp(HP + amount, 0, MaxHP);
    }
    // Gets health of enemy
    public float getHP()
    {
        return HP;
    }
    // Sets mana of enemy
    public void setMP(float mana)
    {
        MP = Mathf.Clamp(mana, 0, MaxMP);
    }
    // Gets mana of enemy
    public float getMP()
    {
        return MP;
    }
    // Sets attack of enemy
    public void setATK(float attack)
    {
        ATK = attack;
    }
    // Gets attack of enemy
    public float getATK()
    {
        return ATK;
    }
    public bool getTutorialStatus()
    {
        return tutorialEnemy;
    }
    public void spendMP(float amount)
    {
        MP = Mathf.Clamp(MP - amount, 0, MaxMP);
    }
    public void regenMP()
    {
        // regen 5% mp
        MP = Mathf.Clamp(MP + (MaxMP/20), 0, MaxMP);
    }

    // Update is called once per frame
    void Update()
    {
        // WIP testing
        if(Input.GetKey(KeyCode.Q))
        {
            SPD = 100000;
            MaxMP = 100000;
            MaxHP = 100000;
            HP = 100000;
            MP = 100000;
            ATK = 100000;
        }
    }

    public List<Condition> conditions;
    public void Start()
    {
        conditions = new List<Condition>();
    }

    public void AddCondition(Condition add)
    {
        conditions.Add(add);
    }

    public void WipeConditions()
    {
        conditions.Clear();
    }

    public void ReduceConditions(CombatScreen.TurnType toReduceOn)
    {
        foreach(Condition condi in conditions)
        {
            if(condi.GetTurnTypeToReduceOn() == toReduceOn)
            {
                condi.ReduceTurnsLeft();
            }
            if(condi.GetTurnsLeft() == 0)
            {
                conditions.Remove(condi);
            }
        }
    }

    public bool HasCondition(String condiName)
    {
        foreach(Condition condi in conditions)
        {
            if(condi.GetName() == condiName)
            {
                return true;
            }
        }
        return false;
    }

    public float GetAmountTotal(String condiName)
    {
        float total = 0;
        foreach(Condition condi in conditions)
        {
            if(condi.GetName() == condiName)
            {
                total += condi.GetAmount();
            }
        }
        return total;
    }


}
