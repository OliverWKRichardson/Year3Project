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
    public GameObject scen1success;
    public GameObject scen2success;
    public GameObject scen1fail;
    public GameObject scen2fail;
    public GameObject combatScreen;
    public GameObject scenarioPrefab;
    
    void Start()
    {
        scenario1.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(launchScenarios);
        scenario2.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(launchScenarios);
    }

    public void launchScenarios()
    {
        Instantiate(scenarioPrefab);
        Destroy(gameObject);
    }
}
