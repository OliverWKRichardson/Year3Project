using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CombatScreen.TurnType;
using System;

public class EnemyGenerator : MonoBehaviour
{
    // Enemy Type
    public enum enemyType{none,malware, hacker, socialengineer, scriptkiddie, nationstateactor}
    private int enemyTypeCount = Enum.GetNames(typeof(enemyType)).Length;
    // Enemy class
    public GameObject enemy;

    //enemy
    GameObject hostile;

    // force type of enemy spawned
    public enemyType forcetype;

    // Start is called before the first frame update
    void Start()
    {
        createEnemy();
    }

    void createEnemy()
    {
        Transform pos = gameObject.transform;
        hostile = Instantiate(enemy);
        hostile.transform.position = pos.position;// Add Vector2(x, y) for the position of the newly generated enemy

        hostile.GetComponent<EnemyStats>().setNormal();

        enemyType enemyType = (enemyType)UnityEngine.Random.Range(1, enemyTypeCount); // no need to subtract 1 from upper bound as the none type does this for us
        if(forcetype != enemyType.none)
        {
            enemyType = forcetype;
        }

        switch(enemyType) // every enemy needs a 0 cost skill for when they run out of mana
        {
            /**case enemyType.light:
                hostile.GetComponent<EnemyStats>().setType(enemyType.light);
                hostile.GetComponent<EnemyStats>().setSPD(UnityEngine.Random.Range(5, 11));
                hostile.GetComponent<EnemyStats>().setMaxHP(UnityEngine.Random.Range(400, 600));
                hostile.GetComponent<EnemyStats>().setHP(hostile.GetComponent<EnemyStats>().getMaxHP());
                hostile.GetComponent<EnemyStats>().setMaxMP(UnityEngine.Random.Range(100, 150));
                hostile.GetComponent<EnemyStats>().setMP(hostile.GetComponent<EnemyStats>().getMaxMP());
                hostile.GetComponent<EnemyStats>().setATK(UnityEngine.Random.Range(50, 100));
                hostile.GetComponent<EnemySkills>().SetSkills("Light Attack", LightAttack, LightAttackCost,"DDoS" , DoTA, DoTACost,"DDoS" , DoTA, DoTACost);
                break;
            case enemyType.heavy:
                hostile.GetComponent<EnemyStats>().setType(enemyType.heavy);
                hostile.GetComponent<EnemyStats>().setSPD(UnityEngine.Random.Range(1, 5));
                hostile.GetComponent<EnemyStats>().setMaxHP(UnityEngine.Random.Range(750, 1000));
                hostile.GetComponent<EnemyStats>().setHP(hostile.GetComponent<EnemyStats>().getMaxHP());
                hostile.GetComponent<EnemyStats>().setMaxMP(UnityEngine.Random.Range(100, 150));
                hostile.GetComponent<EnemyStats>().setMP(hostile.GetComponent<EnemyStats>().getMaxMP());
                hostile.GetComponent<EnemyStats>().setATK(UnityEngine.Random.Range(80, 180));
                hostile.GetComponent<EnemySkills>().SetSkills("Light Attack", LightAttack, LightAttackCost,"Heavy Attack" , HeavyAttack, HeavyAttackCost,"Heavy Attack" , HeavyAttack, HeavyAttackCost);
                break;**/
            case enemyType.malware:
                hostile.GetComponent<EnemyStats>().setType(enemyType.malware);
                hostile.GetComponent<EnemyStats>().setSPD(UnityEngine.Random.Range(3, 7));
                hostile.GetComponent<EnemyStats>().setMaxHP(UnityEngine.Random.Range(350, 550));
                hostile.GetComponent<EnemyStats>().setHP(hostile.GetComponent<EnemyStats>().getMaxHP());
                hostile.GetComponent<EnemyStats>().setMaxMP(UnityEngine.Random.Range(100, 150));
                hostile.GetComponent<EnemyStats>().setMP(hostile.GetComponent<EnemyStats>().getMaxMP());
                hostile.GetComponent<EnemyStats>().setATK(UnityEngine.Random.Range(80, 130));
                hostile.GetComponent<EnemySkills>().SetSkills("Ransomware", RansomwareAttack, RansomwareCost, "Virus", VirusAttack,VirusCost, "Spyware", SpywareAttack,VirusCost );
                break;
            case enemyType.hacker:
                hostile.GetComponent<EnemyStats>().setType(enemyType.hacker);
                hostile.GetComponent<EnemyStats>().setSPD(UnityEngine.Random.Range(5, 10));
                hostile.GetComponent<EnemyStats>().setMaxHP(UnityEngine.Random.Range(500, 600));
                hostile.GetComponent<EnemyStats>().setHP(hostile.GetComponent<EnemyStats>().getMaxHP());
                hostile.GetComponent<EnemyStats>().setMaxMP(UnityEngine.Random.Range(100, 150));
                hostile.GetComponent<EnemyStats>().setMP(hostile.GetComponent<EnemyStats>().getMaxMP());
                hostile.GetComponent<EnemyStats>().setATK(UnityEngine.Random.Range(80, 130));
                hostile.GetComponent<EnemySkills>().SetSkills("Botnet Attack", BotnetAttack,BotnetCost, "Phishing Attack", PhishingAttack,LightAttackCost, "Dictionary Password Attack", DictionaryPasswordAttack, HeavyAttackCost);
                break;

            case enemyType.socialengineer:
                hostile.GetComponent<EnemyStats>().setType(enemyType.socialengineer);
                hostile.GetComponent<EnemyStats>().setSPD(UnityEngine.Random.Range(5, 11));
                hostile.GetComponent<EnemyStats>().setMaxHP(UnityEngine.Random.Range(500, 600));
                hostile.GetComponent<EnemyStats>().setHP(hostile.GetComponent<EnemyStats>().getMaxHP());
                hostile.GetComponent<EnemyStats>().setMaxMP(UnityEngine.Random.Range(100, 150));
                hostile.GetComponent<EnemyStats>().setMP(hostile.GetComponent<EnemyStats>().getMaxMP());
                hostile.GetComponent<EnemyStats>().setATK(UnityEngine.Random.Range(80, 130));
                hostile.GetComponent<EnemySkills>().SetSkills("Phishing Attack", PhishingAttack, LightAttackCost, "Spear Phishing", SpearPhishingAttack, BotnetCost, "Smishing", PhishingAttack, LightAttackCost);
                break;

            case enemyType.scriptkiddie:
                hostile.GetComponent<EnemyStats>().setType(enemyType.scriptkiddie);
                hostile.GetComponent<EnemyStats>().setSPD(UnityEngine.Random.Range(3, 7));
                hostile.GetComponent<EnemyStats>().setMaxHP(UnityEngine.Random.Range(350, 500));
                hostile.GetComponent<EnemyStats>().setHP(hostile.GetComponent<EnemyStats>().getMaxHP());
                hostile.GetComponent<EnemyStats>().setMaxMP(UnityEngine.Random.Range(100, 150));
                hostile.GetComponent<EnemyStats>().setMP(hostile.GetComponent<EnemyStats>().getMaxMP());
                hostile.GetComponent<EnemyStats>().setATK(UnityEngine.Random.Range(80, 130));
                hostile.GetComponent<EnemySkills>().SetSkills("DOS Attack", DoSAttack, VirusCost, "SQL Injection", SQLInjectionAttack, RansomwareCost, "Trojan", TrojanAttack, VirusCost);
                break;

                //Edit this later to give nation state actor its own moves
            case enemyType.nationstateactor:
                hostile.GetComponent<EnemyStats>().setType(enemyType.nationstateactor);
                hostile.GetComponent<EnemyStats>().setSPD(UnityEngine.Random.Range(5, 10));
                hostile.GetComponent<EnemyStats>().setMaxHP(UnityEngine.Random.Range(500, 600));
                hostile.GetComponent<EnemyStats>().setHP(hostile.GetComponent<EnemyStats>().getMaxHP());
                hostile.GetComponent<EnemyStats>().setMaxMP(UnityEngine.Random.Range(100, 150));
                hostile.GetComponent<EnemyStats>().setMP(hostile.GetComponent<EnemyStats>().getMaxMP());
                hostile.GetComponent<EnemyStats>().setATK(UnityEngine.Random.Range(80, 130));
                hostile.GetComponent<EnemySkills>().SetSkills("Botnet Attack", BotnetAttack, BotnetCost, "Phishing Attack", PhishingAttack, LightAttackCost, "Dictionary Password Attack", DictionaryPasswordAttack, HeavyAttackCost);
                break;




        }

    }

