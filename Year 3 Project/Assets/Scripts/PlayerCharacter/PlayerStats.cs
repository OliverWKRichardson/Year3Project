using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EnemyGenerator.enemyType;

public class PlayerStats : MonoBehaviour
{
    // Type of enemy
    public EnemyGenerator.enemyType type;
    // Speed of enemy
    public float SPD;
    // Health of enemy
    public float C;
    public float I;
    public float A;
    // Max Health of enemy
    public float MaxC;
    public float MaxI;
    public float MaxA;
    // Mana of enemy
    public float MP;
    // Max Mana of enemy
    public float MaxMP;
    // Attack of enemy
    public float ATK;

    // Sets MaxHP of enemy
    public void setMaxC(float setMaxC)
    {
        MaxC = setMaxC;
    }
    // Gets MaxHP of enemy
    public float getMaxC()
    {
        return MaxC;
    }
    // Sets MaxHP of enemy
    public void setMaxI(float setMaxI)
    {
        MaxI = setMaxI;
    }
    // Gets MaxHP of enemy
    public float getMaxI()
    {
        return MaxI;
    }
    // Sets MaxHP of enemy
    public void setMaxA(float setMaxA)
    {
        MaxA = setMaxA;
    }
    // Gets MaxHP of enemy
    public float getMaxA()
    {
        return MaxA;
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
    public void setC(float health)
    {
        C = Mathf.Clamp(health, 0, MaxC);
    }
    // Sets health of enemy
    public void setI(float health)
    {
        I = Mathf.Clamp(health, 0, MaxI);
    }
    // Sets health of enemy
    public void setA(float health)
    {
        A = Mathf.Clamp(health, 0, MaxA);
    }
    // deal damage to self
    public void DamageC(float amount)
    {
        // no negative damage
        if(amount < 0)
        {
            return;
        }
        // reduce hp by amount 
        C = Mathf.Clamp(C - amount, 0, MaxC);
    }
    public void DamageI(float amount)
    {
        // no negative damage
        if(amount < 0)
        {
            return;
        }
        // reduce hp by amount 
        I = Mathf.Clamp(I - amount, 0, MaxI);
    }
    public void DamageA(float amount)
    {
        // no negative damage
        if(amount < 0)
        {
            return;
        }
        // reduce hp by amount 
        A = Mathf.Clamp(A - amount, 0, MaxA);
    }   
    // heal self
    public void HealC(float amount)
    {
        if(amount < 0)
        {
            return;
        }
        C = Mathf.Clamp(C + amount, 0, MaxC);
    }
    public void HealI(float amount)
    {
        if(amount < 0)
        {
            return;
        }
        I = Mathf.Clamp(I + amount, 0, MaxI);
    }
    public void HealA(float amount)
    {
        if(amount < 0)
        {
            return;
        }
        A = Mathf.Clamp(A + amount, 0, MaxA);
    }
    // Gets health of enemy
    public float getC()
    {
        return C;
    }
    public float getI()
    {
        return I;
    }
    public float getA()
    {
        return A;
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
    public void spendMP(float amount)
    {
        MP = Mathf.Clamp(MP - amount, 0, MaxMP);
    }
    public void regenMP()
    {
        // regen 5% mp
        MP = Mathf.Clamp(MP + (MaxMP/20), 0, MaxMP);
    }
}
