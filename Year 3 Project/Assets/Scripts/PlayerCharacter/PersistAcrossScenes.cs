using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistAcrossScenes : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // load player state
        LoadPlayer();
        // set to start
        transform.position = GameObject.Find("StartPoint").transform.position;
    }

    private static float SPD;
    private static float HP;
    private static float MaxHP;
    private static float MP;
    private static float MaxMP;
    private static float ATK;

    public void SavePlayer()
    {
        SPD = GetComponent<Stats>().getSPD();
        HP = GetComponent<Stats>().getHP();
        MaxHP = GetComponent<Stats>().getMaxHP();
        MP = GetComponent<Stats>().getMP();
        MaxMP = GetComponent<Stats>().getMaxMP();
        ATK = GetComponent<Stats>().getATK();
    }

    public void LoadPlayer()
    {
        GetComponent<Stats>().setSPD(SPD);
        GetComponent<Stats>().setHP(HP);
        GetComponent<Stats>().setMaxHP(MaxHP);
        GetComponent<Stats>().setMP(MP);
        GetComponent<Stats>().setMaxMP(MaxMP);
        GetComponent<Stats>().setATK(ATK);
    }
}
