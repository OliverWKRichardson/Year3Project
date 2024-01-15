using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialDialogueS1 : MonoBehaviour
{
    // Start is called before the first frame update

    private GameObject dialog;
    private void Start()
    {
        dialog = GameObject.FindWithTag("DialogueSystem");

        dialog.SetActive(true);

        DialogScript ds = dialog.GetComponent<DialogScript>();

        ds.SetText("System: Firewall AI Deployed. Welcome to the organization's network. This is an area of the network where threats have not been detected. We will train you as an AI model here to efficiently defend against cybersecurity adversaries. Press E at anytime during dialog to skip to the end.");

    }

    
    
}
