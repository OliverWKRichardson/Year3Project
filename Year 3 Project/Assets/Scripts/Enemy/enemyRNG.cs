using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyRNG : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float chance = Random.Range(0, 3);

        if (chance == 0)
        {
            this.gameObject.SetActive(true);
        }

        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
