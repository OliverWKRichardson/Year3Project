using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Runtime.InteropServices;
using UnityEngine;
using Random = UnityEngine.Random;

public class MapCreate : MonoBehaviour
{

    public List<GameObject> rooms;



    public MapgenScript mapscript;

    public int width = 40;
    public int length = 24;
    // Start is called before the first frame update
    void Start()

    {
        createMap();

    }

    // Update is called once per frame
    void Update()
    {

    }

    [ContextMenu("TestCreate")]
    public void createMap()
    {


        Room[,] map = mapscript.getMap();

        for (int i = 0; i < map.GetLength(0); i++)
        {
            for (int j = 0; j < map.GetLength(1); j++)
            {
                Room temp = map[i, j];
                if (temp == null)
                {
                    Debug.Log("E");
                }
                else
                {
                    Debug.Log(temp.getType());
                }
            }
        }

        int rows = map.GetLength(0);
        int cols = map.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)



            {

                if (map[i, j] == null)
                {
                    continue;
                }
                spawnRoom(i, j, map); ;

            }
            //
        }

    }

    public void spawnRoom(int i, int j, Room[,] map)
    {

        string roomcode = checkNeighbours(i, j, map);

        //Debug.Log("i: " + i + " j: " + j);
        //string stringcode = "";
        //for (int x = 0; x < roomcode.Count; x++)
        //{
        // stringcode = stringcode + roomcode[x];

        // }

        //Debug.Log(stringcode);


        GameObject floor = Instantiate(rooms[0], new Vector2(40f * j, 24f * i), Quaternion.identity);
        floor.transform.position = new Vector3(floor.transform.position.x, floor.transform.position.y, 1f);
        if (roomcode.Contains("U"))
        {
            //instantiateRoom(2, floor, 0.274f, 0.5f, 90f);
            //instantiateRoom(6, floor, 7.5e-05f, 0.495f, 90);






            //GameObject wall = Instantiate(rooms[2], new Vector2(floor.transform.position.x, floor.transform.position.y), Quaternion.Euler(0f,0f,90f), floor.transform);
            //wall.transform.localPosition = new Vector3 (0f, 0.49f, 0f);

        }
        else
        {
            instantiateRoom(1, floor, 0, 0.495f, 90);


        }

        if (roomcode.Contains("D"))
        {
            instantiateRoom(2, floor, -0.265f, -0.495f, 90);
            instantiateRoom(2, floor, 0.265f, -0.495f, 90);
            instantiateRoom(6, floor, -7.5e-05f, -0.495f, 90);



            //GameObject wall = Instantiate(rooms[2], new Vector2(floor.transform.position.x, floor.transform.position.y), Quaternion.Euler(0f, 0f, 90f), floor.transform);
            //wall.transform.localPosition = new Vector3(0f, -0.49f, 0f);


        }
        else
        {
            instantiateRoom(1, floor, 0f, -0.495f, 90);



        }

        if (roomcode.Contains("L"))
        {
            instantiateRoom(4, floor, -0.49695f, 0.27625f, 0f);
            instantiateRoom(4, floor, -0.49695f, -0.27625f, 0f);

            instantiateRoom(6, floor, -0.497f, -0.0004166667f, 0);
        }

        else
        {
            instantiateRoom(3, floor, -0.49725f, 0f, 0f);
        }

        if (roomcode.Contains("R"))
        {
            //instantiateRoom(4, floor, 0.49695f, 0.27625f, 0f);
            //instantiateRoom(4, floor, 0.49695f, -0.27625f, 0f);

        }
        else
        {
            instantiateRoom(3, floor, 0.49725f, 0f, 0f);
        }

        roomFill(roomcode, floor, map[i, j]);



    }

    public void roomFill(string roomcode, GameObject floor, Room givenroom)
    {
        float roomlayout = Random.Range(0, 2);

        //Attack Room Generation
        if (givenroom.getType() == 2)
        {
            if (roomcode.Equals("LR"))
            {
                {
                    if (roomlayout == 0f)
                    {
                        GameObject formation =instantiateRoom(8, floor, 0, 0, 0);
                        formation.transform.localScale = new Vector3(1f, 1f, 1f);
                    }
                    if (roomlayout == 1f)
                    {
                        GameObject formation = instantiateRoom(9, floor, 0, 0, 90);
                        formation.transform.localScale = new Vector3(1.5f, 0.699999988f, 1f);
                    }
                    return;
                }
            }
            if (roomcode.Equals("UD"))
            {
                if (roomlayout == 0f)
                {
                    GameObject formation = instantiateRoom(8, floor, 0, 0, 90);
                    formation.transform.localScale = new Vector3(1f, 0.800000012f, 1f);
                }

                if (roomlayout == 1f)
                {
                    GameObject formation = instantiateRoom(9, floor, 0, 0, 0);
                    formation.transform.localScale = new Vector3(0.9f, 0.9f, 1f);
                }
                return;
            }
            instantiateRoom(7, floor, 0, 0, 0);
            return;
        }

        //
        if (givenroom.getType() == 1)
        {
            instantiateRoom(10, floor, 0, 0, 0);
        }

        if (givenroom.getType() == 5)
        {
            GameObject spawner = instantiateRoom(5, floor, 0, 0, 0);
            GameObject respawnpad = instantiateRoom(11, floor, 0, 0, 0);
            spawner.name = "StartPoint";
        }
        //

        if (givenroom.getType() == 4)
        {
            instantiateRoom(13, floor, 0f, 0f, 0f);
        }

        if (givenroom.getType() == 3)
        {
            instantiateRoom(13, floor, 0.07f, 0f, 0f);
        }
    }
    public GameObject instantiateRoom(int roomid, GameObject floor, float xoffset, float yoffset, float zrotation)
    {
        GameObject wall = Instantiate(rooms[roomid], new Vector2(floor.transform.position.x, floor.transform.position.y), Quaternion.Euler(0f, 0f, zrotation));
        wall.transform.parent = floor.transform;
        wall.transform.localPosition = new Vector3(xoffset, yoffset, 0f);
        return wall;

    }

    public string checkNeighbours(int i, int j, Room[,] map)
    {
        string parts = "";

        if (i < map.GetLength(0) - 1)
        {
            if (map[i + 1, j] != null)
            {
                parts = parts + ("U");
            }
        }

        if (i > 0)
        {
            if (map[i - 1, j] != null)
            {
                parts = parts + ("D");
            }
        }

        if (j > 0)
        {
            if (map[i, j - 1] != null)
            {
                parts = parts + ("L");
            }
        }
        if (j < map.GetLength(1) - 1)
        {
            if (map[i, j + 1] != null)
            {
                parts = parts + ("R");
            }
        }

        return parts;
    }

    public Boolean roomcheck(Room givenRoom)
    {
        if (givenRoom == null)
        {
            return false;
        }
        else
        {
            return true;
        }

    }
}
