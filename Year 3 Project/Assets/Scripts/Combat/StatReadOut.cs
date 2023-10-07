using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatReadOut : MonoBehaviour
{
    public Text playerATK;
    public Text playerSPD;
    public Text enemyATK;
    public Text enemySPD;
    private GameObject player;
    private GameObject enemy;
    public GameObject combatScreen;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("PlayerCharacter");
        playerATK.text = "Attack: " + player.GetComponent<Stats>().getATK();
        playerSPD.text = "Speed: " + player.GetComponent<Stats>().getSPD();
        enemy = combatScreen.GetComponent<CombatScreen>().enemy;
        enemyATK.text = "Attack: " + enemy.GetComponent<Stats>().getATK();
        enemySPD.text = "Speed: " + enemy.GetComponent<Stats>().getSPD();
    }
}
