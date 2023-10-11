using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Runtime.InteropServices;
using UnityEngine;

public class MapCreate : MonoBehaviour
{
    public GameObject room;

    public MapgenScript mapscript;

    public int width = 40;
    public int length = 24;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [ContextMenu ("TestCreate")]
    public void createMap()
    {
        mapscript.generateMap();

        Room[,] map = mapscript.getMap();

        int rows = map.GetLength(0);
        int cols = map.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)



            {
                //spawnRoom(i, j,map); ;
                Instantiate(room, new Vector2(40f * j, 24f * i ), Quaternion.identity);
                
            }
//
        }    

    }
    // Up Down Left Right
    // 1  2    3    4
    // Spawn the correct room & adjust transformation based on the concatenation / room code
    
    /**
    public void spawnRoom(int i, int j, Room[,] map)
    {
        string roomcode =  checkNeighbours(i, j,map);

        
    }
    **/
    /**public string checkNeighbours(int i, int j, Room[,] map)
    {
        string roomcode = "";
        if (i > 0)
        {
            Room currentroom = map[i - 1, j];

            if (currentroom != null)
            {
                try
                {
                    int type = currentroom.getType();
                    roomcode = roomcode + type;

                }
                catch (Exception e) { Debug.Log("Null room type"); }
            }
            

        }
    }
    **/
    
}
