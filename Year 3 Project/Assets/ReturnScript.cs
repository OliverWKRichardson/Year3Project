using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReturnMenu()
    {
        Debug.Log("Cliked!");
        Destroy(GameObject.FindWithTag("Player"));
        SceneManager.LoadSceneAsync(0);
    }
}
