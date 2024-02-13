using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.XR;

public class Area1 : MonoBehaviour
{

    public Sprite sprt;
    private GameObject dm;
    // Start is called before the first frame update


    private DialogScript ds;

    private void Start()
    {
        dm = GameObject.FindWithTag("DialogueSystem").gameObject;
        ds = dm.GetComponent<DialogScript>();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "PlayerCharacter")
        {
            if (gameObject.name == "Area1")
            {
                Debug.Log(collision.gameObject.name);
                string[] dialog = new string[1];
                dialog[0] = "Test Environment Loaded. Clear the simulated hostiles in the network ahead and recover stolen data to proceed. There's a firewall ahead, a bypass script has been installed to assist in breaking the encryption. Simply walk into the firewall to begin. [After answering a question click to continue]";
                outputText(dialog);
                
            }

            if (gameObject.name == "Area2")
            {
                Debug.Log(collision.gameObject.name);
                {
                    string[] dialog = new string[1];
                    dialog[0] = "A more powerful adversary is ahead, prepare yourself.";
                    outputText(dialog);
                }

            }

            if (gameObject.name == "Area3")
            {
                string[] dialog = new string[1];
                dialog[0] = "Well done.You are now fully-trained and optimised for defending the network from threats.Continue to enter the compromised network.";
                outputText(dialog);
            }

        }
    }
    private void LateUpdate()
    {
        ds.SetImg(sprt);

    }

    private void outputText(string[] dialog)
    {
        //Stop The Text Output
        dm.SetActive(true);
        ds.addDialog(dialog);
        Destroy(gameObject);
        

    }
}
