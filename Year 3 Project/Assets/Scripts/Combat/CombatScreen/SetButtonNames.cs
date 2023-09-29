using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetButtonNames : MonoBehaviour
{
    public Text button1;
    public Text button2;
    public Text button3;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.Find("PlayerCharacter");
        
        button1.text = player.GetComponent<Skills>().skill1Name;
        button2.text = player.GetComponent<Skills>().skill2Name;
        button3.text = player.GetComponent<Skills>().skill3Name;
    }
}
