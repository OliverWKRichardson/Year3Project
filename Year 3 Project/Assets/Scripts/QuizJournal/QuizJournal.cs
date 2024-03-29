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
    private Questions inputQuestionsInJSON;

    void Start()
    {
        canvas.SetActive(false);
        active = false;
        for(int i = 0; i < 60; i++)
        {
            questions.transform.GetChild(i).gameObject.SetActive(false);
        }
        questionsInJSON = GetComponent<JSONReader>().questionsInJSON;
        inputQuestionsInJSON = GetComponent<JSONReader>().inputQuestions;
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
        if(false)// disabled journal
        {
            if(active)
            {
                canvas.SetActive(false);
                active = false;
            }
            else
            {
                canvas.SetActive(true);
                active = true;
            }
        }
    }

    public void questionAsked(int index)
    {
        questions.transform.GetChild(index).gameObject.SetActive(true);
    }
}
