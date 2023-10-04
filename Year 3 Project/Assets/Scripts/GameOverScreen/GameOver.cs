using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text scoreText; 
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("PlayerCharacter");
        scoreText.text = "Score: "+player.GetComponent<PersistAcrossScenes>().getScoreString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
