using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteRandomiser : MonoBehaviour
{
    private int rand;
    public Sprite[] SpriteOptions;
    public GameObject[] GOSpriteOptions;
    private EnemyStats es;
    // Start is called before the first frame update
    void Start()
    {
        es = gameObject.gameObject.GetComponent<EnemyStats>();
        if (es.getBossStatus() == true)
        {
            BossSprites();
        }
        else
        {
            enemySprites();
        }
    }

    void enemySprites()
    {
        es = gameObject.gameObject.GetComponent<EnemyStats>();
        EnemyGenerator.enemyType type = es.getType();
        switch (type)
        {
            case EnemyGenerator.enemyType.malware:
                GetComponent<SpriteRenderer>().sprite = SpriteOptions[3];
                GetComponent<CombatSprite>().sprite = GOSpriteOptions[3];
                break;

            case EnemyGenerator.enemyType.hacker:
                GetComponent<SpriteRenderer>().sprite = SpriteOptions[4];
                GetComponent<CombatSprite>().sprite = GOSpriteOptions[4];
                break;
            case EnemyGenerator.enemyType.scriptkiddie:
                GetComponent<SpriteRenderer>().sprite = SpriteOptions[1];
                GetComponent<CombatSprite>().sprite = GOSpriteOptions[1];
                break;
            case EnemyGenerator.enemyType.socialengineer:
                GetComponent<SpriteRenderer>().sprite = SpriteOptions[2];
                GetComponent<CombatSprite>().sprite = GOSpriteOptions[2];
                break;
            case EnemyGenerator.enemyType.nationstateactor:
                GetComponent<SpriteRenderer>().sprite = SpriteOptions[0];
                GetComponent<CombatSprite>().sprite = GOSpriteOptions[0];
                break;


        }
    }

    void BossSprites()
    {
        GameObject player = GameObject.Find("PlayerCharacter");
        int currentLvl = player.GetComponent<PlayerStats>().GetLevel();
        GetComponent<SpriteRenderer>().sprite = SpriteOptions[currentLvl];
        GetComponent<CombatSprite>().sprite = GOSpriteOptions[currentLvl];
    }
}
