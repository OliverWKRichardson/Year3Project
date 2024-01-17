using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialStart : MonoBehaviour
{
    private GameObject dm;
    private DialogScript ds;

    // Start is called before the first frame update
    void Start()
    {
        dm = GameObject.FindWithTag("DialogueSystem").gameObject;
        ds = dm.GetComponent<DialogScript>();
        string[] dialog = new string[1];
        dialog[0] = "System: Firewall AI Deployed. Welcome to the organization's network. This is an area of the network where threats have not been detected. We will train you as an AI model here to efficiently defend against cybersecurity adversaries. Press E at anytime during dialogue to skip to the end, press E again to end dialogue.";
        ds.addDialog(dialog);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
