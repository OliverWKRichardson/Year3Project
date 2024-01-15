using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogtest : MonoBehaviour
{

    public GameObject dialog;
    private DialogScript ds;
    
    // Start is called before the first frame update
    void Start()
    {
        ds = dialog.GetComponent<DialogScript>();
        ds.SetText("Hello World! YIPEEEEEEEEEEE BRUH");
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
