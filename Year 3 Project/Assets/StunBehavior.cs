using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class StunBehavior : MonoBehaviour
{   
    
    //After hitting firewall call STUN To briefly halt the Attacker
    public IEnumerator Stun()
    {   
        //Decrease enemy speed to 0 & reset after 4 seconds
        AIPath aiscript = gameObject.GetComponent<AIPath>();
        Sprite sprite = gameObject.GetComponent<Sprite>();
        aiscript.maxSpeed = 0;

        yield return new WaitForSeconds(4);

        aiscript.maxSpeed = 2;

    }
}
