

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizSpawner : MonoBehaviour
{
    private bool quizTriggered = false;
    public GameObject quizScreenPrefab;

    private PlayerCharacterMovement playerMovement;

    private GameObject generatedQuiz;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered range");

            if (!quizTriggered)
            {
                playerMovement = other.GetComponent<PlayerCharacterMovement>();
                playerMovement.DisablePlayerMovement();
               // Instantiate(quizScreenPrefab, quizScreenPosition, Quaternion.identity);
                generatedQuiz = Instantiate(quizScreenPrefab, other.transform.position, Quaternion.identity);
                quizTriggered = true;
                GetComponent<Collider2D>().enabled = false;
            }
        }
    }

    void QuizCleared()
    {
        playerMovement.EnablePlayerMovement();
        Destroy(generatedQuiz);
        Destroy(transform.parent.gameObject);
    }

}