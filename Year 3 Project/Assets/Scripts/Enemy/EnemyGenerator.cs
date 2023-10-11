using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    // Enemy Type
    public enum enemyType{none, light, heavy}

    // Enemy class
    public GameObject enemy;

    // force type of enemy spawned
    public enemyType forcetype;

    // Start is called before the first frame update
    void Start()
    {
        createEnemy();
    }

    void createEnemy()
    {
        Transform pos = gameObject.transform;
        GameObject hostile = Instantiate(enemy, pos); // Add Vector2(x, y) for the position of the newly generated enemy

        enemyType enemyType = (enemyType)Random.Range(1, 3);
        if(forcetype != enemyType.none)
        {
            enemyType = forcetype;
        }

        switch(enemyType)
        {
            case enemyType.light:
                hostile.GetComponent<EnemyStats>().setType(enemyType.light);
                hostile.GetComponent<EnemyStats>().setSPD(Random.Range(5, 11));
                hostile.GetComponent<EnemyStats>().setMaxHP(Random.Range(400, 600));
                hostile.GetComponent<EnemyStats>().setHP(hostile.GetComponent<EnemyStats>().getMaxHP());
                hostile.GetComponent<EnemyStats>().setMaxMP(Random.Range(100, 150));
                hostile.GetComponent<EnemyStats>().setMP(hostile.GetComponent<EnemyStats>().getMaxMP());
                hostile.GetComponent<EnemyStats>().setATK(Random.Range(50, 100));
                hostile.GetComponent<EnemySkills>().SetSkills(LightAttack, LightAttack, LightAttack);
                break;
            case enemyType.heavy:
                hostile.GetComponent<EnemyStats>().setType(enemyType.heavy);
                hostile.GetComponent<EnemyStats>().setSPD(Random.Range(1, 5));
                hostile.GetComponent<EnemyStats>().setMaxHP(Random.Range(750, 1000));
                hostile.GetComponent<EnemyStats>().setHP(hostile.GetComponent<EnemyStats>().getMaxHP());
                hostile.GetComponent<EnemyStats>().setMaxMP(Random.Range(100, 150));
                hostile.GetComponent<EnemyStats>().setMP(hostile.GetComponent<EnemyStats>().getMaxMP());
                hostile.GetComponent<EnemyStats>().setATK(Random.Range(80, 180));
                hostile.GetComponent<EnemySkills>().SetSkills(HeavyAttack, HeavyAttack, HeavyAttack);
                break;
        }

    }


    // Template Skills
    public void LightAttack(GameObject target)
    {
        Debug.Log("Enemy Used Light Attack On "+ target.name);
    }

    public void HeavyAttack(GameObject target)
    {
        Debug.Log("Enemy Used Heavy Attack On "+ target.name);
    }
}

