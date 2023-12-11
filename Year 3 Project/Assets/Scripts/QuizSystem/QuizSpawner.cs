using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
// using Newtonsoft.Json;



public class QuizSpawner : MonoBehaviour
{
    private bool quizTriggered = false;
    public GameObject quizScreenPrefab;

    public string[] questions;

    public List<string[]> answersList;

    public QuizManager quizManager;

    private PlayerCharacterMovement playerMovement;

    private GameObject generatedQuiz;

    private System.Random rand = new System.Random();

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered range");

            if (!quizTriggered)
            {
                playerMovement = other.GetComponent<PlayerCharacterMovement>();
                playerMovement.DisablePlayerMovement();

                generatedQuiz = Instantiate(quizScreenPrefab, other.transform.position, Quaternion.identity);
                Debug.Log(!generatedQuiz);
                quizTriggered = true;
                GetComponent<Collider2D>().enabled = false;
              //  setQuizTexts();
              setQuestions();
            }
        }
    }

    public void setQuestions()
    {   
        // readQuestionsFromJSON();
        hardcodeQuestions();
        Transform menuCenter = generatedQuiz.transform.Find("QA/Menu Center");
        Transform question = menuCenter.transform.Find("Canvas/QuestionText");

        Transform button1 = menuCenter.transform.Find("Canvas/Answer 1 Button");
        Transform button2 = menuCenter.transform.Find("Canvas/Answer 2 Button");
        Transform button3 = menuCenter.transform.Find("Canvas/Answer 3 Button");
        Transform answerText1 = button1.transform.Find("AnswerText1");
        Transform answerText2 = button2.transform.Find("AnswerText2");
        Transform answerText3 = button3.transform.Find("AnswerText3");


        QuestionData questionData = quizManager.GetRandomQuestion();
        question.gameObject.GetComponent<Text>().text = questionData.question;

        answerText1.gameObject.GetComponent<Text>().text = questionData.correctAnswer;
        answerText2.gameObject.GetComponent<Text>().text = questionData.incorrectAnswer1;
        answerText3.gameObject.GetComponent<Text>().text = questionData.incorrectAnswer2;
    
       
      
    }


    void QuizCleared()
    {
        playerMovement.EnablePlayerMovement();
        Destroy(generatedQuiz);
        Destroy(transform.parent.gameObject);
    }


}
