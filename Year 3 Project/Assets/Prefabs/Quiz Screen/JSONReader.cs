using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSONReader : MonoBehaviour
{
    public TextAsset jsonFile;

    // Start is called before the first frame update
    void Start()
    {
        Questions questionsInJSON = JsonUtility.FromJson<Questions>(jsonFile.text);

        foreach(QuestionData question in questionsInJSON.questions)
        {
            // change to do things with the questions
            Debug.Log(question.question);
            Debug.Log(question.correctAnswer);
            Debug.Log(question.incorrectAnswer1);
            Debug.Log(question.incorrectAnswer2);
            Debug.Log(question.incorrectAnswer3);
        }
    }
}