    private int LightAttackCost = 0;
    private int BotnetCost = 70;
    private int RansomwareCost = 50;
    private int VirusCost = 25;

    // Template Skills
    public void DoTA(GameObject target)
    {
        Debug.Log("Enemy Used DoTA Attack On "+ target.name);
        Condition DDoS = new Condition("DoTA", 5, CombatScreen.TurnType.playerTurn, 10.0f);
        target.GetComponent<PlayerStats>().AddCondition(DDoS);
        hostile.GetComponent<EnemyStats>().spendMP(50);
    }
    private int DoTACost = 50;
    public void DoTI(GameObject target)
    {
        Debug.Log("Enemy Used DoTI Attack On "+ target.name);
        Condition FileDeletionWorm = new Condition("DoTI", 5, CombatScreen.TurnType.playerTurn, 10.0f);
        target.GetComponent<PlayerStats>().AddCondition(FileDeletionWorm);
        hostile.GetComponent<EnemyStats>().spendMP(50);
    }
    private int DoTICost = 50;
    public void DoTC(GameObject target)
    {
        Debug.Log("Enemy Used DoTA Attack On "+ target.name);
        Condition DownloadingPersonalData = new Condition("DoTC", 5, CombatScreen.TurnType.playerTurn, 10.0f);
        target.GetComponent<PlayerStats>().AddCondition(DownloadingPersonalData);
        hostile.GetComponent<EnemyStats>().spendMP(50);
    }
    private int DoTCCost = 50;

