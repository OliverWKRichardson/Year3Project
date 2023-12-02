using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopInteract : MonoBehaviour
{

    GameObject plyr;
    GameObject shopGUI;
    private Boolean entered = false;
    private Boolean debounce = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((entered == true && Input.GetKeyDown(KeyCode.E)))
        {
            actMenu();

        }


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            plyr = GameObject.Find("PlayerCharacter");
            shopGUI = plyr.transform.Find("ShopMenu").gameObject;
            entered = true;
            other.transform.Find("interactCanvas").gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            entered = false;
            other.transform.Find("interactCanvas").gameObject.SetActive(false);
            
        }

        //Destroy SHOP GUI here.
    }


    void actMenu()
    {
        if (debounce == true)
        {
            debounce = false;
            shopGUI.SetActive(true);
        }

        else
        {
            debounce = true;
            shopGUI.SetActive(false);
        }

    }


}
