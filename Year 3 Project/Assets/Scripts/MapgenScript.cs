using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapgenScript : MonoBehaviour
{   
    private Room[,] roomgen;
    //private Room room;

    // Start is called before the first frame update
    void Start()
    {
        //generateMap();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Room[,] generateMap()
    {
        roomgen = new Room[4,4];
        Room boss = new Room(0, null, null, null, null);
        int x = Random.Range(0, 3);
        int y = Random.Range(0, 3);
        Debug.Log(boss.getType());
        roomgen[x, y] = boss;

        for (int i = 0; i < 4; i++)
        {
            for (int k = 0; k < 4; k++)
            {

                if (roomgen[i, k] != null)
                {
                    continue;
                }
                //At the moment room type is completely even chance of 50% type 1 50% type 2
                //Need to make type 2 more rare as we don't want an abundance of shops -> Mess with the RNG.
                int roomtype = Random.Range(1, 3);
                

                Room room = new Room(roomtype, null, null, null, null);

                // Set neighbours of rooms depending on their position on the 2D Array
                // Keeping neighbour fields incase they are useful, will delete if i only end up using their actual array positions to determine neighbour in code.
                if (i > 0)
                {
                    room.setRoom("up", roomgen[i - 1, k]);
                }
                if (i < 3)
                {
                    room.setRoom("down", roomgen[i + 1, k]);
                }
                if (k > 0)
                {
                    room.setRoom("left", roomgen[i, k - 1]);
                }
                if (k < 3)
                {
                    room.setRoom("right", roomgen[i, k + 1]);
                }
                roomgen[i, k] = room;

            }
        }
        return roomgen;


    }

    [ContextMenu ("test print random map")]
    public void testprint()
    {
        Room[,] myrooms = generateMap();

        
        for (int i = 0; i<4; i++)
        {
            System.Console.WriteLine("Can you see this?");
            Debug.Log("-------");
            for (int j =0; j<4; j++)
            {
                Debug.Log(myrooms[i, j].getType());
            }
        }

    }
}
