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
    private Boolean skipDialog = false;
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
            skipDialog = true;
        }
    }
    public void SetText(string text)
    {
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

        if (text.Length == index)
        {
            StartCoroutine(closeDialog());
            skipDialog = false;
        }
        else {
            StartCoroutine(textRoutine(text, index+1));
        }
    }

    IEnumerator closeDialog()
    {
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
    }
}
