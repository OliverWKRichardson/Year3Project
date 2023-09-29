using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatStarter : MonoBehaviour
{
    bool lineOfSightTesting = false;
    bool inCombat = false;
    bool combatCleanUp = false;
    public GameObject combatScreenPrefab;
    GameObject combatScreen;

    public void endCombat()
    {
        inCombat = false;
    }

    // Update is called once per frame
    void Update()
    {
        // If in range to test Line of sight with player then do so
        if(lineOfSightTesting)
        {
            // get player position
            Transform playerTransform = GameObject.Find("PlayerCharacter").transform;
            // raycast at player
            RaycastHit2D hit = Physics2D.Linecast(transform.position, playerTransform.position);
            // if hit something
            if(hit.collider != null)
            {
                // if is the player
                if(hit.collider.gameObject == GameObject.Find("PlayerCharacter"))
                {
                    Debug.Log("Entered Combat");
                    inCombat = true;
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
            combatCleanUp = false;
            // delete enemy
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
