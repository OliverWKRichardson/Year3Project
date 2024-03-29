using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    // Start is called before the first frame update
    private int previousval = 0;
    private GameObject moneyval;
    private GameObject moneyanim;
    void Start()
    {
        previousval = GameObject.FindWithTag("Player").GetComponent<PlayerStats>().GetMoney();
        moneyanim = this.transform.Find("animVal").gameObject;
        moneyval = this.transform.Find("moneyValTxt").gameObject;
        UpdateMoney();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateMoney() {
        int val = GameObject.FindWithTag("Player").GetComponent<PlayerStats>().GetMoney();
        moneyval.GetComponent<TextMeshProUGUI>().text = val.ToString();
        int newmoney = val-previousval;
        previousval = val;

        if (newmoney > 0)
        {
            moneyanim.GetComponent<TextMeshProUGUI>().SetText("+" + newmoney);
            StartCoroutine(MoneyNotification());

        }
        else if (newmoney < 0)
        {
            
            moneyanim.GetComponent<TextMeshProUGUI>().SetText(newmoney.ToString());
            StartCoroutine(MoneyNotification());

        }
    }

    IEnumerator MoneyNotification()
    {
        moneyanim.SetActive(true);
        yield return new WaitForSeconds(1.10f);
        moneyanim.SetActive(false);
    }

    
}
