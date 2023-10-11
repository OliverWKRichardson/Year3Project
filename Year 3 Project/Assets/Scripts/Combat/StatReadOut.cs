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
        playerATK.text = "Attack: " + player.GetComponent<PlayerStats>().getATK();
        playerSPD.text = "Speed: " + player.GetComponent<PlayerStats>().getSPD();
        enemy = combatScreen.GetComponent<CombatScreen>().enemy;
        enemyATK.text = "Attack: " + enemy.GetComponent<EnemyStats>().getATK();
        enemySPD.text = "Speed: " + enemy.GetComponent<EnemyStats>().getSPD();
    }
}
