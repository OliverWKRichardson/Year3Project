using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatStarter : MonoBehaviour
{
    bool lineOfSightTesting = false;

    [SerializeField]
    GameObject enemy;

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
                    // start combat
                    // WIP put code to enter combat here
                    Debug.Log("Chasing Player");
                    chasePlayer(playerTransform);
                    // stop line of sight testing
                    lineOfSightTesting = false;
                }
            }
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
            Debug.Log("No longer Near Enemy");
            lineOfSightTesting = false;
            ignorePlayer();
        }
    }
    
    void chasePlayer(Transform playerTransform)
    {
        Debug.Log("Chasing Player");
        Rigidbody rb = GetComponent<Rigidbody>();
        EnemyStats stats = GetComponent<EnemyStats>();

        if (transform.position.x < playerTransform.position.x)
        {
            rb.velocity = new Vector2(stats.getSPD(), 0);
        }
        else if (transform.position.x > playerTransform.position.x)
        {
            rb.velocity = new Vector2(-stats.getSPD(), 0);
        }
        if (transform.position.y < playerTransform.position.y)
        {
            rb.velocity = new Vector2(0, stats.getSPD());
        }
        else if (transform.position.y > playerTransform.position.y)
        {
            rb.velocity = new Vector2(0, -stats.getSPD());
        }
        else if (transform.position.x == playerTransform.position.x & transform.position.y == playerTransform.position.y)
        {
            Debug.Log("Initiating Combat");
        }
    }

    void ignorePlayer()
    {
        Debug.Log("Ignoring Player");
    }
}
