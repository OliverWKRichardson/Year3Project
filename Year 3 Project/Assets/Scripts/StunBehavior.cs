using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class StunBehavior : MonoBehaviour
{

    //After hitting firewall call STUN To briefly halt the Attacker

    private void Awake()
    {
        
    }
    private bool stunned = false;
    public IEnumerator Stun()
    {
        stunned = true;
        //Decrease enemy speed to 0 & reset after 4 seconds
        AIPath aiscript = gameObject.GetComponent<AIPath>();
        Sprite sprite = gameObject.GetComponent<Sprite>();
        aiscript.maxSpeed = 0;
        GameObject cs = gameObject.transform.Find("Combat Starter").gameObject;
        cs.SetActive(false);
        yield return new WaitForSeconds(4);
        cs.SetActive(true);
        aiscript.maxSpeed = 2;
        stunned = false;

    }


}
