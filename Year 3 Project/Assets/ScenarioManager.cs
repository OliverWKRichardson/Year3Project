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
    public GameObject helpbutton;
    public GameObject targetBoss;
    public GameObject finalAnswer;
    public GameObject confirmButton;
    public GameObject questionText;
    public GameObject explainationText;

    // Start is called before the first frame update
    void Start()
    {
        spy.GetComponent<Button>().onClick.AddListener(wrongAnswer);
        virus.GetComponent<Button>().onClick.AddListener(wrongAnswer);
        ransom.GetComponent<Button>().onClick.AddListener(rightAnswer);
        troj.GetComponent<Button>().onClick.AddListener(wrongAnswer);
        helpbutton.GetComponent<Button>().onClick.AddListener(displayHelp);
        finalAnswer.SetActive(false);
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


        Destroy(gameObject, 1);
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
            debuffBoss();
            return;
        }
        showSliderAnswers();
    }
    public void debuffBoss()
    {
        float currentHP = targetBoss.GetComponent<EnemyStats>().getHP();
        currentHP = currentHP * 0.8f;
        targetBoss.GetComponent<EnemyStats>().setHP(currentHP);

        float currentATK = targetBoss.GetComponent<EnemyStats>().getATK();
        currentATK = currentATK * 0.6f;
        targetBoss.GetComponent<EnemyStats>().setATK(currentATK);
    }

    public void displayHelp()
    {
        finalAnswer.SetActive(true);
        confirmButton.GetComponent<Button>().onClick.AddListener(disableHelp);
    }

    public void disableHelp()
    {
        finalAnswer.SetActive(false);
    }
}
