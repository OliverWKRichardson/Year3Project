using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using Pathfinding;
// using Newtonsoft.Json;



public class QuizSpawner : MonoBehaviour
{

    private bool answerSelected = false;

    private bool quizTriggered = false;

    public GameObject quizScreenPrefab;

    public GameObject inputPrefab;

    private bool prefabPicked;

    public string[] questions;

    public List<string[]> answersList;

    private QuizManager quizManager;

    private PlayerCharacterMovement playerMovement;

    private GameObject generatedQuiz;

    private System.Random rand = new System.Random();

    private QuestionData questionData;

    private void Start()
    {
        quizManager = this.GetComponent<QuizManager>();
        prefabPicked = true;
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

                if (rand.Next(2) == 0)
                {
                    quizScreenPrefab = quizScreenPrefab;
                    prefabPicked = true;
                }
                else
                {
                    quizScreenPrefab = inputPrefab;
                    prefabPicked = false;
                }

                generatedQuiz = Instantiate(quizScreenPrefab, other.transform.position, Quaternion.identity);
                //   Debug.Log(!generatedQuiz);
                quizTriggered = true;
                GetComponent<Collider2D>().enabled = false;

                quizManager = QuizManager.Instance;
                //  Debug.Log(quizManager);


                Debug.Log("prefab is + " + prefabPicked);
                setQuestions(prefabPicked);

            }
        }
    }

    private void Update()
    {

        if (quizTriggered && answerSelected && Input.GetMouseButtonDown(0)) // Check if answer is selected and the mouse is clicked
        {
            QuizCleared();
        }
    }

    public void setQuestions(bool whichPrefabPicked)
    {

        if (whichPrefabPicked == true)
        {
            Transform menuCenter = generatedQuiz.transform.Find("QA/Menu Center");
            Transform question = menuCenter.transform.Find("Canvas/QuestionText");

            Transform button1 = menuCenter.transform.Find("Canvas/Answer 1 Button");
            Transform button2 = menuCenter.transform.Find("Canvas/Answer 2 Button");
            Transform button3 = menuCenter.transform.Find("Canvas/Answer 3 Button");
            Transform answerText1 = button1.transform.Find("AnswerText1");
            Transform answerText2 = button2.transform.Find("AnswerText2");
            Transform answerText3 = button3.transform.Find("AnswerText3");

            questionData = quizManager.GetRandomQuestion();
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

        else
        {
            Transform menuCenter = generatedQuiz.transform.Find("QA/Menu Center");
            Transform question = menuCenter.transform.Find("Canvas/QuestionText");

            Transform button1 = menuCenter.transform.Find("Canvas/Answer 1 Button");
            // Transform btn1 = button1.transform.Find("Button");
            Transform inputField = button1.transform.Find("InputField");

            questionData = quizManager.getRandomInputQuestion();

            Debug.Log(questionData.question);
            Debug.Log(questionData.correctAnswer);

            question.gameObject.GetComponent<Text>().text = questionData.question;

            InputField submission = inputField.GetComponent<InputField>();

            submission.onEndEdit.AddListener(submissionInput);

        }

    }


    public void QuizCleared()
    {
        // Enable enemy AI
        AIDestinationSetter.inCombat = false;
        playerMovement.EnablePlayerMovement();


        Destroy(generatedQuiz);
        if (!transform.parent.gameObject.CompareTag("Router"))
        {
            Destroy(transform.parent.gameObject);

        }
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
        if (quizTriggered && !answerSelected)
        {
            Transform menuCenter = generatedQuiz.transform.Find("QA/Menu Center");
            Transform[] answerButtons = new Transform[3];

            for (int i = 0; i < 3; i++)
            {
                answerButtons[i] = menuCenter.transform.Find($"Canvas/Answer {i + 1} Button");
            }

            string correctAnswer = questionData.correctAnswer;
            //  Debug.Log(correctAnswer);

            foreach (Transform button in answerButtons)
            {
                Text buttonText = button.GetComponentInChildren<Text>();

                if (button.GetComponent<Button>() == clickedButton)
                {
                    //  Debug.Log($"Clicked Button Text: {buttonText.text} | Correct Answer: {correctAnswer}");

                    if (buttonText.text == correctAnswer)
                    {
                        buttonText.color = Color.green; // Correct answer picked
                        foreach (Transform answerButton in answerButtons)
                        {
                            if (answerButton.GetComponentInChildren<Text>().text != correctAnswer)
                            {
                                answerButton.GetComponentInChildren<Text>().color = Color.red; // Highlight correct answer in green
                            }

                        }
                    }
                    else
                    {
                        buttonText.color = Color.red; // Incorrect answer picked
                        foreach (Transform answerButton in answerButtons)
                        {
                            if (answerButton.GetComponentInChildren<Text>().text == correctAnswer)
                            {
                                answerButton.GetComponentInChildren<Text>().color = Color.green; // Highlight correct answer in green
                                                                                                 // break;
                            }
                            else { answerButton.GetComponentInChildren<Text>().color = Color.red; }
                        }
                    }
                }
            }
        }
        answerSelected = true;
        // StartCoroutine(QuizClearedAfterDelay());
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

    // rename + do whitespace

    private void submissionInput(string arg0)
    {

        //questionData = quizManager.getRandomInputQuestion();
        string correctAnswer = questionData.correctAnswer;
        Debug.Log("Correct answer is" + correctAnswer);

        string userInput = arg0.Trim().ToLower();

        if (keywordSearch(userInput))
        {
            Debug.Log("Correct!");
        }
        else
        {
            Debug.Log("Incorrect!");
        }

        

        answerSelected = true;
        Debug.Log(arg0);

    }

    public bool keywordSearch(string userInput)
    {
       
        string correctAnswer = questionData.correctAnswer;
        userInput = userInput.ToLower();
        correctAnswer = correctAnswer.ToLower();
        string[] keywords = correctAnswer.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

        List<string> foundKeywords = new List<string>();

        foreach (string keyword in keywords)
        {
            if (!userInput.Contains(keyword))
            {
                return false;
            }
        }
        return true;

    }


}