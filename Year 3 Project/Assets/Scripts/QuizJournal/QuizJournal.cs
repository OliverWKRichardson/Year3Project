using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizJournal : MonoBehaviour
{
    public GameObject canvas;
    public GameObject questions;
    private bool active;
    private Questions questionsInJSON;

    void Start()
    {
        canvas.SetActive(false);
        active = false;
        for(int i = 0; i < 60; i++)
        {
            questions.transform.GetChild(i).gameObject.SetActive(false);
        }
        questionsInJSON = GetComponent<JSONReader>().questionsInJSON;
        int textIndex = 0;
        foreach(QuestionData question in questionsInJSON.questions)
        {
            questions.transform.GetChild(textIndex).gameObject.GetComponent<Text>().text = question.question + " Answer: " + question.correctAnswer;
            questions.transform.GetChild(textIndex).gameObject.SetActive(true); // WIP temp shows all loaded questions in journal remove when testing done
            textIndex++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.J))
        {
            if(active)
            {
                canvas.SetActive(false);
                active = false;
                Cursor.visible = false;
            }
            else
            {
                canvas.SetActive(true);
                active = true;
                Cursor.visible = true;
            }
        }
    }

    public void questionAsked(int index)
    {
        questions.transform.GetChild(index).gameObject.SetActive(true);
    }
}
