using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseStarter : MonoBehaviour
{
    bool lineOfSightTesting = false;
    GameObject enemy;

    void Start()
    {
        enemy = gameObject.transform.parent.gameObject;
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
                    // start combat
                    // WIP put code to enter combat here
                    Debug.Log("Chasing Player");
                    chasePlayer();
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
    
    void chasePlayer()
    {
        Debug.Log("Chasing Player");
        Transform playerTransform = GameObject.Find("PlayerCharacter").transform;
        Rigidbody2D rb = enemy.GetComponent<Rigidbody2D>();
        EnemyStats stats = enemy.GetComponent<EnemyStats>();
        Vector2 direction = Vector2.zero;

        if (transform.position.x < playerTransform.position.x)
        {
            direction.x = 1;
        }
        else if (transform.position.x > playerTransform.position.x)
        {
            direction.x = -1;
        }
        else
        {
            direction.x = 0;
        }
        if (transform.position.y < playerTransform.position.y)
        {
            direction.y = 1;
        }
        else if (transform.position.y > playerTransform.position.y)
        {
            direction.y = -1;
        }
        else
        {
            direction.y = 0;
        }
        direction.Normalize();
        rb.velocity = stats.getSPD() * direction;
    }

    void ignorePlayer()
    {
        Debug.Log("Ignoring Player");
    }
}
