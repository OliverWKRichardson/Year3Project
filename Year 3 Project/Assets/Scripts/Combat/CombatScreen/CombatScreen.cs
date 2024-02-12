using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using Pathfinding;
using UnityEngine.UIElements;
using System;
using UnityEngine.UI;
using TMPro;

public class CombatScreen : MonoBehaviour
{
    public GameObject PlayerSpriteSpawn;
    public GameObject EnemySpriteSpawn;
    public GameObject MenuCenter;
    public GameObject TutorialCanvas;

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
    public GameObject winText;
    public GameObject loseText;
    public GameObject continueText;

    public GameObject buttonAB;
    public GameObject buttonPR;
    public GameObject buttonSU;
    public GameObject tutorialText1;
    public GameObject tutorialText2;
    public GameObject tutorialText3;
    public GameObject tutorialText4;
    public GameObject tutorialText5;
	public GameObject tutorialText6;
    public GameObject tutorialSkip;
    public GameObject tutorialContinue;
    public GameObject tutorialNext1;
    public GameObject tutorialNext2;
    public GameObject tutorialNext3;
    public GameObject tutorialNext4;
    public GameObject tutorialNext5;

    public GameObject enemyActionText;
    public GameObject playerActionText;
    public GameObject enemyTypeText;

    private System.Action<GameObject> skill1;
    private System.Action<GameObject> skill2;
    private System.Action<GameObject> skill3;

    private Transform hudTransform;

    int turnNumber;

    public bool tutorialMode;

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
        GameObject ui = GameObject.FindWithTag("DialogueSystem");
        ui.transform.localScale = new Vector3(0, 0, 0);
        MenuCenter.transform.GetChild(0).GetComponent<Canvas>().worldCamera = Camera.main;
        button1.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(useSkill1);
        button2.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(useSkill2);
        button3.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(useSkill3);
        enemyTurnTimerDone = true;
        enemyTurnTimer = 0;
        playerTurnTimerDone = true;
        playerTurnTimer = 0;

        playergameover = false;

        hudTransform = player.transform.Find("HUD");
        hudTransform.gameObject.SetActive(false);

