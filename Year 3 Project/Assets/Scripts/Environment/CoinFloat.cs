using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinFloat : MonoBehaviour
{

    Boolean descend = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (descend == false)
        {
            gameObject.transform.position = gameObject.transform.position + new Vector3(0, 0.005f, 0) * Time.deltaTime;
        }

        if (descend == true)
        {
            gameObject.transform.position = gameObject.transform.position + new Vector3(0, -0.005f, 0) * Time.deltaTime;        }
        
        if (gameObject.transform.position.y >= 1.8)
        {
            descend = true;

        }

        if (gameObject.transform.position.y <= 1.5)
        {
            descend = false;
        }

    }
}
