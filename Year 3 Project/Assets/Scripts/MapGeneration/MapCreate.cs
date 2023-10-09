using System.Collections;
using System.Collections.Generic;
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
                Instantiate(room, new Vector2(40f * j, 24f * i ), Quaternion.identity);
                
            }
//
        }    

    }

    
}
