using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CombatScreen.TurnType;

public class Condition
{
    private String name;
    private int turnsRemaining;
    private CombatScreen.TurnType turnTypeToReduceOn;
    private float amount;

    public Condition(String setName, int turns, CombatScreen.TurnType turnType, float setAmount)
    {
        name = setName;
        turnsRemaining = turns;
        turnTypeToReduceOn = turnType;
        amount = setAmount;
    }

    public CombatScreen.TurnType GetTurnTypeToReduceOn()
    {
        return turnTypeToReduceOn;
    }

    public void ReduceTurnsLeft()
    {
        turnsRemaining -= 1;
    }

    public String GetName()
    {
        return name;
    }

    public float GetAmount()
    {
        return amount;
    }

    public int GetTurnsLeft()
    {
        return turnsRemaining;
    }
}
