using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempfix : MonoBehaviour
{
    Boolean poscheck = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        if (poscheck == false)
        {

            GameObject.Find("PlayerCharacter").transform.position = GameObject.Find("StartPoint").transform.position + new Vector3(0,0,-1);
            poscheck = true;
            this.enabled = false;
        }
    }
}
