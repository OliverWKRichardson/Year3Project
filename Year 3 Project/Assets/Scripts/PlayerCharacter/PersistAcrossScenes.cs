using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

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
    private static int score;

    public void SavePlayer()
    {
        SPD = GetComponent<PlayerStats>().getSPD();
        HP = GetComponent<PlayerStats>().getHP();
        MaxHP = GetComponent<PlayerStats>().getMaxHP();
        MP = GetComponent<PlayerStats>().getMP();
        MaxMP = GetComponent<PlayerStats>().getMaxMP();
        ATK = GetComponent<PlayerStats>().getATK();
    }

    public void LoadPlayer()
    {
        GetComponent<PlayerStats>().setSPD(SPD);
        GetComponent<PlayerStats>().setHP(HP);
        GetComponent<PlayerStats>().setMaxHP(MaxHP);
        GetComponent<PlayerStats>().setMP(MP);
        GetComponent<PlayerStats>().setMaxMP(MaxMP);
        GetComponent<PlayerStats>().setATK(ATK);
    }

    public void removeCamera()
    {
        Destroy(transform.GetChild(1).gameObject);
    }

    public String getScoreString()
    {
        return score.ToString();
    }

    public void addScore(int amount)
    {
        score = score + amount;
    }
}
