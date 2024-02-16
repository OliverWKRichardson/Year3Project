using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinScreen : MonoBehaviour
{
    public Text scoreText;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        scoreText.text = "Score: " + player.GetComponent<PersistAcrossScenes>().getScoreString();
        player.gameObject.transform.Find("HUD").gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
