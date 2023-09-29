using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CombatScreen : MonoBehaviour
{
    public GameObject PlayerSpriteSpawn;
    public GameObject EnemySpriteSpawn;
    public GameObject MenuCenter;
    public GameObject enemy;
    public GameObject player;
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    private System.Action<GameObject> skill1;
    private System.Action<GameObject> skill2;
    private System.Action<GameObject> skill3;
    public enum TurnType{playerTurn, enemyTurn, END, START};
    public TurnType turn = TurnType.START;

    // Start is called before the first frame update
    // Initiate Combat Here
    // Use Sprite Spawn Empties to create sprites of combatants
    // Get the stats of the combatants
    // Decide starting turn
    void Start()
    {
        Cursor.visible = true;
        MenuCenter.transform.GetChild(0).GetComponent<Canvas>().worldCamera = Camera.main;
        button1.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(useSkill1);
        button2.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(useSkill2);
        button3.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(useSkill3);
    }

    public void setEnemy(GameObject setEnemy)
    {
        // get enemy and player
        enemy = setEnemy;
        player = GameObject.Find("PlayerCharacter");
        // create menu
        skill1 = player.GetComponent<Skills>().skill1;
        skill2 = player.GetComponent<Skills>().skill2;
        skill3 = player.GetComponent<Skills>().skill3;
        // set starting turn
        if(turn == TurnType.START)
        {
            if(player.GetComponent<Stats>().getSPD() >= enemy.GetComponent<Stats>().getSPD())
            {
                turn = TurnType.playerTurn;
            }
            else
            {
                turn = TurnType.enemyTurn;
            }
        }
    }

    // Player Turns
    public void useSkill1()
    {
        if(player.GetComponent<Skills>().skill1cost > player.GetComponent<Stats>().getMP())
        {
            Debug.Log("Out Of MP");
            return;
        }
        if(turn == TurnType.playerTurn)
        {
            skill1(enemy);
        }
        turn = TurnType.enemyTurn;
    }
    public void useSkill2()
    {
        if(player.GetComponent<Skills>().skill2cost > player.GetComponent<Stats>().getMP())
        {
            Debug.Log("Out Of MP");
            return;
        }
        if(turn == TurnType.playerTurn)
        {
            skill2(enemy);
        }
        turn = TurnType.enemyTurn;
    }
    public void useSkill3()
    {
        if(player.GetComponent<Skills>().skill3cost > player.GetComponent<Stats>().getMP())
        {
            Debug.Log("Out Of MP");
            return;
        }
        if(turn == TurnType.playerTurn)
        {
            skill3(enemy);
        }
        turn = TurnType.enemyTurn;
    }

    // Update is called once per frame
    // Use to change UI on changes in combat
    // Change turn indicator when turn changes
    void Update()
    {
        // WIP testing
        if(turn != TurnType.START)
        {
            if(Input.GetKey(KeyCode.Q))
            {
                // end combat if not in start and press q
                turn = TurnType.END;
            }
        }
        // check turn
        if(turn == TurnType.START)
        {
            return;
        }
        else if(turn == TurnType.END)
        {
            Cursor.visible = false;
            enemy.transform.GetChild(0).GetComponent<CombatStarter>().endCombat();
        }
        else if(turn == TurnType.enemyTurn)
        {
            // pick enemy move
            Debug.Log("Enemy Move");
            // regen player mana
            player.GetComponent<Stats>().regenMP();
            // WIP add enemy move here
            turn = TurnType.playerTurn;
        }
    }
}
