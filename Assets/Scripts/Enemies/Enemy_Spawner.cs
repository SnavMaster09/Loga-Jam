using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawner : MonoBehaviour
{

    public GameObject spider;

    public int maxEnemies;

    // Start is called before the first frame update
    void Start()
    {
        int numEnemies = Random.Range(1, maxEnemies);
        for(int i=1;i<=numEnemies;i++)
        {
            Instantiate(spider, new Vector3(gameObject.transform.position.x + Random.Range(-4.5f, 4.5f), gameObject.transform.position.y + Random.Range(-1f, 4.5f), 0), transform.rotation);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
