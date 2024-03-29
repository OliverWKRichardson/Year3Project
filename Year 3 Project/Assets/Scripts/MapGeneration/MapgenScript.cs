using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Serialization.Json;
using Unity.Collections.LowLevel.Unsafe;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;


public class MapgenScript : MonoBehaviour
{

    public struct coordinates
    {
        private int x, y;

        public coordinates(int x, int y)
        {
            this.x = x; this.y = y;
        }
        public int getx() { return x; }
        public int gety() { return y; }


    }
    private int MAX_ROOMS = 12;
    private int minMap = 5;
    private int maxMap = 5;

    private int mapX;
    private int mapY;

    private Stack<coordinates> coordstack = new Stack<coordinates>();
    private Room?[,] roomarray;
    private coordinates bosscoords;
    private coordinates startcoords;
    private int MAX_SHOPS = 2;
    private int shopcounter = 0;
    private int MAX_COINS = 2;
    private int coincounter = 0;
    private int roomcounter = 0;
    private int greatestX {get; set; }
    private int greatestY { get; set; }
    private int smallestX { get; set; }
    private int smallestY { get; set; }

    private Boolean spawnroomexists = false;

    //private Room room;

    // Start is called before the first frame update
    void Start()
    {
        generateMap();
        if (bossDistance(startcoords.getx(), startcoords.gety()) < 3) {
            shopcounter = 0;
            coincounter = 0;
            roomcounter = 0;
            spawnroomexists = false;
            coordstack = new Stack<coordinates>();
            Start(); }
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Modern Fisher-Yates shuffle algo, Richard Durstenfeld in 1964
    //An unbiased permutation order for which way to travel when generating rooms.

    [ContextMenu("testshuffe")]
    public void testShuffle()
    {
        int[] order = orderShuffle();

        foreach (int i in order)
        {
            Debug.Log(i);
        }
    }

    //Modern Fisher-Yates shuffle algo, Richard Durstenfeld in 1964
    //An unbiased permutation order for which way to travel when generating rooms.
    public List<coordinates> coordsshuffle(List<coordinates> coords)
    {

        for (int i = coords.Count - 1; i >= 1; i--)
        {

            int gen = Random.Range(0, i+1);

            //Tuple swap of values is a way of swapping values in C#




            (coords[i], coords[gen]) = (coords[gen], coords[i]);


        }

        return coords;
    }


    public int[] orderShuffle()
    {

        int[] order = { 1, 2, 3, 4 };

        for (int i = 3; i >= 1; i--)
        {

            int gen = Random.Range(0, i+1);

            //Tuple swap of values is a way of swapping values in C#




            (order[i], order[gen]) = (order[gen], order[i]);

        }
        return order;
    }

    public double bossDistance(int x, int y)
    {
        //Euclidean Distance Formula
        int bossx = bosscoords.getx();
        int bossy = bosscoords.gety();

        return Math.Sqrt(((bossx - x) ^ 2 + (bossy - y) ^ 2));



    }



    public Room generateRoom(int x, int y)
    //null == Empty Room
    //1 == Boss Room
    //2 == Attack Room
    //3 == Shop Room
    //4 == Coin Room
    //5 == Spawn Room
    {

        //Could clean up code here and remove some of the room counters place it after the firszt conditional.
        if (smallestX > x)
        {
            smallestX = x;
        }
        if (smallestY > y)
        {
            smallestY = y;
        }
        if (greatestX < x)
        {
            greatestX = x;
        }

        if (greatestY < y)
        {
            greatestY = y;
        }
        if (roomcounter == 0) {
            roomcounter++;
            return new Room(1, null, null, null, null);
        }

        //Primitive case for spawn room not existing when there are no rooms left. Doesn't factor distance from Boss room, this could be a potential issue.
        // Potential fix -> Run generations until spawn room exists randomly or use math to determine when you get last "ideal spawn room chance".
        if (roomcounter == MAX_ROOMS-1 && spawnroomexists == false)
        {
            roomcounter++;
            spawnroomexists = true;
            startcoords = new coordinates(x, y);

            return new Room(5, null, null, null, null);

        }
        //Formula for spawning start Room is  if rng <= (n * EuclideanDistance) 
        //Start Room spawning

        int sprng = Random.Range(3, 15);
       
        if (sprng < 4 * bossDistance(x, y) && spawnroomexists == false)
        {

            roomcounter++;
            spawnroomexists = true;
            startcoords = new coordinates(x, y);
            return new Room(5, null, null, null, null);
        }

        if (coordstack.Count == 0 && spawnroomexists == false)
        {
            roomcounter++;
            spawnroomexists = true;
            startcoords = new coordinates(x, y);
            return new Room(5, null, null, null, null);
        }

        int rng = Random.Range(0, 20);

           if ((shopcounter < MAX_SHOPS) && roomcounter >= 4 && (rng>=10 && rng <=15 ))
        {
            roomcounter++;
            shopcounter++;
            return new Room(3, null, null, null, null);
        }
        //if (rng > 13 && (coincounter < MAX_COINS) && bossDistance(x,y) >= 2)
        //{
          //  roomcounter++;
           // coincounter++;
            //return new Room(4, null, null, null, null);

        //}


        roomcounter++;
        return new Room(2, null, null, null, null);
        
    
    }

    public void fillMap(int x, int y)
    {
        if ((roomarray[x, y] == null) && (roomcounter < MAX_ROOMS))

        {     

            roomarray[x, y] = generateRoom(x,y);
            List<coordinates> coordlist = new List<coordinates>(4);


            if (x > 0) {
                coordinates up = new coordinates(x - 1, y);
                coordlist.Add(up);
                
            }

            if (x < mapX-1) {
                coordinates down = new coordinates(x + 1, y);
                coordlist.Add(down);

            }

            if (y > 0) {
                coordinates left = new coordinates(x, y - 1); 
                coordlist.Add(left);

            }
            if (y < mapY-1) {
                coordinates right = new coordinates(x, y + 1);
                coordlist.Add(right);

            }


            coordlist = coordsshuffle(coordlist);
            //Put them on stack after shuffling

            foreach(coordinates i in coordlist)
            {
                coordstack.Push( i);

            }

            coordinates next = coordstack.Pop();
            fillMap(next.getx(), next.gety());
            

            
        }
        else if ((coordstack.Count > 0) && (roomcounter <MAX_ROOMS))
        {
            coordinates next = coordstack.Pop();
            fillMap(next.getx(), next.gety());

        }

        








    }
    public void generateMap()
    {
        //Randomly Define Map X & Y Maximum Size
        mapX = Random.Range(minMap, maxMap);
        mapY = Random.Range(minMap, maxMap);
        roomarray = new Room[mapX, mapY];

        greatestX = Random.Range(0, mapX);
        greatestY = Random.Range(0, mapY);
        smallestX = greatestX;
        smallestY = greatestY;
        bosscoords = new coordinates(greatestX, greatestY);

        //Now we have boss coords **SOMEWHERE** on the map.


        fillMap(bosscoords.getx(),bosscoords.gety());


        


    }

    public Room[,] getMap()
    {
        return roomarray;
    }

    [ContextMenu ("test print random map")]
    public void testprint()
    {
        

        
        for (int i = 0; i<mapX; i++)
        {
            Debug.Log("-------");
            for (int j =0; j<mapY; j++)
            {
                if (roomarray[i,j] == null)
                {
                    Debug.Log("E");
                    continue;
                }   
                Debug.Log(roomarray[i, j].getType());
            }
        }

    }

    public int getGreatestX()
    {
        return greatestX;

    }
    public int getGreatestY()
    {
        return greatestY;

    }
    public int getSmallestX()
    {
        return smallestX;

    }
    public int getSmallestY()
    {
        return smallestY;

    }

    public int getArryMaxX()
    {
        return mapX;
    }
    public int getArryMaxY()
    {
        return mapY;
    }
    public Boolean CheckNeighbour(int i, int j, char output)
    {

        Boolean checkNeighbourColumns = false;
        int num = 0;
        if (output == 'r'){
            num = 1;
        }
        else if (output == 'l')
        {
            num = -1;
        }

        

        for (int x = getSmallestX()+1; x < getGreatestX(); x++)
        {



            checkNeighbourColumns = (checkNeighbourColumns || roomarray[i, j + num] == null);
        }

        return  checkNeighbourColumns; }
    }
    
  

