using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class BossBattle : MonoBehaviour
{
    public GameObject BossSpriteSpawn;
    public GameObject MenuCenter;

    public GameObject boss;
    public GameObject player;

    public GameObject scenario1;
    public GameObject scenario2;
    public GameObject combatScreen;
    public GameObject scenario1Prefab;
    public GameObject scenario2Prefab;
    
    void Start()
    {
        scenario1.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(launchScenario1);
        scenario2.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(launchScenario2);
        //BossSpriteSpawn.GetComponent<CombatSprite>().sprite = boss.GetComponent<CombatSprite>().sprite;
    }

    public void launchScenario1()
    {
        scenario1Prefab.GetComponent<ScenarioManager>().targetBoss = boss;
        Instantiate(scenario1Prefab);
        bossEnd();
    }

    public void launchScenario2()
    {
        scenario2Prefab.GetComponent<ScenarioManager>().targetBoss = boss;
        Instantiate(scenario2Prefab);
        bossEnd();
    }
    
    public void bossEnd()
    {
        Destroy(gameObject);
    }
}
