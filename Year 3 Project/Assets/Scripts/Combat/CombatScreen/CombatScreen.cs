using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatScreen : MonoBehaviour
{
    [SerializeField] private GameObject PlayerSpriteSpawn;
    [SerializeField] private GameObject EnemySpriteSpawn1;
    [SerializeField] private GameObject EnemySpriteSpawn2;
    [SerializeField] private GameObject EnemySpriteSpawn3;
    [SerializeField] private GameObject EnemySpriteSpawn4;
    [SerializeField] private GameObject EnemySpriteSpawn5;
    [SerializeField] private GameObject MenuCenter;
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject player;
    private System.Action<GameObject> skill1;
    private System.Action<GameObject> skill2;
    private System.Action<GameObject> skill3;

    // Start is called before the first frame update
    // Initiate Combat Here
    // Use Sprite Spawn Empties to create sprites of combatants
    // Get the stats of the combatants
    // Decide starting turn
    void Start()
    {
        player = GameObject.Find("PlayerCharacter");
        // WIP Create Menu For Player Skills At Bottom Of Screen
        skill1 = player.GetComponent<Skills>().skill1;
        skill2 = player.GetComponent<Skills>().skill2;
        skill3 = player.GetComponent<Skills>().skill3;
    }

    public void setEnemy(GameObject setEnemy)
    {
        enemy = setEnemy;
    }

    public void useSkill1()
    {
        skill1(enemy);
    }
    public void useSkill2()
    {
        skill2(enemy);
    }
    public void useSkill3()
    {
        skill3(enemy);
    }

    // Update is called once per frame
    // Use to change UI on changes in combat
    // Change turn indicator when turn changes
    void Update()
    {
        
    }
}
