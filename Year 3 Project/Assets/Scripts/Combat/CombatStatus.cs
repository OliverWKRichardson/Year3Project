using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class CombatStatus : MonoBehaviour
{
    private bool combat;

    // Start is called before the first frame update
    void Start()
    {
        combat = false;
    }

    public void inCombat() {
        combat = true;
    }
    public void outCombat() {
        combat = false;
    }
    public bool getCombat() {
        return combat;
    }
}
