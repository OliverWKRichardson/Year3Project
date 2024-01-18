using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogtest : MonoBehaviour
{

    public GameObject dialog;
    private DialogScript ds;
    public Sprite img;
    
    // Start is called before the first frame update
    void Start()
    {
        ds = dialog.GetComponent<DialogScript>();
        ds.SetImg(img); 
        string[] msg = new string[2];
        msg[0] = "Network layer 1 loaded.";
        msg[1] = "This is the first and least challenging layer of the network, for each threat you neutralize you will earn NETCOINS, Spend NETCOINS at the World Wide Web to upgrade & maintenance your AI model.";
        //msg[2] = "Defeat the main threat of this network layer in order to gain access to the gateway to the next network layer.";
        ds.addDialog(msg);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
