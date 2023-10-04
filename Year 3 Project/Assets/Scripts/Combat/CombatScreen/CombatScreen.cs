using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

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

    public TurnType getTurn()
    {
        return turn;
    }

    float enemyTurnTimer;
    bool enemyTurnTimerDone;

    float playerTurnTimer;
    bool playerTurnTimerDone;

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
        enemyTurnTimerDone = true;
        enemyTurnTimer = 0;
        playerTurnTimerDone = true;
        playerTurnTimer = 0;
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
        if(playerTurnTimerDone != true)
        {
            return;
        }
        if(player.GetComponent<Skills>().skill1cost > player.GetComponent<Stats>().getMP())
        {
            Debug.Log("Not Enough MP");
            return;
        }
        if(turn == TurnType.playerTurn)
        {
            skill1(enemy);
            // Wait for 3 seconds
            Debug.Log("Waiting for 3 seconds");
            playerTurnTimer = 3;
            playerTurnTimerDone = false;
            // -- Continued in player timer --
        }
    }
    public void useSkill2()
    {
        if(playerTurnTimerDone != true)
        {
            return;
        }
        if(player.GetComponent<Skills>().skill2cost > player.GetComponent<Stats>().getMP())
        {
            Debug.Log("Not Enough MP");
            return;
        }
        if(turn == TurnType.playerTurn)
        {
            skill2(enemy);
            // Wait for 3 seconds
            Debug.Log("Waiting for 3 seconds");
            playerTurnTimer = 3;
            playerTurnTimerDone = false;
            // -- Continued in player timer --
        }
    }
    public void useSkill3()
    {
        if(playerTurnTimerDone != true)
        {
            return;
        }
        if(player.GetComponent<Skills>().skill3cost > player.GetComponent<Stats>().getMP())
        {
            Debug.Log("Not Enough MP");
            return;
        }
        if(turn == TurnType.playerTurn)
        {
            skill3(enemy);
            // Wait for 3 seconds
            Debug.Log("Waiting for 3 seconds");
            playerTurnTimer = 3;
            playerTurnTimerDone = false;
            // -- Continued in player timer --
        }
    }

    // Update is called once per frame
    // Use to change UI on changes in combat
    // Change turn indicator when turn changes
    void Update()
    {
        // Determine If Combat is Over
        if(player.GetComponent<Stats>().getHP() == 0) // player dies(hp doesn't go below 0 as it is clamped)
        {
            // Game Over Screen
            SceneManager.LoadScene(0); 
            player.GetComponent<PersistAcrossScenes>().removeCamera();
            Destroy(gameObject);
        }
        if(enemy.GetComponent<Stats>().getHP() == 0) // enemy dies(hp doesn't go below 0 as it is clamped)
        {
            // End Combat
            turn = TurnType.END;
            // Reward Player
            player.GetComponent<PersistAcrossScenes>().addScore(100);
            // WIP give money to player once implemented
        }

        // Timers
        if (!playerTurnTimerDone)
        {
            playerTurnTimer = playerTurnTimer - Time.deltaTime;
        }

        if (!playerTurnTimerDone && playerTurnTimer < 0)
        {
            // -- Continued from player action --
            turn = TurnType.enemyTurn;

            //Set to false so that We don't run this again
            playerTurnTimerDone = true;
        }

        if (!enemyTurnTimerDone)
        {
            enemyTurnTimer = enemyTurnTimer - Time.deltaTime;
        }

        if (!enemyTurnTimerDone && enemyTurnTimer < 0)
        {
            // -- Continued from enemy turn --
            // regen player mana
            Debug.Log("Player Mana Regens");
            player.GetComponent<Stats>().regenMP();
            // Becomes Players turn again
            Debug.Log("Player Turn");
            turn = TurnType.playerTurn;

            //Set to false so that We don't run this again
            enemyTurnTimerDone = true;
        }

        // WIP testing stuff
        //if(turn != TurnType.START)
        //{
        //    if(Input.GetKey(KeyCode.Q))
        //    {
        //        // set enemy hp to 0 if not in start and press q
        //        enemy.GetComponent<Stats>().setHP(0);
        //    }
        //}
        //if(turn != TurnType.START)
        //{
        //    if(Input.GetKey(KeyCode.Q))
        //    {
        //        // set own hp to 0 if not in start and press q
        //        player.GetComponent<Stats>().setHP(0);
        //    }
        //}

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
        else if((turn == TurnType.enemyTurn)&&(enemyTurnTimerDone == true))
        {
            Debug.Log("Enemy Turn");
            // Enemy moves
            Debug.Log("Enemy Move");
            // WIP put enemy move here
            
            // Wait for 3 seconds
            Debug.Log("Waiting for 3 seconds");
            enemyTurnTimer = 3;
            enemyTurnTimerDone = false;
            // -- Continued in enemy timer --
        }
    }
}
