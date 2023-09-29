using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    // Enemy Type
    public enum enemyType{light, heavy}

    // Enemy class
    [SerializeField]
    private GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        createEnemy();
    }

    void createEnemy()
    {
        Transform pos = gameObject.transform;
        GameObject hostile = Instantiate(enemy, pos); // Add Vector2(x, y) for the position of the newly generated enemy

        enemyType enemyType = (enemyType)Random.Range(0, 2);

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
                break;
            case enemyType.heavy:
                hostile.GetComponent<Stats>().setType(enemyType.heavy);
                hostile.GetComponent<Stats>().setSPD(Random.Range(1, 5));
                hostile.GetComponent<Stats>().setMaxHP(Random.Range(750, 1000));
                hostile.GetComponent<Stats>().setHP(hostile.GetComponent<Stats>().getMaxHP());
                hostile.GetComponent<Stats>().setMaxMP(Random.Range(100, 150));
                hostile.GetComponent<Stats>().setMP(hostile.GetComponent<Stats>().getMaxMP());
                hostile.GetComponent<Stats>().setATK(Random.Range(80, 180));
                break;
        }

    }
}
