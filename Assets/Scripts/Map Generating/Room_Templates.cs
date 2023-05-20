using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room_Templates : MonoBehaviour
{

    public GameObject[] bottomRooms;
    public GameObject[] topRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;

    public GameObject closedRoom;
    public List<GameObject> rooms;
    private float waitTime = 4;
    public bool spawnedBoss;
    public GameObject boss;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnBoss());
    }

    // Update is called once per frame
    void Update()
    {
        
        
           
    
    }

    private IEnumerator SpawnBoss()
    {
        yield return new WaitForSeconds(2);
        if (spawnedBoss == false)
        {
            for (int i = 0; i < rooms.Count; i++)
            {
                if (i == rooms.Count - 1)
                {
                    Instantiate(boss, rooms[rooms.Count - 1].transform.position, Quaternion.identity);
                    spawnedBoss = true;
                }
            }
        }
    }
}
