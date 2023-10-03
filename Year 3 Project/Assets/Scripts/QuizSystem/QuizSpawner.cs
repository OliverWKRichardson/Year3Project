    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizSpawner : MonoBehaviour
{
    void spawnQuiz()
    {
        // spawn quiz
        GameObject quiz = Instantiate(Resources.Load("Prefabs/UI/QuizSystem/QuizSpawner")) as GameObject;
        // set quiz position
        quiz.transform.position = new Vector3(0, 0, 0);
        // set quiz parent
        quiz.transform.parent = GameObject.Find("Canvas").transform;
        // set quiz name
        quiz.name = "Quiz";
    }
}
