using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorScript : MonoBehaviour
{
    public int sceneIndex;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "PlayerCharacter")
        {
            Debug.Log("Door entered, changing map.");
            // Save Player
            GameObject player = GameObject.Find("PlayerCharacter");
            player.GetComponent<PersistAcrossScenes>().SavePlayer();
            // load new scene
            SceneManager.LoadScene(sceneIndex); 
        }
    }

    public void setSceneIndex(int index)
    {
        sceneIndex = index;
    }
}
