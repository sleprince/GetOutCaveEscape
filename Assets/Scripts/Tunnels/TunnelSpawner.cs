using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TunnelSpawner : MonoBehaviour
{
    public int openingDirection = 1;
    // 1 -> IS T > need bottom door.
    // 2 -> IS B > need top door.
    // 3 -> IS R > need left door.
    // 4 -> IS L > need right door.

   // private RoomTemplates templates;
    private int rand;


    public bool spawned = false;

    public float waitTime = 4f;
    public float expTime;

    public float tunnelNum;

    //public GameObject SPoint;
    private TunnelTemplate templates;
    GameflowManager game;
    //public GameObject templates;

    void Start()
    {
        //transform.position = SPoint.transform.position;



        templates = GameObject.FindGameObjectWithTag("Tunnels").GetComponent<TunnelTemplate>();
        game = GameflowManager.GetInstance();
    }

    void FixedUpdate()
    {
        //StartCoroutine(TimeHater(0.5f)); //seems to be skipped on start.
        expTime = Time.timeSinceLevelLoad;


        //Spawn(openingDirection);

        //spawned = true;

        
        //Destroy(gameObject, waitTime); //supposed to stop the start function happen over and over I think.

        

        Invoke("Spawn", 8.0f);





        //Invoke spawn 2 doors. pass in oD , after 3 minutes, 3 doors after 1.5mins etc.
    }

    void Spawn()
    {
        int oD = openingDirection;

        if (game.tunnelNum + 1 <= game.levelNumTunnels && spawned == false)
        {
            game.tunnelNum++;


            if (oD == 1)
            {

                //GameObject go1 = (GameObject)Resources.Load("Tunnels/CorridorBig");


                //need to spawn a tunnel with a bottom door.
                rand = Random.Range(0, templates.bottomTunnels.Length);
                GameObject go = Instantiate(templates.bottomTunnels[rand], transform.position, templates.bottomTunnels[rand].transform.rotation);
                TunnelManager tunnel1 = go.GetComponent<TunnelManager>();
                tunnel1.tunnelNum = game.tunnelNum;
                //for the original tunnel one that needed rotating.
                //Instantiate(go1, transform.position, Quaternion.Euler(270, 0, 0));


                //Instantiate(go1, transform.position, Quaternion.identity);

                //go1.transform.position = new Vector3(62, 16, 8);

                //StartCoroutine(TimeHater(20.5f));
            }
           else if (openingDirection == 2)
            {
                //GameObject go2 = (GameObject)Resources.Load("Tunnels/TTB");
                //Instantiate(go2, transform.position, Quaternion.Euler(270, 0, 0));

                //StartCoroutine(TimeHater(20.5f));

                //rand will be between 1 and 2 now.
                //need to spawn a tunnel with a top door.
                  rand = Random.Range(0, templates.topTunnels.Length);
                 GameObject go2 = Instantiate(templates.topTunnels[rand], transform.position, templates.topTunnels[rand].transform.rotation);
                 TunnelManager tunnel2 = go2.GetComponent<TunnelManager>();
                 tunnel2.tunnelNum = game.tunnelNum;
            }
            else if (openingDirection == 3)
            {
                //need to spawn a tunnel with a left door.
                rand = Random.Range(0, templates.leftTunnels.Length);
                GameObject go3 = Instantiate(templates.leftTunnels[rand], transform.position, templates.leftTunnels[rand].transform.rotation);
                TunnelManager tunnel3 = go3.GetComponent<TunnelManager>();
                tunnel3.tunnelNum = game.tunnelNum;
            }
            else if (openingDirection == 4)
            {
                //need to spawn a tunnel with a right door.
                rand = Random.Range(0, templates.rightTunnels.Length);
                GameObject go4 = Instantiate(templates.rightTunnels[rand], transform.position, templates.rightTunnels[rand].transform.rotation);
                TunnelManager tunnel4 = go4.GetComponent<TunnelManager>();
                tunnel4.tunnelNum = game.tunnelNum;
            }
            spawned = true;
            
        }
    }


     void OnTriggerEnter(Collider other)
     {
         Debug.Log("Spawn points collided."); //weirdly even though nothing gets shown in log these collisions are still
                                              //happening. Probably because it gets destroyed straight after. Cannot debug.


        if (other.CompareTag("SpawnPoint"))
        {
            Invoke("Destroy", 0.5f);
        }

        //if (other.CompareTag("Tunnels"))
        //{
           // spawned = true;
           // Destroy(transform.parent.gameObject);
       // }

        //if tag of collider is "Tunnel" (middle one) then destroy the tunnel itself instead of the spawn point.

    }

    void Destroy()
    {

            
            //if (other.GetComponent<Tunnelspawner>().spawned == false && spawned == false)
            //{
            // Instantiate(templates.closedRoom, transform.position, Quaternion.identity);

            //Destroy(gameObject);

            spawned = true; //if spawnpoints touching, spawned = true.

        // }
    }



    /* public void OnCollisionEnter(Collision collision)
     {
         Debug.Log("Spawn points collided.");
         //if (other.CompareTag("SpawnPoint")){
                     //if(other.GetComponent<TunnelSpawner>().spawned == false && spawned == false){
                         //Instantiate(templates.closedRoom, transform.position, Quaternion.identity);
             Destroy(gameObject);
         //}
         spawned = true;
                // }
             }
    */

    IEnumerator TimeHater(float timer)
    {
        yield return new WaitForSeconds(timer);
        //spawned = true;
    }

    public static TunnelSpawner instance;
    public static TunnelSpawner GetInstance()
    {
        return instance;
    }

    void Awake()
    {
        instance = this;
        //DontDestroyOnLoad(this.gameObject);
    }

} //class end.