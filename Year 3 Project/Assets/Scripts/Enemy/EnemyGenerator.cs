using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{

    // Enemy class
    [SerializeField]
    private GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        // createEnemy();
    }

    void createEnemy()
    {
        GameObject hostile = Instantiate(enemy); // Add Vector2(x, y) for the position of the newly generated enemy

        int enemyType = Random.Range(1,3);

        if (enemyType == 1)
        {
            hostile.GetComponent<Stats>().setSPD(Random.Range(3, 5));
            hostile.GetComponent<Stats>().setHP(Random.Range(500, 800));
            hostile.GetComponent<Stats>().setMP(Random.Range(100, 150));
            hostile.GetComponent<Stats>().setATK(Random.Range(50, 100));
        }
        else if (enemyType == 2)
        {
            hostile.GetComponent<Stats>().setSPD(Random.Range(4, 7));
            hostile.GetComponent<Stats>().setHP(Random.Range(750, 1000));
            hostile.GetComponent<Stats>().setMP(Random.Range(200, 350));
            hostile.GetComponent<Stats>().setATK(Random.Range(80, 180));
        }

    }
}
