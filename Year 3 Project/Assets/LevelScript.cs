using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelScript : MonoBehaviour
{
    public int sceneIndex;
    public GameObject quizScreenPrefab;

    public void setSceneIndex(int index)
    {
        sceneIndex = index;
    }

    public void reloadScene()
    {
        GameObject player = GameObject.Find("PlayerCharacter");
        player.GetComponent<PersistAcrossScenes>().SavePlayer();
        SceneManager.LoadScene(sceneIndex);
    }
    
}
