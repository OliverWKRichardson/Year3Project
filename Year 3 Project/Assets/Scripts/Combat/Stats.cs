using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EnemyGenerator.enemyType;

public class Stats : MonoBehaviour
{
    // Type of enemy
    [SerializeField]
    EnemyGenerator.enemyType type;
    // Speed of enemy
    [SerializeField]
    float SPD;
    // Health of enemy
    [SerializeField]
    float HP;
    // Max Health of enemy
    [SerializeField]
    float MaxHP;
    // Mana of enemy
    [SerializeField]
    float MP;
    // Max Mana of enemy
    [SerializeField]
    float MaxMP;
    // Attack of enemy
    [SerializeField]
    float ATK;

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

}
