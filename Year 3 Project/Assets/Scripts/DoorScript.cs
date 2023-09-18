using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public SceneManager Scenemanager;
    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("Door entered, changing map.");
            //Based on what kind of door we are using we can tell which room to change to. 4 Doors, North East South West on each map.
            //North door sents to North of current room for example.


        }
    }
}
