using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using Pathfinding;
using UnityEngine.UIElements;

public class CombatScreen : MonoBehaviour
{
    public GameObject PlayerSpriteSpawn;
    public GameObject EnemySpriteSpawn;
    public GameObject MenuCenter;

    public GameObject enemy;
    public GameObject player;

    public GameObject enemyHPBar;
    public GameObject playerHPBarC;
    public GameObject playerHPBarI;
    public GameObject playerHPBarA;
    public GameObject enemyMPBar;
    public GameObject playerMPBar;

    public GameObject button1;
    public GameObject button2;
    public GameObject button3;

    private System.Action<GameObject> skill1;
    private System.Action<GameObject> skill2;
    private System.Action<GameObject> skill3;

    public enum TurnType { playerTurn, enemyTurn, END, START, combatover };
    public TurnType turn = TurnType.START;

    public TurnType getTurn()
    {
        return turn;
    }

    float enemyTurnTimer;
    bool enemyTurnTimerDone;

    float playerTurnTimer;
    bool playerTurnTimerDone;
    bool playergameover;

    // Start is called before the first frame update
    // Initiate Combat Here
    // Use Sprite Spawn Empties to create sprites of combatants
    // Get the stats of the combatants
    // Decide starting turn
    void Start()
    {
        MenuCenter.transform.GetChild(0).GetComponent<Canvas>().worldCamera = Camera.main;
        button1.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(useSkill1);
        button2.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(useSkill2);
        button3.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(useSkill3);
        enemyTurnTimerDone = true;
        enemyTurnTimer = 0;
        playerTurnTimerDone = true;
        playerTurnTimer = 0;
        playergameover = false;
    }

