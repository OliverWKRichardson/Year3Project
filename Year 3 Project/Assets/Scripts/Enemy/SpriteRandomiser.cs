using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteRandomiser : MonoBehaviour
{
    private int rand;
    public Sprite[] SpriteOptions;
    // Start is called before the first frame update
    void Start()
    {
        rand = Random.Range(0,SpriteOptions.Length);
        GetComponent<SpriteRenderer>().sprite = SpriteOptions[rand];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
