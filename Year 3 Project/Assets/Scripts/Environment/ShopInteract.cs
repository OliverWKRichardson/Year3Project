using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ShopInteract : MonoBehaviour
{

    private PlayerStats stats;
    public GameObject Exitbtn;
    public GameObject Helpbtn;
    public GameObject shopGUI;
    public GameObject menuGUI;
    public GameObject helpGUI;
    public GameObject interact;
    private Boolean entered = false;
    private Boolean debounce = false;
    // Start is called before the first frame update
    void Start()
    {
        stats = this.gameObject.GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((entered == true && Input.GetKeyDown(KeyCode.E)))
        {
            if (debounce == false)
            {
                openShop();
            }
            else
            {
                closeShop();
            }
        }

       
        


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.tag == "Shop")
        {
            entered = true;
            interact.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Shop")
        {
            entered = false;
            interact.SetActive(false);
            
            closeShop();
  
            
        }

        //Destroy SHOP GUI here.
    }


    void openShop()
    {
        debounce = true;

        menuGUI.SetActive(true);
        shopGUI.SetActive(true);
        Exitbtn.SetActive(true);
        Helpbtn.SetActive(true);

    }

    public void closeShop()
    {
        debounce = false;
        menuGUI.SetActive(false);
        shopGUI.SetActive(false);
        helpGUI.SetActive(false);
    }


    public void OpenHelpMenu()
    {
        shopGUI.SetActive(false);
        helpGUI.SetActive(true);
        Exitbtn.SetActive(false);
        Helpbtn.SetActive(false);
    }

    public void CloseHelpMenu()
    {
        shopGUI.SetActive(true);
        helpGUI.SetActive(false);
        Exitbtn.SetActive(true);
        Helpbtn.SetActive(true);
    }
//Need to take money on purchases in future game
    public void buyAC() {
        //Heal C to full 

        stats.setC(stats.getMaxC());
    
    }

    public void buyRS() {
        //Heal I to full
        stats.setI(stats.getMaxI());
    }

    public void buyAVS()
    {   //Heal A to full
        stats.setA(stats.getMaxA());
    }
   


}
