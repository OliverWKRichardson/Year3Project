using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialoIconScript : MonoBehaviour
{


    
    // Start is called before the first frame update
    public void setImg(Sprite sprite)
    {
        Image img = gameObject.GetComponent<Image>();
        img.sprite = sprite;
    }
}