        turnNumber = 0;

        
        runCombatTutorial();
    }

    public void setEnemy(GameObject setEnemy)
    {
        // get enemy and player
        enemy = setEnemy;
        player = GameObject.Find("PlayerCharacter");
        // player.GetComponent<PlayerCharacterMovement>().fixRight();
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
        setEnemyTypeText(enemy.GetComponent<EnemyStats>());
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
            DisplayActionText("Player",player.GetComponent<Skills>().skill1Name);
            // Wait for 1 second
            Debug.Log("Waiting for 1 second");
            playerTurnTimer = 1;
            playerTurnTimerDone = false;
            turnNumber++;
            tutorialManager();
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
            DisplayActionText("Player",player.GetComponent<Skills>().skill2Name);
            // Wait for 1 second
            Debug.Log("Waiting for 1 second");
            playerTurnTimer = 1;
            playerTurnTimerDone = false;
            turnNumber++;
            tutorialManager();
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
            DisplayActionText("Player",player.GetComponent<Skills>().skill3Name);
            // Wait for 1 second
            Debug.Log("Waiting for 1 second");
            playerTurnTimer = 1;
            playerTurnTimerDone = false;
            turnNumber++;
            tutorialManager();
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
            loseText.SetActive(true);
            continueText.SetActive(true);
            if (Input.GetMouseButtonDown(0))
            {
                playergameover = true;
                turn = TurnType.END;
            }
        }
        if (enemy.GetComponent<EnemyStats>().getHP() == 0) // enemy dies(hp doesn't go below 0 as it is clamped)
        {
            turn = TurnType.combatover;
            winText.SetActive(true);
            continueText.SetActive(true);
            if (Input.GetMouseButtonDown(0))
            {
                // End Combat
                turn = TurnType.END;
                // Reward Player
                player.GetComponent<PersistAcrossScenes>().addScore(100);
                // Re-enable minimap
                hudTransform.gameObject.SetActive(true);
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
                GameObject ui = GameObject.FindWithTag("DialogueSystem");
                ui.transform.localScale = new Vector3(1, 1, 1);

                //Award Player Money For Win
                PlayerStats ps = player.GetComponent<PlayerStats>();
                ps.WinMoney();
                GameObject.FindWithTag("Money").GetComponent<MoneyManager>().UpdateMoney();
                GameObject hb = GameObject.FindWithTag("HealthBars");

                GameObject abar = hb.transform.Find("Abar").gameObject;
                GameObject cbar = hb.transform.Find("Cbar").gameObject;
                GameObject ibar = hb.transform.Find("Ibar").gameObject;
                Debug.Log(ps.getC());
                Debug.Log(ps.getMaxC());
                cbar.GetComponent<ResourceBar>().Setf(ps.getC()/ps.getMaxC());
                ibar.GetComponent<ResourceBar>().Setf(ps.getI() / ps.getMaxI());
                abar.GetComponent<ResourceBar>().Setf(ps.getA()/ps.getMaxA());


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
                    DisplayActionText("Enemy",enemy.GetComponent<EnemySkills>().skill1Name);
                    break;
                case 2:
                    enemy.GetComponent<EnemySkills>().UseSkill2(player);
                    DisplayActionText("Enemy",enemy.GetComponent<EnemySkills>().skill2Name);
                    break;
                case 3:
                    enemy.GetComponent<EnemySkills>().UseSkill3(player);
                    DisplayActionText("Enemy",enemy.GetComponent<EnemySkills>().skill3Name);
                    break;
            }
            // Wait for 1 second
            Debug.Log("Waiting for 1 second");
            enemyTurnTimer = 1;
            enemyTurnTimerDone = false;
            // -- Continued in enemy timer --
        }
    }

    public void DisplayActionText(String currentTurn, String text)
    {
        if(currentTurn == "Enemy")
        {
            enemyActionText.SetActive(true);
            playerActionText.SetActive(false);
            enemyActionText.GetComponent<Text>().text = text;
        }
        else if(currentTurn == "Player")
        {
            playerActionText.SetActive(true);
            enemyActionText.SetActive(false);
            playerActionText.GetComponent<Text>().text = text;
        }
    }

    public void runCombatTutorial()
    {
        if (enemy.GetComponent<EnemyStats>().getTutorialStatus() == true)
        {
            TutorialCanvas.SetActive(true);
            MenuCenter.transform.GetChild(1).GetComponent<Canvas>().worldCamera = Camera.main;
            tutorialText1.SetActive(true);
            tutorialText2.SetActive(false);
            tutorialText3.SetActive(false);
            tutorialText4.SetActive(false);
            tutorialText5.SetActive(false);
            tutorialText6.SetActive(false);
            tutorialNext1.SetActive(false);
            tutorialNext2.SetActive(false);
            tutorialNext3.SetActive(false);
            tutorialNext4.SetActive(false);
            tutorialNext5.SetActive(false);
            buttonAB.SetActive(false);
            buttonPR.SetActive(false);
            buttonSU.SetActive(false);
            tutorialContinue.SetActive(true);
            tutorialSkip.SetActive(true);
            tutorialSkip.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(leaveTutorial);
            tutorialContinue.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(doTutorial);
            tutorialMode = true;
        }
        else 
        {
            TutorialCanvas.SetActive(false);
            tutorialMode = false;
            MenuCenter.transform.GetChild(0).GetComponent<Canvas>().worldCamera = Camera.main;
            return;
        }
    }
    
    public void doTutorial()
    {
        Debug.Log("Tutorial Started");
        tutorialContinue.SetActive(false);
        tutorialSkip.SetActive(false);
        tutorialText1.SetActive(false);
        tutorialText2.SetActive(true);
        tutorialNext1.SetActive(true);
        tutorialNext1.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(cycleTutorialOn);
    }
    public void leaveTutorial()
    {
        TutorialCanvas.SetActive(false);
        MenuCenter.transform.GetChild(0).GetComponent<Canvas>().worldCamera = Camera.main;
        tutorialMode = false;
    }
    public void cycleTutorialOn()
    {
        tutorialText2.SetActive(false);
        tutorialText3.SetActive(true);
        buttonPR.SetActive(true);
        tutorialNext1.SetActive(false);
        tutorialNext2.SetActive(true);
        tutorialNext2.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(cycleTutorialOff);
    }
    public void cycleTutorialOff()
    {
        tutorialText3.SetActive(false);
        buttonPR.SetActive(false);
        tutorialNext2.SetActive(false);
        TutorialCanvas.SetActive(false);
        MenuCenter.transform.GetChild(0).GetComponent<Canvas>().worldCamera = Camera.main;
    }
    public void supportGuide()
    {
        MenuCenter.transform.GetChild(1).GetComponent<Canvas>().worldCamera = Camera.main;
        TutorialCanvas.SetActive(true);
        tutorialText4.SetActive(true);
        tutorialNext3.SetActive(true);
        buttonSU.SetActive(true);
        tutorialNext3.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(leaveSupport);
    }
    public void leaveSupport()
    {
        tutorialText4.SetActive(false);
        buttonSU.SetActive(false);
        tutorialNext3.SetActive(false);
        TutorialCanvas.SetActive(false);
        MenuCenter.transform.GetChild(0).GetComponent<Canvas>().worldCamera = Camera.main;
    }
    public void abilityGuide()
    {
        MenuCenter.transform.GetChild(1).GetComponent<Canvas>().worldCamera = Camera.main;
        TutorialCanvas.SetActive(true);
        tutorialText5.SetActive(true);
        buttonAB.SetActive(true);
        tutorialNext4.SetActive(true);
        tutorialNext4.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(tutorialFinal);
    }
    public void tutorialFinal()
    {
        tutorialText5.SetActive(false);
        buttonAB.SetActive(false);
        tutorialText6.SetActive(true);
        tutorialNext4.SetActive(false);
        tutorialNext5.SetActive(true);
        tutorialNext5.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(tutorialLeaving);
    }
    public void tutorialLeaving()
    {
        TutorialCanvas.SetActive(false);
        tutorialMode = false;
        MenuCenter.transform.GetChild(0).GetComponent<Canvas>().worldCamera = Camera.main;
    }
    public void tutorialManager()
    {
        if (tutorialMode == true)
        {
            if (turnNumber == 1)
            {
                supportGuide();
            }
            else if (turnNumber == 2)
            {
                abilityGuide();
            }
        }
    }


    public void setEnemyTypeText(EnemyStats es)
    {
        EnemyGenerator.enemyType type = es.getType();
        switch (type)
        {
            case EnemyGenerator.enemyType.malware:
                enemyTypeText.GetComponent<Text>().text = "Malware";
                break;

            case EnemyGenerator.enemyType.hacker:
                enemyTypeText.GetComponent<Text>().text = ("Hacker");

                break;
            case EnemyGenerator.enemyType.scriptkiddie:
                enemyTypeText.GetComponent<Text>().text = ("Script Kiddie");

                break;
            case EnemyGenerator.enemyType.socialengineer:
                enemyTypeText.GetComponent<Text>().text = ("Social Engineer");

                break;
            case EnemyGenerator.enemyType.nationstateactor:
                enemyTypeText.GetComponent<Text>().text = ("Nation State Actor");

                break;


        }
    }
}
