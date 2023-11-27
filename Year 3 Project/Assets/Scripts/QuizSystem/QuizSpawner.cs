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


        string q = questions[rand.Next(questions.Length)];
        question.GetComponent<Text>().text = q.ToString();

        // get corresponding answers
        int index = System.Array.IndexOf(questions, q);
        string[] answers = answersList[index];
        answerText1.GetComponent<Text>().text = answers[0];
        answerText2.GetComponent<Text>().text = answers[1];
        answerText3.GetComponent<Text>().text = answers[2];

        

       
      
    }


    void QuizCleared()
    {
        playerMovement.EnablePlayerMovement();
        Destroy(generatedQuiz);
        Destroy(transform.parent.gameObject);
    }


    // TODO: refactor this out of QuizSpawner
    // TODO: do i need all of newtonsoft?
    void readQuestionsFromJSON()
    {
        // json reader
        string filename = "Questions.json";
        string path = Path.Combine(Application.dataPath, "Scripts", "QuizSystem", filename);


        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            // TODO: change to seperate class for data
          //  var questionsData = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(json);
        }
        else
        {
            Debug.Log("File not found" + path);
        }

    }
    
     // TODO: delete this for JSON instead
    void hardcodeQuestions()
    {
        questions = new string[] {
        "What does 'non-repudiation' mean, in the context of information security?",
        "What does CIA stand for?",
        "What is the best password?",
        "A tech company is trying to secure its sensitive data from unauthorized data. What is an essential measure it should consider to protect its IP?" };

        answersList = new List<string[]>();
        answersList.Add(new string[] { "The ability to prove that a user performed an action", "It refers to the process of concealing the identity of both the sender / recipient of a message", "It means allowing parties to deny sending / receiving a message without consequence" });
        answersList.Add(new string[] { "Confidentiality, Integrity and Availability", "Covert Information Access", "Cybersecurity Infiltration Analysis" });
        answersList.Add(new string[] { "kent.SU2018", "$starwars", "Frank2000", "bij$223jOIUnKhe", "p4$$w0rd"});
        answersList.Add(new string[] { "Encryption", "Copyright", "Open Access", "Passwords"});

    
    }

}
