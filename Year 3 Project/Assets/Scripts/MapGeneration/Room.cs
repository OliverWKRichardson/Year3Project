using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



            /** Room codes
             * 0 -> Boss
             * 1 -> Encounter/Attack Room
             * 2 -> Shop Room
             */

public class Room
{

    private Room left;
    private Room right;
    private Room up;
    private Room down;
    private int? leveltype;

    public Room(int? leveltype, Room left, Room right, Room up, Room down)
    {
        this.leveltype = leveltype;
        this.left = left;
        this.right = right;
        this.up = up;
        this.down = down;
    }

    // getter for different neighbours
    public Room getRoom(string room)
    {
        if (room == "left")
        {
            return left;
        }
        if (room == "right")
        {
            return right;
        }
        if (room == "up")
        {
            return up;
        }
        if (room == "down")
        {
            return down;
        }
        return null;

    }

    // setter for different neighbours
    public void setRoom(string room, Room givenRoom)
    {
        if (room == "left")
        {
            left = givenRoom;
        }
        if (room == "right")
        {
            right = givenRoom;
        }
        if (room == "up")
        {
            up = givenRoom;
        }
        if (room == "down")
        {
            down = givenRoom;
        }

    }

    public void setType(int type)
    {
        leveltype = type;
    }

    public int getType()
    {
        if (leveltype == null)
        {
            throw new System.Exception("No level type contained for this room");
        }
        return (int)leveltype;
    }
    
}
