using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelScript : MonoBehaviour
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
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "PlayerCharacter")
        {
            GameObject player = GameObject.Find("PlayerCharacter");
            player.GetComponent<PersistAcrossScenes>().SavePlayer();
            SceneManager.LoadScene(sceneIndex);
        }
    }

    public void setSceneIndex(int index)
    {
        sceneIndex = index;
    }

    public void IncrementScene()
    {
        sceneIndex++;
    }

    
}
