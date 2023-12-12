using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class QuizManager : MonoBehaviour
{


    public static QuizManager Instance { get; private set; }


public string jsonFilePath;

public Questions questions;

public TextAsset jsonFile;

public QuestionData[] allQuestions;

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
    allQuestions = questions.questions;

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





}
