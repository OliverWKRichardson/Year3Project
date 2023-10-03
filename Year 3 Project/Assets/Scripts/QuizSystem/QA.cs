using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QA : MonoBehaviour
{
    public GameObject MenuCenter;

    public GameObject question;

    // change to arrays
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;

    public GameObject AnswerText1;
    public GameObject AnswerText2;
    public GameObject AnswerText3;



    void Start()
    {
       question.GetComponent<UnityEngine.UI.Text>().text = "Placeholder question? Placeholder question?";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
