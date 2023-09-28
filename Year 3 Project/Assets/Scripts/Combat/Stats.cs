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
    // Mana of enemy
    [SerializeField]
    float MP;
    // Attack of enemy
    [SerializeField]
    float ATK;

    // Sets attack of enemy
    public void setType(EnemyGenerator.enemyType setType)
    {
        type = setType;
    }
    // Gets attack of enemy
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
        HP = health;
    }
    // Gets health of enemy
    public float getHP()
    {
        return HP;
    }
    // Sets mana of enemy
    public void setMP(float mana)
    {
        MP = mana;
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
