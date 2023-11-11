using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrapDoorQuizSpawner : MonoBehaviour
{
    public int sceneIndex;
    private bool quizCleared;

    GameObject quizScreen;
    public GameObject quizScreenPrefab;

    public string quizScreenPrefabPath = "QA"; 

    Vector3 quizScreenPosition = new Vector3(0, 0, 0);

    private PlayerCharacterMovement playerMovement;

    private GameObject generatedQuiz;

    public bool quizTriggered;

    void Start()
    {
       quizCleared = false;
       quizTriggered = false;
    }

    void Update()
    {
        if(quizCleared)
        {
            EndQuiz();
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
            quizScreen = Resources.Load<GameObject>(quizScreenPrefabPath);

            if (!quizTriggered)
            {
                playerMovement = other.GetComponent<PlayerCharacterMovement>();
                playerMovement.DisablePlayerMovement();
               // Instantiate(quizScreenPrefab, quizScreenPosition, Quaternion.identity);
                generatedQuiz = Instantiate(quizScreen, quizScreenPosition, Quaternion.identity);
                quizTriggered = true;
                GetComponent<Collider2D>().enabled = false;
            }
    }

    public void EndQuiz()
    {
        Debug.Log("Door entered, changing map.");
        // Save Player
        GameObject player = GameObject.Find("PlayerCharacter");
        player.GetComponent<PersistAcrossScenes>().SavePlayer();
        // load new scene
        SceneManager.LoadScene(sceneIndex); 
    }
}
