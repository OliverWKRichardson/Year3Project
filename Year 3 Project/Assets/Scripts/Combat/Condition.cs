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
    private String statAffected;
    private float amount;
}
