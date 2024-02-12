using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class TextDisplayScript : MonoBehaviour, IPointerEnterHandler
{

    private TextMeshProUGUI abilitydesc;
    // Start is called before the first frame update
    private Boolean MouseEnter = false;
    private Boolean PointerExit = false;

    public void OnPointerEnter(PointerEventData evdata)
    {
        MouseEnter = true;
        
    }

    public void OnPointerExit(PointerEventData evdata)
    {
        PointerExit = true;
    }
    void Start()
    {
        abilitydesc = GameObject.FindWithTag("AbilityBox").GetComponent<TextMeshProUGUI>();
        Debug.Log(gameObject.name);
    }

    // Update is called once per frame
    void Update()
    {
        if (MouseEnter)
        {
            SetText();
        }
        if (PointerExit == true)
        {
            abilitydesc.SetText("Hover over the buy button of a control to see what it does!");
            PointerExit = false;
        }
    }


    private void SetText()
    {
        String objname = this.gameObject.name;
        switch (objname)
        {
            case "ACbtn":
                abilitydesc.SetText("Access Control: re-distribute priveleges and create an access control system among your organization. \n\n\n <color=\"yellow\"> <i>Restores confidentiality to your system. [consumed on purchase]");
                break;
            case "RSbtn":
                abilitydesc.SetText("Recovery  Systems: Use recovery systems such as data recovey software and back ups to restore lost data.\n\n\n <color=\"yellow\"> <i>Restores integrity to your system. [consumed on purchase]");
                break;
            case "AVbtn":
                abilitydesc.SetText("Anti-Virus Software: Software that removes viruses and other malware from the system.\n\n\n <color=\"yellow\"> <i>Restores availability [consumed on purchase]");
                break;
            case "IDSbtn":
                abilitydesc.SetText("Intrustion Detection System: A network control that monitors network traffic and devices to determine abnormal or malicious activity or violations of security policies. \n\n\n <color=\"yellow\"> <i> Threats appear on minimap");
                break;
            case "FWbtn":
                abilitydesc.SetText("Firewall: Controls the flow of netwrk traffic between an untrusted external network and an internal trusted network. \n\n\n <color=\"yellow\"> <i> Prevents a threat from initiating combat once.");
                break;
            case "IRPbtn":
                abilitydesc.SetText("Incident Response Plan: A planned response to minimize damage caused by a cyber incident/attack. \n\n\n <color=\"yellow\"> <i>Weakens the damage output of threats");
                break;
        }

        MouseEnter = false;
    }

}
