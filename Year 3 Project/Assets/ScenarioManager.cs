using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScenarioManager : MonoBehaviour
{
    
    public GameObject spy;
    public GameObject virus;
    public GameObject ransom;
    public GameObject troj;
    public GameObject sliderCIA;
    public GameObject confid;
    public GameObject integ;
    public GameObject avail;

    // Start is called before the first frame update
    void Start()
    {
        spy.GetComponent<Button>().onClick.AddListener(wrongAnswer);
        virus.GetComponent<Button>().onClick.AddListener(wrongAnswer);
        ransom.GetComponent<Button>().onClick.AddListener(rightAnswer);
        troj.GetComponent<Button>().onClick.AddListener(wrongAnswer);
    }

    public void wrongAnswer()
    {
        ColorBlock wrongcb = spy.GetComponent<Button>().colors;
        wrongcb.normalColor = Color.red;
        ColorBlock rightcb = ransom.GetComponent<Button>().colors;
        rightcb.normalColor = Color.green;
        spy.GetComponent<Button>().colors = wrongcb;
        virus.GetComponent<Button>().colors = wrongcb;
        troj.GetComponent<Button>().colors = wrongcb;
        ransom.GetComponent<Button>().colors = rightcb;
        showSliderAnswers();
        Destroy(gameObject, 3);
    }
    public void rightAnswer()
    {
        ColorBlock rightcb = ransom.GetComponent<Button>().colors;
        rightcb.pressedColor = Color.green;
        rightcb.highlightedColor = Color.green;
        rightcb.normalColor = Color.green;
        checkSliderAnswers();
        Destroy(gameObject, 3);
    }
    public void showSliderAnswers()
    {
        Text confidText = confid.GetComponent<Text>();
        confidText.color = Color.red;

        Text integText = integ.GetComponent<Text>();
        integText.color = Color.red;

        Text availText = avail.GetComponent<Text>();
        availText.color = Color.green;
    }
    public void checkSliderAnswers()
    {
        if (sliderCIA.GetComponent<Slider>().value == 3)
        {
            return;
        }
        else
        {
            showSliderAnswers();
        }
    }
}
