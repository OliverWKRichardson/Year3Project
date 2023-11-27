using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrapDoorQuizSpawner : MonoBehaviour
{
    public int sceneIndex;
    private bool quizCleared;
    public GameObject quizScreenPrefab;

    private PlayerCharacterMovement playerMovement;

    private GameObject generatedQuiz;

    private bool quizTriggered;

    void Start()
    {
       quizCleared = false;
       quizTriggered = false;
    }

    void Update()
    {
        if(quizCleared)
        {
            QuizCleared();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "PlayerCharacter")
        {
            StartQuiz(collision);
        }
    }

    public void setSceneIndex(int index)
    {
        sceneIndex = index;
    }

    public void StartQuiz(Collider2D other)
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

    public void QuizCleared()
    {
        playerMovement.EnablePlayerMovement();
        Debug.Log("Door entered, changing map.");
        // Save Player
        GameObject player = GameObject.Find("PlayerCharacter");
        player.GetComponent<PersistAcrossScenes>().SavePlayer();
        // load new scene
        SceneManager.LoadScene(sceneIndex); 
    }
}
