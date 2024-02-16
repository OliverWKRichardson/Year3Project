using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
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

        if (player.GetComponent<PlayerStats>().GetLevel() == 2)
        {
            SceneManager.LoadScene(8);

        }
        else
        {
            SceneManager.LoadScene(sceneIndex);
        }
    }
    
}
