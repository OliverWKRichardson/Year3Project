using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static CombatScreen.TurnType;

public class TurnIndicator : MonoBehaviour
{
    public Text turnIndicator;
    public CombatScreen.TurnType currentTurnDisplayed;
    public GameObject combatScreen;

    // Start is called before the first frame update
    void Start()
    {
        currentTurnDisplayed = combatScreen.GetComponent<CombatScreen>().getTurn();
        if(currentTurnDisplayed == CombatScreen.TurnType.START)
        {
            turnIndicator.text = "Start";
        }
        else if(currentTurnDisplayed == CombatScreen.TurnType.playerTurn)
        {
            turnIndicator.text = "Player";
        }
        else if(currentTurnDisplayed == CombatScreen.TurnType.enemyTurn)
        {
            turnIndicator.text = "Enemy";
        }
        else if(currentTurnDisplayed == CombatScreen.TurnType.END)
        {
            turnIndicator.text = "End";
        }
    }

    // Update is called once per frame
    void Update()
    {
        // if displayed turn if not the current turn
        if(currentTurnDisplayed != combatScreen.GetComponent<CombatScreen>().getTurn())
        {
            // Update displayed turn
            currentTurnDisplayed = combatScreen.GetComponent<CombatScreen>().getTurn();
            if(currentTurnDisplayed == CombatScreen.TurnType.START)
            {
                turnIndicator.text = "Start";
            }
            else if(currentTurnDisplayed == CombatScreen.TurnType.playerTurn)
            {
                turnIndicator.text = "Player";
            }
            else if(currentTurnDisplayed == CombatScreen.TurnType.enemyTurn)
            {
                turnIndicator.text = "Enemy";
            }
            else if(currentTurnDisplayed == CombatScreen.TurnType.END)
            {
                turnIndicator.text = "End";
            }
        }
    }
}
