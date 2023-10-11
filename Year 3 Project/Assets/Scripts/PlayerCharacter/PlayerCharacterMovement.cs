using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterMovement : MonoBehaviour
{
    public float SPEED = 3;
    public bool movementDisabled = false;

    public void DisablePlayerMovement()
    {
        movementDisabled = true;
    }

    public void EnablePlayerMovement()
    {
        movementDisabled = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Hide Mouse
        Cursor.visible = false;
        // set initial stats for player
        PlayerStats playerStats = GetComponent<PlayerStats>();
        playerStats.setSPD(7);
        playerStats.setMaxHP(400);
        playerStats.setHP(400);
        playerStats.setMaxMP(200);
        playerStats.setMP(200);
        playerStats.setATK(200);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // FixedUpdate is called 50 times per second
    void FixedUpdate()
    {
        // Create empty Vector2
        Vector2 direction = Vector2.zero;
        // Evaluate horizontal input
        if(Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
        {
            direction.x = 0;
        }
        else if(Input.GetKey(KeyCode.A))
        {
            direction.x = -1;
        }
        else if(Input.GetKey(KeyCode.D))
        {
            direction.x = 1;
        }
        else
        {
            direction.x = 0;
        }
        // Evaluate verticle input
        if(Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.W))
        {
            direction.y = 0;
        }
        else if(Input.GetKey(KeyCode.S))
        {
            direction.y = -1;
        }
        else if(Input.GetKey(KeyCode.W))
        {
            direction.y = 1;
        }
        else
        {
            direction.y = 0;
        }
        // Normalize Vector2 so that it isn't faster to travel diagonally
        direction.Normalize();
        // Check Player Movement is not disabled
        if(movementDisabled)
        {
            // If it is stop movement
            direction = Vector2.zero;
        }
        // Add velocity to the character
        GetComponent<Rigidbody2D>().velocity = SPEED * direction;
    }
}
