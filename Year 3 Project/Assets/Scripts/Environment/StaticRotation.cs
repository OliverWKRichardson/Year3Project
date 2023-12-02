using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class StaticRotation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()

        
    {
        //Debug.Log(this.transform.parent.localEulerAngles);
        if (this.transform.parent.localEulerAngles != new Vector3(0, 0, 90))
        {
            
            this.transform.localEulerAngles = new Vector3(0, 0, 0);
            this.transform.localScale = new Vector3(4, 0.400000066f, 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
