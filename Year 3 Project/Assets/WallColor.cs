using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallColor : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject plyr;
    // Start is called before the first frame update
    void Start()
    {
        plyr = GameObject.FindWithTag("Player");

        int level = plyr.GetComponent<PlayerStats>().GetLevel();

        if (level == 0)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(0f, 182f, 255f);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
