

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizSpawner : MonoBehaviour
{
    public bool quizTriggered = false;
    GameObject quizScreen;
    public GameObject quizScreenPrefab;

    public string quizScreenPrefabPath = "QA"; 

    Vector3 quizScreenPosition = new Vector3(0, 0, 0);

    private PlayerCharacterMovement playerMovement;


    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered range");
            quizScreen = Resources.Load<GameObject>(quizScreenPrefabPath);

            if (!quizTriggered)
            {
                playerMovement = other.GetComponent<PlayerCharacterMovement>();
                playerMovement.DisablePlayerMovement();
               // Instantiate(quizScreenPrefab, quizScreenPosition, Quaternion.identity);
                Instantiate(quizScreen, quizScreenPosition, Quaternion.identity);
                quizTriggered = true;
                GetComponent<Collider2D>().enabled = false;
            }
        }
    }



}