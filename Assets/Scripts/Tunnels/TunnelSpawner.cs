using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TunnelSpawner : MonoBehaviour
{
    public int openingDirection = 1;
    // 1 -> need bottom door.
    // 2 -> need top door.
    // 3 -> need left door.
    // 4 -> need right door.

   // private RoomTemplates templates;
    private int rand;
    public bool spawned = false;

    public float waitTime = 4f;
    public float expTime;

    void Start()
    {
        expTime = Time.fixedTime;

        //Destroy(gameObject, waitTime); //supposed to stop the start function happen over and over I think.
        //templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();

        //Invoke("Spawn", 0.1f);

        Spawn(openingDirection);

        //Invoke spawn 2 doors. pass in oD , after 3 minutes, 3 doors after 1.5mins etc.
    }


    void Spawn(int oD)
    {
        if (spawned == false)
        {
            if ((oD == 1) && (expTime <= 0.01f))
            {

                GameObject go1 = (GameObject)Resources.Load("Tunnels/Tunnel_Prefab");


                //need to spawn a tunnel with a bottom door.
                //rand = Random.Range(0, templates.bottomRooms.Length);
                Instantiate(go1, transform.position, Quaternion.Euler(270, 0, 0));
            }
            else if (expTime >= 0.01f)
            {
                GameObject go2 = (GameObject)Resources.Load("Tunnels/TTB");
                Instantiate(go2, transform.position, Quaternion.Euler(270, 0, 0));

                //rand will be between 1 and 2 now.
                //need to spawn a tunnel with a top door.
                //  rand = Random.Range(0, templates.topRooms.Length);
                // Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);
            }
            else if (openingDirection == 3)
            {
                //need to spawn a tunnel with a left door.
               // rand = Random.Range(0, templates.leftRooms.Length);
              //  Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);
            }
            else if (openingDirection == 4)
            {
                //need to spawn a tunnel with a right door.
               // rand = Random.Range(0, templates.rightRooms.Length);
                //Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation);
            }
            //spawned = true;
        }
    }

    void OnTriggerEnter3D(Collider other)
    {
        if (other.CompareTag("SpawnPoint"))
        {
            //if (other.GetComponent<RoomSpawner>().spawned == false && spawned == false)
            //{
               // Instantiate(templates.closedRoom, transform.position, Quaternion.identity);
                Destroy(gameObject);
           // }
            spawned = true;
        }
    }
} //class end.