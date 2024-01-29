using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class DialogScript : MonoBehaviour
{
    //Boolean that states whether a dialog is currently in place (A set of messages that are being iterated through)
    private Boolean activeDialog = false;

    private Queue<String[]> DialogQ = new Queue<string[]>();
    //Boolean that states whether an individual message has been completed.
    private int msgIndex = 0;
    private int size = 0;
    private Boolean messageComplete = true;
    private Boolean skipDialog = false;
    private Boolean nextDialog = false;
    private GameObject img;
    public float textspeed;
    GameObject textcomp;
    // Start is called before the first frame update
    void Start()
    {
       
        textcomp = gameObject.transform.Find("Canvas").gameObject.transform.Find("Panel").gameObject;
        img = gameObject.transform.Find("Canvas").gameObject.transform.Find("charimage").gameObject;
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            if ((skipDialog == true))
            {
                nextDialog = true;
            }
            else
            {
                skipDialog = true;
            }
        }
       
        if (DialogQ.Count > 0)
        {
            if (activeDialog == false)
            {
                skipDialog = false;
                SendMessages(DialogQ.Dequeue());

            }
        }

        if (nextDialog == true)
        {
            StartCoroutine(closeDialog());
            skipDialog = false;
            nextDialog = false;
        }
    }
    public void SetText(string text)
    {
        img.SetActive(true);
        textcomp.SetActive(true);
        messageComplete = false;
        StartCoroutine(textRoutine(text, 1));

    }

    public void SetImg(Sprite image)
    {
        Image imgcomp = img.GetComponent<Image>();
        imgcomp.sprite = image;

    }

    IEnumerator textRoutine(string text, int index)
    {
        
        if (skipDialog == true){
            index = text.Length;
        }

        
        
        string substr = text.Substring(0, index);
        yield return new WaitForSeconds(textspeed);
        TextMeshProUGUI textc = textcomp.transform.Find("DialogText").gameObject.GetComponent<TextMeshProUGUI>();
        textc.SetText(substr);

        
        if ((text.Length == index))
        {
            skipDialog = true;
           
        }
        if (text.Length > index) { 
            StartCoroutine(textRoutine(text, index+1));
        }

        
    }

    IEnumerator closeDialog()
    {
        yield return new WaitForSeconds(0.01f);
        messageComplete = true;
        activeDialog = false;

        if (DialogQ.Count > 0)
        {
            wipeDialog();
        }
        if ((DialogQ.Count == 0))
        {
            resetDialog();
            img.SetActive(false);
        }
        
        
    }

    public void SendMessages(string[] messages)
    {

        activeDialog = true;
        size = messages.Length;
        msgIndex = 0;

        
        while ((msgIndex < size))

        {
            if (messageComplete == true)
            {
                SetText(messages[msgIndex]);


                msgIndex++;

                

            }

        }


        

        

       
        
        
    }

    public void addDialog(string[] messages)
    {
        if (messages.Length > 1)
        {
            for (int i = 0; i < messages.Length; i++)
            {
                string[] temp = new string[1];
                temp[0] = messages[i];
                addDialog(temp);

            }
            return;
        }
        DialogQ.Enqueue(messages);
    }
    public Boolean GetStatus()
    {
        return messageComplete;
    }

    public Boolean DialogStatus()
    {
        return activeDialog;
    }

    void wipeDialog()
    {

        TextMeshProUGUI text = textcomp.transform.Find("DialogText").GetComponent<TextMeshProUGUI>();
        text.SetText("");

    }

    void resetDialog()
    {

        TextMeshProUGUI text = textcomp.transform.Find("DialogText").GetComponent<TextMeshProUGUI>();
        text.SetText("");
        textcomp.SetActive(false);

    }
    void resetImage()
    {
        img.GetComponent<Image>().sprite = null;
        img.SetActive(false);
    }

    

   
}