    public void setEnemy(GameObject setEnemy)
    {
        // get enemy and player
        enemy = setEnemy;
        player = GameObject.Find("PlayerCharacter");
        // create sprites of characters
        Instantiate(player.GetComponent<CombatSprite>().getCombatSprite(), PlayerSpriteSpawn.transform);
        Instantiate(enemy.GetComponent<CombatSprite>().getCombatSprite(), EnemySpriteSpawn.transform);
        // set up hp bars
        enemyHPBar.GetComponent<ResourceBar>().SetMax((int)enemy.GetComponent<EnemyStats>().getMaxHP());
        playerHPBarC.GetComponent<ResourceBar>().SetMax((int)player.GetComponent<PlayerStats>().getMaxC());
        playerHPBarI.GetComponent<ResourceBar>().SetMax((int)player.GetComponent<PlayerStats>().getMaxI());
        playerHPBarA.GetComponent<ResourceBar>().SetMax((int)player.GetComponent<PlayerStats>().getMaxA());
        enemyHPBar.GetComponent<ResourceBar>().Set((int)enemy.GetComponent<EnemyStats>().getHP());
        playerHPBarC.GetComponent<ResourceBar>().Set((int)player.GetComponent<PlayerStats>().getC());
        playerHPBarI.GetComponent<ResourceBar>().Set((int)player.GetComponent<PlayerStats>().getI());
        playerHPBarA.GetComponent<ResourceBar>().Set((int)player.GetComponent<PlayerStats>().getA());

        // set up mp bars
        enemyMPBar.GetComponent<ResourceBar>().SetMax((int)enemy.GetComponent<EnemyStats>().getMaxMP());
        playerMPBar.GetComponent<ResourceBar>().SetMax((int)player.GetComponent<PlayerStats>().getMaxMP());
        enemyMPBar.GetComponent<ResourceBar>().Set((int)enemy.GetComponent<EnemyStats>().getMP());
        playerMPBar.GetComponent<ResourceBar>().Set((int)player.GetComponent<PlayerStats>().getMP());

        // set up player skills
        skill1 = player.GetComponent<Skills>().skill1;
        skill2 = player.GetComponent<Skills>().skill2;
        skill3 = player.GetComponent<Skills>().skill3;
        // set starting turn
        if (turn == TurnType.START)
        {
            if (player.GetComponent<PlayerStats>().getSPD() >= enemy.GetComponent<EnemyStats>().getSPD())
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
        if (playerTurnTimerDone != true)
        {
            return;
        }
        if (player.GetComponent<Skills>().skill1cost > player.GetComponent<PlayerStats>().getMP())
        {
            Debug.Log("Not Enough MP");
            return;
        }
        if (turn == TurnType.playerTurn)
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
        if (playerTurnTimerDone != true)
        {
            return;
        }
        if (player.GetComponent<Skills>().skill2cost > player.GetComponent<PlayerStats>().getMP())
        {
            Debug.Log("Not Enough MP");
            return;
        }
        if (turn == TurnType.playerTurn)
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
        if (playerTurnTimerDone != true)
        {
            return;
        }
        if (player.GetComponent<Skills>().skill3cost > player.GetComponent<PlayerStats>().getMP())
        {
            Debug.Log("Not Enough MP");
            return;
        }
        if (turn == TurnType.playerTurn)
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
        //Update HP Bars
        enemyHPBar.GetComponent<ResourceBar>().Set((int)enemy.GetComponent<EnemyStats>().getHP());
        playerHPBarC.GetComponent<ResourceBar>().Set((int)player.GetComponent<PlayerStats>().getC());
        playerHPBarI.GetComponent<ResourceBar>().Set((int)player.GetComponent<PlayerStats>().getI());
        playerHPBarA.GetComponent<ResourceBar>().Set((int)player.GetComponent<PlayerStats>().getA());
        // Update MP Bars
        enemyMPBar.GetComponent<ResourceBar>().Set((int)enemy.GetComponent<EnemyStats>().getMP());
        playerMPBar.GetComponent<ResourceBar>().Set((int)player.GetComponent<PlayerStats>().getMP());

        // Determine If Combat is Over
        if ((player.GetComponent<PlayerStats>().getC() == 0) || (player.GetComponent<PlayerStats>().getI() == 0) || (player.GetComponent<PlayerStats>().getA() == 0)) // player dies(hp doesn't go below 0 as it is clamped)
        {
            turn = TurnType.combatover;
            // WIP display lose text
            if (Input.GetMouseButtonDown(0))
            {
                playergameover = true;
                turn = TurnType.END;
            }
        }
        if (enemy.GetComponent<EnemyStats>().getHP() == 0) // enemy dies(hp doesn't go below 0 as it is clamped)
        {
            turn = TurnType.combatover;
            if (Input.GetMouseButtonDown(0))
            {
                // WIP display win text
                // End Combat
                turn = TurnType.END;
                // Reward Player
                player.GetComponent<PersistAcrossScenes>().addScore(100);
                // WIP give money to player once implemented
            }
        }

        // Timers
        if (!playerTurnTimerDone)
        {
            playerTurnTimer = playerTurnTimer - Time.deltaTime;
        }

        if (!playerTurnTimerDone && playerTurnTimer < 0)
        {
            // -- Continued from player action --
            // Apply Condition On turn Affects
            if (player.GetComponent<PlayerStats>().HasCondition("DoTA"))
            {
                float dmg = player.GetComponent<PlayerStats>().GetAmountTotal("DoTA");
                player.GetComponent<PlayerStats>().DamageA(dmg);
            }
            if (player.GetComponent<PlayerStats>().HasCondition("DoTI"))
            {
                float dmg = player.GetComponent<PlayerStats>().GetAmountTotal("DoTI");
                player.GetComponent<PlayerStats>().DamageI(dmg);
            }
            if (player.GetComponent<PlayerStats>().HasCondition("DoTC"))
            {
                float dmg = player.GetComponent<PlayerStats>().GetAmountTotal("DoTC");
                player.GetComponent<PlayerStats>().DamageC(dmg);
            }
            // Reduce conditions
            player.GetComponent<PlayerStats>().ReduceConditions(TurnType.playerTurn);
            enemy.GetComponent<EnemyStats>().ReduceConditions(TurnType.playerTurn);

            // regen enemy mana
            Debug.Log("Enemy Mana Regens");
            enemy.GetComponent<EnemyStats>().regenMP();

            // enemy turn
            if (turn != TurnType.combatover)
            {
                turn = TurnType.enemyTurn;
            }

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
            // Apply Condition On turn Affects
            if (player.GetComponent<PlayerStats>().HasCondition("DoT"))
            {
                float dmg = player.GetComponent<PlayerStats>().GetAmountTotal("DoT");
                enemy.GetComponent<EnemyStats>().Damage(dmg);
            }
            // Reduce conditions
            player.GetComponent<PlayerStats>().ReduceConditions(TurnType.enemyTurn);
            enemy.GetComponent<EnemyStats>().ReduceConditions(TurnType.enemyTurn);
            // regen player mana
            Debug.Log("Player Mana Regens");
            player.GetComponent<PlayerStats>().regenMP();
            // Becomes Players turn again
            if (turn != TurnType.combatover)
            {
                Debug.Log("Player Turn");
                turn = TurnType.playerTurn;
            }

            //Set to false so that We don't run this again
            enemyTurnTimerDone = true;
        }

        // check turn
        if (turn == TurnType.START)
        {
            return;
        }
        else if (turn == TurnType.END)
        {
            if (playergameover)
            {
                // Game Over Screen
                SceneManager.LoadScene(1);
                player.GetComponent<PersistAcrossScenes>().removeCamera();
                Destroy(gameObject);
            }
            else
            {
                player.GetComponent<PlayerStats>().WipeConditions();
                enemy.GetComponent<EnemyStats>().WipeConditions();
                player.GetComponent<CombatStatus>().outCombat();
                // Re-Enable Enemy chasing Player
                if (enemy.GetComponent<AIDestinationSetter>() != null) { enemy.GetComponent<AIDestinationSetter>().leaveCombat(); }
                enemy.transform.GetChild(0).GetComponent<CombatStarter>().endCombat();
            }

        }
        else if ((turn == TurnType.enemyTurn) && (enemyTurnTimerDone == true))
        {
            Debug.Log("Enemy Turn");
            // Enemy moves
            Debug.Log("Enemy Move");
            // decide move to use
            int move = enemy.GetComponent<EnemySkills>().DecideMove();
            // use picked move
            switch (move)
            {
                case 1:
                    enemy.GetComponent<EnemySkills>().UseSkill1(player);
                    break;
                case 2:
                    enemy.GetComponent<EnemySkills>().UseSkill2(player);
                    break;
                case 3:
                    enemy.GetComponent<EnemySkills>().UseSkill3(player);
                    break;
            }
            // Wait for 3 seconds
            Debug.Log("Waiting for 3 seconds");
            enemyTurnTimer = 3;
            enemyTurnTimerDone = false;
            // -- Continued in enemy timer --
        }
    }
}
