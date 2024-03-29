using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class CombatStarter : MonoBehaviour
{
    bool lineOfSightTesting = false;
    bool inCombat = false;
    bool combatCleanUp = false;
    public GameObject combatScreenPrefab;
    GameObject combatScreen;
    private bool fw;
    private bool canFight = true;
    private GameObject plyr;
    public void endCombat()
    {
        inCombat = false;
    }

    // Update is called once per frame
    void Update()
    {
        plyr = GameObject.FindWithTag("Player");
        fw = plyr.transform.Find("Firewall").gameObject.activeSelf;
        gameObject.transform.position = gameObject.transform.parent.transform.position;
        Debug.Log(gameObject.transform.parent.name);

        // If in range to test Line of sight with player then do so
        if(lineOfSightTesting && fw == false)
        {
            // get player position
            Transform playerTransform = GameObject.Find("PlayerCharacter").transform;
            // raycast at player
            RaycastHit2D hit = Physics2D.Linecast(transform.position, playerTransform.position);

            // if hit something
            if(hit.collider != null)
            {

                // if is the player
                if(hit.collider.gameObject == GameObject.Find("PlayerCharacter") && (AIDestinationSetter.inCombat == false) && (canFight == true))
                {
                    canFight = false;
                    Debug.Log("Entered Combat");
                    inCombat = true;
                    AIDestinationSetter.inCombat = true;

                    playerTransform.gameObject.GetComponent<CombatStatus>().inCombat();
                    combatCleanUp = true;
                    // start combat
                    combatScreen = Instantiate(combatScreenPrefab, playerTransform);
                    combatScreen.GetComponent<CombatScreen>().setEnemy(gameObject.transform.parent.gameObject);
                    // Disable movement for the player
                    GameObject.Find("PlayerCharacter").GetComponent<PlayerCharacterMovement>().DisablePlayerMovement();
                    // stop line of sight testing
                    lineOfSightTesting = false;
                }
            }
        }

        // Exit Combat Screen and let the player move on Combat End
        if(!inCombat && combatCleanUp)
        {
            Debug.Log("Left Combat");
            Destroy(combatScreen);
            GameObject.Find("PlayerCharacter").GetComponent<PlayerCharacterMovement>().EnablePlayerMovement();
            AIDestinationSetter.inCombat = false;
            combatCleanUp = false;
            // delete enemy
            
            //Call player function to award money if player is alive
            Destroy(gameObject.transform.parent.gameObject);
        }
    }

    // OnTriggerEnter is called when entering a trigger area and passes the trigger that 
    // has been entered as a argument
    void OnTriggerEnter2D(Collider2D other)
    {
        // if enter range with player to enter combat start testing line of sight
        if(other.gameObject.name == "Combat Detector")
        {
            Debug.Log("Near Enemy");
            lineOfSightTesting = true;
        }

        // if player has a FireWall barrier active
        if(other.gameObject.tag == "Barrier")
        {
            if (transform.parent.gameObject.tag == "Boss")
            {
                other.gameObject.SetActive(false);
                fw = false;
            }
            else
            {
                Debug.Log("FireWalled");
                GameObject enemy = gameObject.transform.parent.gameObject;
                StunBehavior enemyscript = enemy.GetComponent<StunBehavior>();
                enemyscript.StartCoroutine(enemyscript.Stun());
                GameObject.FindWithTag("Player").transform.Find("Firewall").gameObject.SetActive(false);
            }
        }
    }

    // OnTriggerExit is called when leaving a trigger area and passes the trigger that has 
    // been left as a argument
    void OnTriggerExit2D(Collider2D other)
    {
        // if leave range with player to enter combat stop testing line of sight
        if(other.gameObject.name == "Combat Detector")
        {
            Debug.Log("Nolonger Near Enemy");
            lineOfSightTesting = false;
        }
    }
}
