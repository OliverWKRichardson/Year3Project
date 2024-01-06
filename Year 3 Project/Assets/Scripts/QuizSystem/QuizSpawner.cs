using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using Pathfinding;
// using Newtonsoft.Json;



public class QuizSpawner : MonoBehaviour
{
    private bool quizTriggered = false;
    public GameObject quizScreenPrefab;

    public string[] questions;

    public List<string[]> answersList;

    private QuizManager quizManager;

    private PlayerCharacterMovement playerMovement;

    private GameObject generatedQuiz;

    private System.Random rand = new System.Random();

    private void Start()
    {
        quizManager = this.GetComponent<QuizManager>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered range");

            if (!quizTriggered)
            {
                //Disable enemy AI
                AIDestinationSetter.inCombat = true;

                playerMovement = other.GetComponent<PlayerCharacterMovement>();
                playerMovement.DisablePlayerMovement();

                generatedQuiz = Instantiate(quizScreenPrefab, other.transform.position, Quaternion.identity);
                //   Debug.Log(!generatedQuiz);
                quizTriggered = true;
                GetComponent<Collider2D>().enabled = false;

                quizManager = QuizManager.Instance;
                Debug.Log(quizManager);
                setQuestions();

            }
        }
    }

    public void setQuestions()
    {
        Transform menuCenter = generatedQuiz.transform.Find("QA/Menu Center");
        Transform question = menuCenter.transform.Find("Canvas/QuestionText");

        Transform button1 = menuCenter.transform.Find("Canvas/Answer 1 Button");
        Transform button2 = menuCenter.transform.Find("Canvas/Answer 2 Button");
        Transform button3 = menuCenter.transform.Find("Canvas/Answer 3 Button");
        Transform answerText1 = button1.transform.Find("AnswerText1");
        Transform answerText2 = button2.transform.Find("AnswerText2");
        Transform answerText3 = button3.transform.Find("AnswerText3");

        QuestionData questionData = quizManager.GetRandomQuestion();
        Debug.Log(questionData.question);
        question.gameObject.GetComponent<Text>().text = questionData.question;

        List<Transform> answerButtons = new List<Transform> { button1, button2, button3 };

        List<string> answers = new List<string> {
            questionData.correctAnswer,
            questionData.incorrectAnswer1,
            questionData.incorrectAnswer2
        };

        Shuffle(answerButtons);
        Shuffle(answers);

        for (int i = 0; i < answerButtons.Count; i++)
        {
            answerButtons[i].gameObject.GetComponentInChildren<Text>().text = answers[i];
        }

        RegisterButtonClicks();

    }


    public void QuizCleared()
    {
        // Enable enemy AI
        AIDestinationSetter.inCombat = false;
        playerMovement.EnablePlayerMovement();

        Destroy(generatedQuiz);
        Destroy(transform.parent.gameObject);
    }


    public void RegisterButtonClicks()
    {
        Debug.Log("Buttons listening");
        Transform menuCenter = generatedQuiz.transform.Find("QA/Menu Center");
        Transform button1 = menuCenter.transform.Find("Canvas/Answer 1 Button");
        Transform button2 = menuCenter.transform.Find("Canvas/Answer 2 Button");
        Transform button3 = menuCenter.transform.Find("Canvas/Answer 3 Button");

        Button btn1 = button1.gameObject.GetComponent<Button>();
        Button btn2 = button2.gameObject.GetComponent<Button>();
        Button btn3 = button3.gameObject.GetComponent<Button>();

        btn1.onClick.AddListener(() => ButtonClick(btn1));
        btn2.onClick.AddListener(() => ButtonClick(btn2));
        btn3.onClick.AddListener(() => ButtonClick(btn3));
    }

    public void ButtonClick(Button clickedButton)
    {
        Transform menuCenter = generatedQuiz.transform.Find("QA/Menu Center");
        Transform answer1Button = menuCenter.transform.Find("Canvas/Answer 1 Button");
        Transform answer2Button = menuCenter.transform.Find("Canvas/Answer 2 Button");
        Transform answer3Button = menuCenter.transform.Find("Canvas/Answer 3 Button");

        // TODO: change buttons to random, so 1st != correct
        if (clickedButton == answer1Button.GetComponent<Button>())
        {
            Text buttonText = answer1Button.GetComponentInChildren<Text>();
            if (buttonText != null)
            {
                buttonText.color = Color.green; // green prob
            }

            buttonText = answer2Button.GetComponentInChildren<Text>();
            buttonText.color = Color.red;

            buttonText = answer3Button.GetComponentInChildren<Text>();
            buttonText.color = Color.red;
        }
        else
        {   
            // TODO: remove redundancy
            Text buttonText = answer1Button.GetComponentInChildren<Text>();
            buttonText.color = Color.green;
            
            buttonText = answer2Button.GetComponentInChildren<Text>();
            buttonText.color = Color.red;

            buttonText = answer3Button.GetComponentInChildren<Text>();
            buttonText.color = Color.red;
        }

        StartCoroutine(QuizClearedAfterDelay());
    }

    IEnumerator QuizClearedAfterDelay()
    {
        yield return new WaitForSeconds(2f); // Two seconds 
        QuizCleared();
    }

    private void Shuffle<T>(List<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rand.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

}
