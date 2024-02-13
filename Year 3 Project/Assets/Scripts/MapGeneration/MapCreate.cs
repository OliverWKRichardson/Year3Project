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

    private Room[,] mapdata;
    public int roomx;
    public int roomy;
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
        mapdata = mapscript.getMap();
        Room[,] map = mapscript.getMap();
        mapscript.testprint();

        for (int i = 0; i < map.GetLength(0); i++)
        {
            for (int j = 0; j < map.GetLength(1); j++)
            {
                Room temp = map[i, j];
                if (temp == null)
                {
                }
                else
                {
                    temp.getType();
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


        //Room base is instantiated here
        GameObject floor = Instantiate(rooms[0], new Vector2(roomx * j, roomy * i), Quaternion.identity);
        floor.transform.position = new Vector3(floor.transform.position.x, floor.transform.position.y, 1f);
        if (roomcode.Contains("U"))
        {
            //instantiateRoomComp(2, floor, 0.274f, 0.5f, 90f);
            //instantiateRoomComp(6, floor, 7.5e-05f, 0.495f, 90);






            //GameObject wall = Instantiate(rooms[2], new Vector2(floor.transform.position.x, floor.transform.position.y), Quaternion.Euler(0f,0f,90f), floor.transform);
            //wall.transform.localPosition = new Vector3 (0f, 0.49f, 0f);

        }
        else
        {
            instantiateRoomComp(1, floor, 0, 0.495f, 90);


        }

        if (roomcode.Contains("D"))
        {
            //Instantiate Left Door Wall
            instantiateRoomComp(2, floor, -0.265f, -0.495f, 90);
            //Instantiate Right Door Wall
            GameObject rw = instantiateRoomComp(2, floor, 0.265f, -0.495f, 90);
            rw.transform.Find("WallSprite").gameObject.GetComponent<SpriteRenderer>().flipY = true;
            GameObject BottomDoor = instantiateRoomComp(6, floor, -7.5e-05f, -0.495f, 90);
            BottomDoor.gameObject.transform.Find("SlantedDoorSprite").gameObject.SetActive(true);



            //GameObject wall = Instantiate(rooms[2], new Vector2(floor.transform.position.x, floor.transform.position.y), Quaternion.Euler(0f, 0f, 90f), floor.transform);
            //wall.transform.localPosition = new Vector3(0f, -0.49f, 0f);


        }
        else
        {
            GameObject wwall = instantiateRoomComp(1, floor, 0f, -0.495f, 90);

            if (i == mapscript.getSmallestX())
            {


                GameObject ws = wwall.gameObject.transform.Find("wallsprite").gameObject;
                ws.gameObject.GetComponent<SpriteRenderer>().flipX = true;
                //ws.transform.position = new Vector3(2.9f, ws.transform.position.y, ws.transform.position.z); 
                GameObject ws2 = wwall.gameObject.transform.Find("wallsprite2").gameObject;

                ws2.GetComponent<SpriteRenderer>().flipX = true;


                /**
                 * Check For Vertical Walls
                 */
                Boolean checkNeighbourColumnsLeft = false;
                Boolean checkNeighbourColumnsRight = false;
                for (int x = mapscript.getSmallestX(); x < mapscript.getGreatestX();x++)
                {
                    if (j == mapscript.getGreatestY())
                    {
                        checkNeighbourColumnsLeft = (checkNeighbourColumnsLeft || mapdata[i, j - 1] == null);

                    }
                    else if (j == mapscript.getSmallestY())
                    {
                        checkNeighbourColumnsRight = (checkNeighbourColumnsRight || mapdata[i, j + 1] == null);

                    }
                    else
                    {
                        checkNeighbourColumnsLeft = (checkNeighbourColumnsLeft || mapdata[i, j - 1] == null);
                        checkNeighbourColumnsRight = (checkNeighbourColumnsRight || mapdata[i, j + 1] == null);
                    }

                }

                if (checkNeighbourColumnsLeft == false)
                {
                    ws.gameObject.transform.Find("LeftCorner").gameObject.SetActive(true);

                }
                if (checkNeighbourColumnsRight == false)
                {
                    ws2.gameObject.transform.Find("RightCorner").gameObject.SetActive(true);

                }
            }

            else
            {

            }


        }

        if (roomcode.Contains("L"))
        {
            GameObject TopWall = instantiateRoomComp(4, floor, -0.49695f, 0.27625f, 0f);
            GameObject TWSprite = TopWall.transform.Find("TopWall").gameObject;
            TWSprite.SetActive(false);

            TopWall.transform.Find("TopWallDark").gameObject.SetActive(true);


            //TDSprite.GetComponent<SpriteRenderer>().flipX = true;


            //Wall that spawns on bottom side of door needs sprite dark version.
            GameObject BotWall = instantiateRoomComp(4, floor, -0.49695f, -0.27625f, 0f);
            
            GameObject leftdoor = instantiateRoomComp(6, floor, -0.497f, -0.0004166667f, 0);
            leftdoor.gameObject.transform.Find("VerticalDoorSprite").gameObject.SetActive(true);
        }

        else
        {
            GameObject wall = instantiateRoomComp(3, floor, -0.49725f, 0.005f, 0f);

            //Debug.Log("J:" + j + " greatest Y:" + mapscript.getGreatestY());
            if (j == mapscript.getSmallestY())
            {
                GameObject ws = wall.transform.Find("wallsprite").gameObject;
                ws.SetActive(true);
                ws.GetComponent<SpriteRenderer>().flipX = true;
                GameObject ws2 = wall.transform.Find("wallsprite2").gameObject;
                ws2.SetActive(true);
                ws2.GetComponent<SpriteRenderer>().flipX = true;
                ws.transform.localPosition = new Vector3(-ws.transform.localPosition.x, ws.transform.localPosition.y, ws.transform.localPosition.z);
                ws2.transform.localPosition = new Vector3(-ws2.transform.localPosition.x, ws2.transform.localPosition.y, ws2.transform.localPosition.z);
                ws2.transform.Find("LeftThreeWay").gameObject.SetActive(true);
                
                if (i < mapscript.getGreatestX())
                {
                    if (mapdata[i + 1, j] == null)
                    {
                        ws.transform.Find("TopLeftCorner").gameObject.SetActive(true);


                    }
                }
                else if (i == mapscript.getGreatestX())
                {
                    ws.transform.Find("TopLeftCorner").gameObject.SetActive(true);
                }
                if (i == mapscript.getSmallestX())
                {
                    ws2.transform.Find("RightThreeWay").gameObject.SetActive(false);
                    ws2.transform.Find("LeftThreeWay").gameObject.SetActive(false);
                }

                else
                {
                    Boolean checkNeighbourColumnsLeft = false;
                    Boolean checkNeighbourColumnsRight = false;
                    for (int x = mapscript.getSmallestX(); x < mapscript.getGreatestX(); x++)
                    {
                        if (j == mapscript.getGreatestY())
                        {
                            checkNeighbourColumnsLeft = (checkNeighbourColumnsLeft || (mapdata[i, j - 1] != null));

                        }
                        else if (j == mapscript.getSmallestY())
                        {
                            checkNeighbourColumnsRight = (checkNeighbourColumnsRight || mapdata[i, j + 1] != null);

                        }
                        else
                        {
                            checkNeighbourColumnsLeft = (checkNeighbourColumnsLeft || mapdata[i, j - 1] != null);
                            checkNeighbourColumnsRight = (checkNeighbourColumnsRight || mapdata[i, j + 1] != null);
                        }

                    }

                    if (checkNeighbourColumnsLeft == false)
                    {
                        ws2.gameObject.transform.Find("SlantWallCorner").gameObject.SetActive(true);

                        if (i > mapscript.getSmallestX())
                        {
                            if (mapdata[i-1,j] != null)
                            {
                                ws2.gameObject.transform.Find("SlantWallCorner").gameObject.SetActive(false);
                            }
                            //ws2.gameObject.transform.Find("SlantWallCorner").gameObject.SetActive(false);

                        }




                    }
                    if (checkNeighbourColumnsRight == false)
                    {
                        // ws2.gameObject.transform.Find("SlantWallCorner").gameObject.SetActive(true);

                    }
                }

                if (i > mapscript.getSmallestX())
                {
                    if (mapdata[i - 1, j] == null)
                    {
                        ws2.transform.Find("RightThreeWay").gameObject.SetActive(false);
                        ws2.transform.Find("LeftThreeWay").gameObject.SetActive(false);
                    }
                }
                
                /**Boolean checkNeighbourColumnsLeft = false;
                Boolean checkNeighbourColumnsRight = false;
                for (int x = mapscript.getSmallestX(); x < mapscript.getGreatestX(); x++)
                {
                    if (j == mapscript.getGreatestY())
                    {
                        checkNeighbourColumnsLeft = (checkNeighbourColumnsLeft || (mapdata[i, j - 1] != null));

                    }
                    else if (j == mapscript.getSmallestY())
                    {
                        checkNeighbourColumnsRight = (checkNeighbourColumnsRight || mapdata[i, j + 1] != null);

                    }
                    else
                    {
                        checkNeighbourColumnsLeft = (checkNeighbourColumnsLeft || mapdata[i, j - 1] != null);
                        checkNeighbourColumnsRight = (checkNeighbourColumnsRight || mapdata[i, j + 1] != null);
                    }

                }

                if (checkNeighbourColumnsLeft == false)
                {
                    //ws.gameObject.transform.Find("SlantWallCorner").gameObject.SetActive(true);

                }
                if (checkNeighbourColumnsRight == false)
                {
                    ws2.gameObject.transform.Find("SlantWallCorner").gameObject.SetActive(true);

                }
            }**/
                
            
            
                /**if (i > mapscript.getSmallestX())
                {
                    if (mapdata[i - 1, j] == null)
                    {
                        ws2.transform.Find("RightThreeWay").gameObject.SetActive(false);
                        ws2.transform.Find("LeftThreeWay").gameObject.SetActive(false);
                    }
                }
                **/

            }
            else
            {
                wall.transform.Find("TopWall").gameObject.SetActive(true);
                if (i < mapscript.getGreatestX())
                {
                    if (mapdata[i + 1, j] == null)
                    {
                        wall.transform.Find("TopWall").gameObject.transform.Find("TopLeftCornerV2").gameObject.SetActive(true);


                    }
                }
                else if (i == mapscript.getGreatestX())
                {
                    wall.transform.Find("TopWall").gameObject.transform.Find("TopLeftCornerV2").gameObject.SetActive(true);
                }

                else if (i == mapscript.getSmallestX())
                {
                   // wall.transform.Find("TopWall").gameObject.transform.Find("BottomLeftCorner").gameObject.SetActive(true);
                }

                else if( i> mapscript.getSmallestX())
                {
                    if (mapdata[i - 1, j] == null)
                    {
                        wall.transform.Find("TopWall").gameObject.transform.Find("BottomLeftConer").gameObject.SetActive(true);
                    }
                }
            }
            

            /**GameObject ws = wall.transform.Find("wallsprite").gameObject;
            ws.GetComponent<SpriteRenderer>().flipX = true;
            GameObject ws2 = wall.transform.Find("wallsprite2").gameObject;
            ws2.GetComponent<SpriteRenderer>().flipX = true;
            ws.transform.localPosition = new Vector3(-ws.transform.localPosition.x, ws.transform.localPosition.y, ws.transform.localPosition.z);
            ws2.transform.localPosition = new Vector3(-ws2.transform.localPosition.x, ws2.transform.localPosition.y, ws2.transform.localPosition.z);**/
        }

        if (roomcode.Contains("R"))
        {
            //instantiateRoomComp(4, floor, 0.49695f, 0.27625f, 0f);
            //instantiateRoomComp(4, floor, 0.49695f, -0.27625f, 0f);

        }
        else
        {
            GameObject wall = instantiateRoomComp(3, floor, 0.49725f, 0.005f, 0f);


            Debug.Log("J:" + j + " greatest Y:" + mapscript.getGreatestY());
            if (j == mapscript.getGreatestY())
            {
                GameObject ws = wall.transform.Find("wallsprite").gameObject;
                ws.SetActive(true);
                GameObject ws2 = wall.transform.Find("wallsprite2").gameObject;
                ws2.SetActive(true);

                ws2.transform.Find("RightThreeWay").gameObject.SetActive(true);


                if (i < mapscript.getGreatestX())
                {
                    if (mapdata[i + 1, j] == null)
                    {
                        ws.transform.Find("TopRightCorner").gameObject.SetActive(true);

                    }
                }

                else if (i == mapscript.getGreatestX())
                {
                    ws.transform.Find("TopRightCorner").gameObject.SetActive(true);
                }

                if (i == mapscript.getSmallestX())
                {
                    ws2.transform.Find("RightThreeWay").gameObject.SetActive(false);
                    ws2.transform.Find("LeftThreeWay").gameObject.SetActive(false);
                }



                else if (mapdata[i-1,j] == null)
                {
                        ws2.transform.Find("RightThreeWay").gameObject.SetActive(false);
                        ws2.transform.Find("LeftThreeWay").gameObject.SetActive(false);
                }



                if (i > mapscript.getSmallestX()+1)
                    Debug.Log("current i!: " + i);
                Debug.Log("smallest X: " + mapscript.getSmallestX());

                {
                    try
                    {
                        //Check if room underneath exists
                        Debug.Log(i +"  "+j);
                        if (mapdata[i-1,j] == null)
                        {
                            ws2.transform.Find("CornerWall").gameObject.SetActive(true);

                        }
                        

                        

                    }
                    catch (Exception e)
                    {
                       // ws2.transform.Find("CornerWall").gameObject.SetActive(true);

                        
                        //No Room Underneath create corner wall.

                    }

                }
              

            }
            else
            {
                wall.transform.Find("TopWall").gameObject.SetActive(true);
            }
        }

        roomFill(roomcode, floor, map[i, j]);

        //Adjust Room Size here

        floor.transform.localScale = new Vector3(roomx, roomy, 1);



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
                        GameObject formation =instantiateRoomComp(8, floor, 0, 0, 0);
                        formation.transform.localScale = new Vector3(1f, 1f, 1f);
                    }
                    if (roomlayout == 1f)
                    {
                        GameObject formation = instantiateRoomComp(9, floor, 0, 0, 90);
                        formation.transform.localScale = new Vector3(1.5f, 0.699999988f, 1f);
                    }
                    return;
                }
            }
            if (roomcode.Equals("UD"))
            {
                if (roomlayout == 0f)
                {
                    GameObject formation = instantiateRoomComp(8, floor, 0, 0, 90);
                    formation.transform.localScale = new Vector3(1f, 0.800000012f, 1f);
                }

                if (roomlayout == 1f)
                {
                    GameObject formation = instantiateRoomComp(9, floor, 0, 0, 0);
                    formation.transform.localScale = new Vector3(0.9f, 0.9f, 1f);
                }
                return;
            }
            instantiateRoomComp(7, floor, 0, 0, 0);
            return;
        }

        //
        if (givenroom.getType() == 1)
        {
            instantiateRoomComp(10, floor, 0, 0, 0);
        }

        if (givenroom.getType() == 5)
        {
            GameObject spawner = instantiateRoomComp(5, floor, 0, 0, 0);
            GameObject respawnpad = instantiateRoomComp(11, floor, 0, 0, 0);
            spawner.name = "StartPoint";
        }
        //

        if (givenroom.getType() == 4)
        {
            instantiateRoomComp(13, floor, 0f, 0f, 0f);
        }

        if (givenroom.getType() == 3)
        {
            instantiateRoomComp(13, floor, 0.07f, 0f, 0f);
        }


    }
    public GameObject instantiateRoomComp(int roomid, GameObject floor, float xoffset, float yoffset, float zrotation)
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
