using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public class Question
{
    public string questionText;
    public string[] options;
    public string correctAnswer;
    public string explanation;
}


public class QuizManager : MonoBehaviour
{
    public static QuizManager instance;

    public string jsonFilePath;

    public Questions questions;

    public TextAsset jsonFile;

    public QuestionData[] allQuestions;

    private List<Question> remainingQuestions; // List to track remaining questions

    private void Awake()
    {
        // Only one instance exists -- should be already handled by QuizSpawner
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instances
        }
    }

    private void Start()
    {
        // Initialize remainingQuestions with allQuestions data
        questions = GetComponent<JSONReader>().questionsInJSON;
        allQuestions = questions.questions;
      
    }

    public QuestionData GetRandomQuestion()
    {

       // Random rand = new Random();

        int index = Random.Range(0, allQuestions.Length);

        return getQuestionData(index);


    }

    public QuestionData getQuestionData(int index)
    {
        return allQuestions[index];
    }





}
