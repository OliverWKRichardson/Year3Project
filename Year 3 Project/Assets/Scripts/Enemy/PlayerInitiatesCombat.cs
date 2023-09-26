using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInitiatesCombat : MonoBehaviour
{
    bool lineOfSightTesting = false;
    
    // Update is called once per frame
    void Update()
    {
        // If in range to test Line of sight with player then do so
        if(lineOfSightTesting)
        {
            // get player position
            Transform enemyTransform = GameObject.Find("Enemy").transform;
            // raycast at player
            RaycastHit2D hit = Physics2D.Linecast(transform.position, enemyTransform.position);
            // if hit something
            if(hit.collider != null)
            {
                // if is the player
                if(hit.collider.gameObject == GameObject.Find("Combat Starter"))
                {
                    // start combat
                    // WIP put code to enter combat here
                    Debug.Log("Entered Combat");
                    // stop line of sight testing
                    lineOfSightTesting = false;
                }
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        // if enter range with player to enter combat start testing line of sight
        if(other.gameObject.name == "Combat Seeker")
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
        if(other.gameObject.name == "Combat Seeker")
        {
            Debug.Log("No longer Near Enemy");
            lineOfSightTesting = false;
        }
    }
}
