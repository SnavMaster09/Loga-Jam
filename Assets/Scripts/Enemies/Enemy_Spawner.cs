using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawner : MonoBehaviour
{

    public GameObject spider;
    public GameObject plant;

    public int maxEnemies;

    // Start is called before the first frame update
    void Start()
    {
        int numEnemies = Random.Range(1, maxEnemies);
        for(int i=1;i<=numEnemies;i++)
        {
            int type = Random.Range(1, 3);
            if(type == 1)
                Instantiate(spider, new Vector3(gameObject.transform.position.x + Random.Range(-4.5f, 4.5f), gameObject.transform.position.y + Random.Range(-1f, 4.5f), 0), transform.rotation);
            else if(type == 2)
                Instantiate(plant, new Vector3(gameObject.transform.position.x + Random.Range(-4.5f, 4.5f), gameObject.transform.position.y + Random.Range(-3f, -1f), 0), transform.rotation);   
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
