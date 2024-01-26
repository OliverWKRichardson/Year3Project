using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

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
        if ((entered == true && Input.GetKeyDown(KeyCode.F)))
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
    public void buyAC()
    {
        //Heal C to full 
        Debug.Log("Buying!");
        int money = gameObject.GetComponent<PlayerStats>().GetMoney();
        int price = GameObject.FindWithTag("ShopItems").gameObject.transform.Find("AC").gameObject.GetComponent<PriceScript>().getpriceVal();
        if (money >= price)
        {
            Debug.Log("AC1");
            stats.setC(stats.getMaxC());
            sendMsg("Access Control designated, running TECHNICAL control to REACT to bad actors in the network. Changes access levels of roles/members in the organization's network and increases the confidentiality of your system. ");
            //
        }
        else
        {
            sendMsg("You don't have enough NETCOIN.");

        }

    }

    public void buyRS()
    {

        //Heal I to full
        int money = gameObject.GetComponent<PlayerStats>().GetMoney();
        int price = GameObject.FindWithTag("ShopItems").gameObject.transform.Find("RS").gameObject.GetComponent<PriceScript>().getpriceVal();
        if (money >= price)
        {
            stats.setI(stats.getMaxI());
            sendMsg("Recovery system booted, running TECHNICAL control to REACT to active data loss from your system, restores lost data using back-ups and other protocols. Increases the integrity of your system. .");
        }
        else
        {
            sendMsg("You don't have enough NETCOIN.");

        }
    }

    public void buyAVS()
    {   //Heal A to full
        int money = gameObject.GetComponent<PlayerStats>().GetMoney();
        int price = GameObject.FindWithTag("ShopItems").gameObject.transform.Find("AVS").gameObject.GetComponent<PriceScript>().getpriceVal();
        if (money >= price)
        {
            stats.setA(stats.getMaxA());
            sendMsg("Antivirus system enabled, running TECHNICAL control to REACT to active viruses & malware from your system and remove them, increases the availability of your system.");
        }
        else
        {
            sendMsg("You don't have enough NETCOIN.");

        }

    }

    public void buyFW()
    {
        int money = gameObject.GetComponent<PlayerStats>().GetMoney();
        int price = GameObject.FindWithTag("ShopItems").gameObject.transform.Find("FW").gameObject.GetComponent<PriceScript>().getpriceVal();
        ;
        if (money >= price)
        {
            gameObject.transform.Find("Firewall").gameObject.SetActive(true);
            sendMsg("Firewall initialized. Running TECHNICAL control to PREVENT threats from enaging your system.");
        }
        else
        {
            sendMsg("You don't have enough NETCOIN.");
        }

    }
    public void buyIRP()
    {
        int money = gameObject.GetComponent<PlayerStats>().GetMoney();
        int price = GameObject.FindWithTag("ShopItems").gameObject.transform.Find("IRP").gameObject.GetComponent<PriceScript>().getpriceVal();
        if (money >= price)
        {
            GameObject[] gb = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (var item in gb)
            {
                EnemyStats es = item.gameObject.GetComponent<EnemyStats>();
                int rng = Random.Range(0, 2);

                //Weakenn The Enemies
                es.setATK(0.75f * es.getATK());

            }
            sendMsg("Incident Response Plan initiated. Running ADMINISTRATIVE control to REACT to and weaken existing threats in the system.");
        }
        else
        {
            sendMsg("You don't have enough NETCOIN.");

        }
    }

    public void buyIDS()
    {
        int money = gameObject.GetComponent<PlayerStats>().GetMoney();
        int price = GameObject.FindWithTag("ShopItems").gameObject.transform.Find("IDS").gameObject.GetComponent<PriceScript>().getpriceVal();
        if (money >= price)
        {
            
            //Intrustion Detection System
            GameObject[] gb = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (var item in gb)
            {
                item.gameObject.transform.Find("EnemyMMapSprite").gameObject.SetActive(true);
            }
            sendMsg("Intrusion Detection System activated. Running TECHNICAL control scans to DETECT threats, they will appear on your radar.");
        }
        else
        {
            sendMsg("You don't have enough NETCOIN.");

        }

    }

    private void sendMsg(String msg)
    {
        DialogScript ds = GameObject.FindWithTag("DialogueSystem").gameObject.GetComponent<DialogScript>();
        string[] dialog = new string[1];
        dialog[0] = msg;
        ds.addDialog(dialog);
    }

    


}
