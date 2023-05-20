using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room_Spawner : MonoBehaviour
{

    public int openingDirection;
    private Room_Templates templates;
    private int rand;
    private bool spawned;

    // Start is called before the first frame update
    void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<Room_Templates>();
        Invoke("Spawn", 0.1f);
        Destroy(gameObject, 6f);
    }

    // Update is called once per frame
    void Spawn()
    {
        if(spawned == false)
        {
            if (openingDirection == 1)
            {
                //need to spawn botto ;
                rand = Random.Range(0, templates.bottomRooms.Length);
                spawned = true;
                Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation);
            }

            else if (openingDirection == 2)
            {
                //need to spawn top
                rand = Random.Range(0, templates.topRooms.Length);
                spawned = true;
                Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);
            }

            else if (openingDirection == 3)
            {
                //need to spawn right
                rand = Random.Range(0, templates.rightRooms.Length);
                spawned = true;
                Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation);
            }

            else if (openingDirection == 4)
            {
                //need to spawn left
                rand = Random.Range(0, templates.leftRooms.Length);
                spawned = true;
                Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);
            }
            spawned = true;
        }
        
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("SpawnPoint"))
        {
            if(collision.GetComponent<Room_Spawner>().spawned == false && spawned == false)
            {
                Instantiate(templates.closedRoom, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            spawned = true;

        }
    }
    
}
