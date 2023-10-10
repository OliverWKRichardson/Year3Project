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
                hostile.GetComponent<Stats>().setType(enemyType.light);
                hostile.GetComponent<Stats>().setSPD(Random.Range(5, 11));
                hostile.GetComponent<Stats>().setMaxHP(Random.Range(400, 600));
                hostile.GetComponent<Stats>().setHP(hostile.GetComponent<Stats>().getMaxHP());
                hostile.GetComponent<Stats>().setMaxMP(Random.Range(100, 150));
                hostile.GetComponent<Stats>().setMP(hostile.GetComponent<Stats>().getMaxMP());
                hostile.GetComponent<Stats>().setATK(Random.Range(50, 100));
                hostile.GetComponent<EnemySkills>().SetSkills(LightAttack, LightAttack, LightAttack);
                break;
            case enemyType.heavy:
                hostile.GetComponent<Stats>().setType(enemyType.heavy);
                hostile.GetComponent<Stats>().setSPD(Random.Range(1, 5));
                hostile.GetComponent<Stats>().setMaxHP(Random.Range(750, 1000));
                hostile.GetComponent<Stats>().setHP(hostile.GetComponent<Stats>().getMaxHP());
                hostile.GetComponent<Stats>().setMaxMP(Random.Range(100, 150));
                hostile.GetComponent<Stats>().setMP(hostile.GetComponent<Stats>().getMaxMP());
                hostile.GetComponent<Stats>().setATK(Random.Range(80, 180));
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

