using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizJournal : MonoBehaviour
{
    public GameObject canvas;
    private bool active;

    void Start()
    {
        canvas.SetActive(false);
        active = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.J))
        {
            if(active)
            {
                canvas.SetActive(false);
                active = false;
                Cursor.visible = false;
            }
            else
            {
                canvas.SetActive(true);
                active = true;
                Cursor.visible = true;
            }
        }
    }
}
