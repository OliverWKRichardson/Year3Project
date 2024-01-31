using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class QuizManager : MonoBehaviour
{


    public static QuizManager Instance { get; private set; }


    public string jsonFilePath;

    public Questions questions, inputQs;

    public TextAsset jsonFile;

    public QuestionData[] allQuestions;

    public QuestionData[] allInputQuestions;

    // private static List<Question> remainingQuestions; // List to track remaining questions

    private void Awake()
    {
        // Only one instance exists -- should be already handled by QuizSpawner

        Instance = this;
        // DontDestroyOnLoad(gameObject); 


    }

    private void Start()
    {
        // Initialize remainingQuestions with allQuestions data
        questions = GetComponent<JSONReader>().questionsInJSON;
        inputQs = GetComponent<JSONReader>().inputQuestions;
        allQuestions = questions.questions;
        allInputQuestions = inputQs.questions;

    }

    public QuestionData GetRandomQuestion()
    {


        int index = Random.Range(0, allQuestions.Length - 1);
        Debug.Log(index);

        return getQuestionData(index);


    }

    public QuestionData getQuestionData(int index)
    {
        return allQuestions[index];
    }

    public QuestionData getRandomInputQuestion()
    {

        int index = Random.Range(0, allInputQuestions.Length - 1);

        return getInputQuestionData(index);
        
    }

    public QuestionData getInputQuestionData(int index)
    {
        return allInputQuestions[index];
    }



}