    public void DoSAttack(GameObject target)
    {
        Debug.Log("Enemy Used DoTA Attack On " + target.name);
        Condition DoS = new Condition("DoTA", 2, CombatScreen.TurnType.playerTurn, 50.0f);
        target.GetComponent<PlayerStats>().AddCondition(DoS);
        hostile.GetComponent<EnemyStats>().spendMP(50);
    }
    public void BotnetAttack(GameObject target)
    {
        Debug.Log("Enemy Used DoTA Attack On " + target.name);
        Condition DDoS = new Condition("DoTA", 5, CombatScreen.TurnType.playerTurn, 75.0f);
        target.GetComponent<PlayerStats>().AddCondition(DDoS);
        hostile.GetComponent<EnemyStats>().spendMP(80);
    }

    public void SpearPhishingAttack(GameObject target)
    {

        Debug.Log("Enemy Used Spear Phishing Attack On " + target.name);
        hostile.GetComponent<EnemyStats>().spendMP(100);
        float amount = hostile.GetComponent<EnemyStats>().getATK();
        float MULT = 1.3f;
        target.GetComponent<PlayerStats>().DamageC(amount * MULT);
    }
    public void HeavyAttack(GameObject target)
    {
        Debug.Log("Enemy Used Heavy Attack On "+ target.name);
        hostile.GetComponent<EnemyStats>().spendMP(100);
        float amount = hostile.GetComponent<EnemyStats>().getATK();
        float MULT = 2;
        target.GetComponent<PlayerStats>().DamageC(amount*MULT);
        target.GetComponent<PlayerStats>().DamageI(amount*MULT);
        target.GetComponent<PlayerStats>().DamageA(amount*MULT);
    }
    private int HeavyAttackCost = 100;
    public void LightAttack(GameObject target)
    {
        Debug.Log("Enemy Used Light Attack On "+ target.name);
        float amount = hostile.GetComponent<EnemyStats>().getATK();
        target.GetComponent<PlayerStats>().DamageC(amount);
        target.GetComponent<PlayerStats>().DamageI(amount);
        target.GetComponent<PlayerStats>().DamageA(amount);
    }

    public void RansomwareAttack(GameObject target)
    {
        Debug.Log("Enemy used Ransomware Attack On" + target.name);
        float amount = hostile.GetComponent<EnemyStats>().getATK();
        float amult = 1.2f;
        float imult = 0.5f;
        target.GetComponent<PlayerStats>().DamageI(imult* amount);
        target.GetComponent<PlayerStats>().DamageA(amult*amount);
    }
    
    public void VirusAttack(GameObject target)
    {
        Debug.Log("Enemy used Virus Attack On" + target.name);
        float amount = hostile.GetComponent<EnemyStats>().getATK();
        float imult = 1.2f;
        target.GetComponent<PlayerStats>().DamageI(imult * amount);
        

    }

    public void DictionaryPasswordAttack(GameObject target)
    {
        Debug.Log("Enemy used Dictionary Attack On" + target.name);
        float amount = hostile.GetComponent<EnemyStats>().getATK();
        float imult = 1.3f;
        target.GetComponent<PlayerStats>().DamageC(imult * amount);
    }

    public void SpywareAttack(GameObject target)
    {
        Debug.Log("Enemy used Spyware Attack On" + target.name);
        float amount = hostile.GetComponent<EnemyStats>().getATK();
        float cmult = 1.2f;
        target.GetComponent<PlayerStats>().DamageC(cmult * amount);
    }

    public void PhishingAttack(GameObject target)
    {
        Debug.Log("Enemy used Phishing Attack On" + target.name);
        float amount = hostile.GetComponent<EnemyStats>().getATK();
        float cmult = 1.1f;
        target.GetComponent<PlayerStats>().DamageC(cmult * amount);
    }

    public void SQLInjectionAttack(GameObject target)
    {
        Debug.Log("Enemy used SQL Injection Attack On" + target.name);
        float amount = hostile.GetComponent<EnemyStats>().getATK();
        float imult = 1.3f;
        target.GetComponent<PlayerStats>().DamageI(imult * amount);

    }

    public void TrojanAttack(GameObject target)
    {
        Debug.Log("Enemy used Trojan Attack On" + target.name);
        float amount = hostile.GetComponent<EnemyStats>().getATK();
        float imult = 1.2f;
        float cmult = 0.8f;

        target.GetComponent<PlayerStats>().DamageI(imult * amount);
        target.GetComponent<PlayerStats>().DamageC(cmult * amount);
    }
    
}

