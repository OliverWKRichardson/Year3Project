using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PriceScript : MonoBehaviour
{
    // Start is called before the first frame update
    private int priceVal;
    private GameObject price;
    void Start()
    {
        priceVal = Random.Range(1, 4);
        price = gameObject.transform.Find("pricetext").gameObject;
        price.GetComponent<TextMeshProUGUI>().text = priceVal.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
         
    }
    public int getpriceVal() { return priceVal; }
    
}
