using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorColor : MonoBehaviour
{
    private GameObject plyr;
    // Start is called before the first frame update
    void Start()
    {
        plyr = GameObject.FindWithTag("Player");

        int level = plyr.GetComponent<PlayerStats>().GetLevel();

        if (level == 1)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(142f,229f,128f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
