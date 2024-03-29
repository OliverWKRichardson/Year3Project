using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterMovement : MonoBehaviour
{
    public float SPEED = 3;
    public bool movementDisabled = false;

    bool facingRight;

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
        // set initial stats for player
        PlayerStats playerStats = GetComponent<PlayerStats>();
        playerStats.setSPD(7);
        playerStats.setMaxC(400);
        playerStats.setC(400);
        playerStats.setMaxI(400);
        playerStats.setI(400);
        playerStats.setMaxA(400);
        playerStats.setA(400);
        playerStats.setMaxMP(200);
        playerStats.setMP(200);
        playerStats.setATK(200);
        facingRight = true;
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
        if((Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.LeftArrow)) && (Input.GetKey(KeyCode.D)||Input.GetKey(KeyCode.RightArrow)))
        {
            direction.x = 0;
        }
        else if(Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.LeftArrow))
        {
            direction.x = -1;
            if (facingRight == true)
            {
                // Flip();
            }
        }
        else if(Input.GetKey(KeyCode.D)||Input.GetKey(KeyCode.RightArrow))
        {
            direction.x = 1;
            if (facingRight == false)
            {
                // Flip();
            }
        }
        else
        {
            direction.x = 0;
        }
        // Evaluate verticle input
        if((Input.GetKey(KeyCode.S)||Input.GetKey(KeyCode.DownArrow)) && (Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.UpArrow)))
        {
            direction.y = 0;
        }
        else if(Input.GetKey(KeyCode.S)||Input.GetKey(KeyCode.DownArrow))
        {
            direction.y = -1;
        }
        else if(Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.UpArrow))
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

    // void Flip()
    // {
    //     // Switch the way the player is labelled as facing
    //     facingRight = !facingRight;

    //     // Multiply the player's x local scale by -1
    //     Vector3 theScale = transform.localScale;
    //     theScale.x *= -1;
    //     transform.localScale = theScale;
    // }

    // public void fixRight()
    // {
    //     if (facingRight == false)
    //     {
    //         Flip();
    //     }
    // }
}
