using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSONReader : MonoBehaviour
{
    public TextAsset jsonFile; 
    public TextAsset inputFile;
    public Questions questionsInJSON;

    public Questions inputQuestions;

    // Start is called before the first frame update
    void Awake()
    {
        questionsInJSON = JsonUtility.FromJson<Questions>(jsonFile.text);
        inputQuestions = JsonUtility.FromJson<Questions>(inputFile.text);
    }
}
