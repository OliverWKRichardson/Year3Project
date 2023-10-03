using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizSpawner : MonoBehaviour
{

    void onCollision(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            spawnQuiz();
        }
    }

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
