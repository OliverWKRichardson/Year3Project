using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSONReader : MonoBehaviour
{
    public TextAsset jsonFile;
    public Questions questionsInJSON;

    // Start is called before the first frame update
    void Awake()
    {
        questionsInJSON = JsonUtility.FromJson<Questions>(jsonFile.text);
    }
}
