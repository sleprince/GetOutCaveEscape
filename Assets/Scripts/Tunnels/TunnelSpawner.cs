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
    public bool spawned;

    public float waitTime = 4f;
    public float expTime;

    public GameObject SPoint;

    void Start()
    {
        transform.position = SPoint.transform.position;
    }

    void FixedUpdate()
    {
        //StartCoroutine(TimeHater(0.5f)); //seems to be skipped on start.
        expTime = Time.fixedTime;


        Spawn(openingDirection);

        //spawned = true;

        //Destroy(gameObject, waitTime); //supposed to stop the start function happen over and over I think.
        //templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();

        //Invoke("Spawn", 0.1f);





        //Invoke spawn 2 doors. pass in oD , after 3 minutes, 3 doors after 1.5mins etc.
    }

    void Spawn(int oD)
    {
        if (spawned == false)
        {
            if ((oD == 1) && (expTime <= 2.00f))
            {

                GameObject go1 = (GameObject)Resources.Load("Tunnels/CorridorBig");


                //need to spawn a tunnel with a bottom door.
                //rand = Random.Range(0, templates.bottomRooms.Length);

                //for the original tunnel one that needed rotating.
                //Instantiate(go1, transform.position, Quaternion.Euler(270, 0, 0));
                Instantiate(go1, transform.position, Quaternion.identity);

                //go1.transform.position = new Vector3(62, 16, 8);

                //StartCoroutine(TimeHater(20.5f));
            }
           /* else if (expTime >= 0.01f)
            {
                GameObject go2 = (GameObject)Resources.Load("Tunnels/TTB");
                Instantiate(go2, transform.position, Quaternion.Euler(270, 0, 0));

                StartCoroutine(TimeHater(20.5f));

                //rand will be between 1 and 2 now.
                //need to spawn a tunnel with a top door.
                //  rand = Random.Range(0, templates.topRooms.Length);
                // Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);
            } */
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

    IEnumerator TimeHater(float timer)
    {
        yield return new WaitForSeconds(timer);
        //spawned = true;
    }

} //class end.