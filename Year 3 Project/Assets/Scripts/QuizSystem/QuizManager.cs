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

    public TextAsset jsonFile;

    public Question[] allQuestions;

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
        remainingQuestions = new List<Question>(allQuestions);
        LoadQuestionsFromJson();
    }

    public Question GetRandomQuestion()
    {
        if (remainingQuestions.Count == 0)
        {
            // TO DO: repeats
        }

        int randomIndex = Random.Range(0, remainingQuestions.Count);
        Question selectedQuestion = remainingQuestions[randomIndex];

        // Remove the selected question to avoid repetition
        remainingQuestions.RemoveAt(randomIndex);

        return selectedQuestion;
    }


    public void LoadQuestionsFromJson()
    {   
        if (jsonFile != null)
        {
            string quizData = jsonFile.text;
            allQuestions = JsonUtility.FromJson<Question[]>(quizData);
            
            if (allQuestions != null)
            {
                remainingQuestions = new List<Question>(allQuestions);
                // Debug.Log("Questions loaded from JSON file");
            }
            else
            {
                Debug.Log("Error: Parsing questions from JSON failed");
            }
        }
        else
        {
            Debug.Log("Error: jsonFile is null.");
        }
    }



}
