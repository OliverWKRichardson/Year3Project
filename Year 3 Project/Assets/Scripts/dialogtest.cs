using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogtest : MonoBehaviour
{

    private PlayerStats ps;
    public GameObject dialog;
    private DialogScript ds;
    public Sprite img;
    
    // Start is called before the first frame update
    void Start()
    {

        ps = GameObject.FindWithTag("Player").GetComponent<PlayerStats>();
        ds = dialog.GetComponent<DialogScript>();
        ds.SetImg(img);

        Debug.Log(ps.GetLevel());
        if (ps.GetLevel() == 0)
        {
            string[] msg = new string[4];
            msg[0] = "Network layer 1 loaded.";
            msg[1] = "The protocols that allowed our routers to communicate are being disrupted on this network. A strong threat must have attacked a vulnerability in our system.";
            msg[2] = "This is the first and least challenging layer of the network, for each threat you neutralize you will earn NETCOINS, Spend NETCOINS at the World Wide Web to upgrade & maintenance your AI model.";
            msg[3] = "You must disable the main threat of this network layer to restore the availability of this network and the internet protocols. Then head to the next network layer.";
            ds.addDialog(msg);
        }

        if (ps.GetLevel() == 1)
        {
            string[] msg = new string[3];

            msg[0] = "Network layer 2 loaded.";
            msg[1] = "You've made it to layer 2, the last threat agent is somewhere in this network. Find and shut down the threat to protect our network's vulnerability.";
            msg[2] = "Becareful, the agent on this level is superior to the previous one.";
            ds.addDialog(msg);
            
        }
    }

   


    // Update is called once per frame
    void Update()
    {
        
    }
}
