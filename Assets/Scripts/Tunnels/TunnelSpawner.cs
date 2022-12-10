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


    public bool spawned;
    public bool tunnelAdded;

   // public GameObject[] spawnPs;


    public float waitTime = 4f;
    public float expTime;

    public float tunnelNum;


    //public GameObject SPoint;
    private TunnelTemplate templates;
    //private TunnelSpawner[] spawnPs;

    GameflowManager game;
    //public GameObject templates;

    void Start()
    {
        //transform.position = SPoint.transform.position;



        templates = GameObject.FindGameObjectWithTag("Tunnels").GetComponent<TunnelTemplate>();
        game = GameflowManager.GetInstance();

        //Spawn();
    }

    void FixedUpdate()
    {
        //StartCoroutine(TimeHater(0.5f)); //seems to be skipped on start.
        expTime = Time.timeSinceLevelLoad;


        //Spawn(openingDirection);

        //spawned = true;


        //Destroy(gameObject, waitTime); //supposed to stop the start function happen over and over I think.

        Invoke("Spawn", 8.0f);
        //Invoke("TunnelCheck", 8.2f);


        //Invoke("Spawn", 16.0f);





        //Invoke spawn 2 doors. pass in oD , after 3 minutes, 3 doors after 1.5mins etc.
    }

    void TunnelCheck(Collider other)
    {
        TunnelSpawner TS = other.GetComponent<TunnelSpawner>();

        if (!tunnelAdded)
        {
            //game.tunnelAdded = false;
            //this.noTunnel = true;


               // spawned = false;

        }

        else
        {
            //spawned = true;

        }

    }

        void Spawn()
    {
        int oD = openingDirection;
        //this.tunnelAdded = false;

        if (game.tunnelNum + 1 <= game.levelNumTunnels + 1 && spawned == false)
        {

            tunnelAdded = false;

            if (oD == 1)
            {

                //GameObject go1 = (GameObject)Resources.Load("Tunnels/CorridorBig");


                //need to spawn a tunnel with a bottom door.
                rand = Random.Range(0, templates.bottomTunnels.Length);
                GameObject go = Instantiate(templates.bottomTunnels[rand], transform.position, templates.bottomTunnels[rand].transform.rotation);
                
                TunnelManager tunnel1 = go.GetComponent<TunnelManager>();
                tunnel1.tunnelNum = game.tunnelNum;

                //spawnPS1 as new array so can do it again further down with different sps.
                TunnelSpawner[] sp1s = new TunnelSpawner[10];

                sp1s = go.GetComponentsInChildren<TunnelSpawner>();


                foreach (TunnelSpawner sp1 in sp1s) //if od = 2 deactivate.
                {
                    if (sp1.openingDirection == 2)
                    {

                        sp1.spawned = true;

                    }

                }



                game.tunnelNum++;
                spawned = true;
                //this.tunnelAdded = true;
                game.tunnelAdded = true;
                tunnelAdded = true;


                // 1 -> IS T > need bottom door.
                // 2 -> IS B > need top door.
                // 3 -> IS R > need left door.
                // 4 -> IS L > need right door.

                //for the original tunnel one that needed rotating.
                //Instantiate(go1, transform.position, Quaternion.Euler(270, 0, 0));


                //Instantiate(go1, transform.position, Quaternion.identity);

                //go1.transform.position = new Vector3(62, 16, 8);

                //StartCoroutine(TimeHater(20.5f));
            }
            else if (oD == 2)
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

                //spawnPS1 as new array so can do it again further down with different sps.
                TunnelSpawner[] sp2s = new TunnelSpawner[10];

                sp2s = go2.GetComponentsInChildren<TunnelSpawner>();


                foreach (TunnelSpawner sp2 in sp2s) //if od = 2 deactivate.
                {
                    if (sp2.openingDirection == 1)
                    {

                        sp2.spawned = true;

                    }

                }


                game.tunnelNum++;
                //this.tunnelAdded = true;
                game.tunnelAdded = true;
                spawned = true;
                tunnelAdded = true;

            }
            else if (oD == 3)
            {
                //need to spawn a tunnel with a left door.
                rand = Random.Range(0, templates.leftTunnels.Length);
                GameObject go3 = Instantiate(templates.leftTunnels[rand], transform.position, templates.leftTunnels[rand].transform.rotation);
                TunnelManager tunnel3 = go3.GetComponent<TunnelManager>();
                tunnel3.tunnelNum = game.tunnelNum;

                //spawnPS1 as new array so can do it again further down with different sps.
                TunnelSpawner[] sp3s = new TunnelSpawner[10];

                sp3s = go3.GetComponentsInChildren<TunnelSpawner>();


                foreach (TunnelSpawner sp3 in sp3s) //if od = 2 deactivate.
                {
                    if (sp3.openingDirection == 4)
                    {

                        sp3.spawned = true;

                    }

                }

                game.tunnelNum++;
                // this.tunnelAdded = true;
                game.tunnelAdded = true;
                spawned = true;
                tunnelAdded = true;

            }
            else if (oD == 4)
            {
                //need to spawn a tunnel with a right door.
                rand = Random.Range(0, templates.rightTunnels.Length);
                GameObject go4 = Instantiate(templates.rightTunnels[rand], transform.position, templates.rightTunnels[rand].transform.rotation);
                TunnelManager tunnel4 = go4.GetComponent<TunnelManager>();
                tunnel4.tunnelNum = game.tunnelNum;

                //spawnPS1 as new array so can do it again further down with different sps.
                TunnelSpawner[] sp4s = new TunnelSpawner[10];

                sp4s = go4.GetComponentsInChildren<TunnelSpawner>();


                foreach (TunnelSpawner sp4 in sp4s) //if od = 2 deactivate.
                {
                    if (sp4.openingDirection == 3)
                    {

                        sp4.spawned = true;

                    }

                }

                game.tunnelNum++;
                //this.tunnelAdded = true;
                game.tunnelAdded = true;
                spawned = true;
                tunnelAdded = true;

            }

            //else
            //{
                //game.tunnelAdded = false;
                //spawned = false;

            //}




        }

    }




       /* if (!game.onTop)
        {
            spawned = true;
        }
        else
        {
            Invoke("Spawn", 0.1f);
        }
       */
  


     void OnTriggerEnter(Collider other)
     {



        if (other.CompareTag("SpawnPoint"))
        {
            //TunnelManager TunMan = other.GetComponentInParent<TunnelManager>();
            //if (TunMan.tunnelNum != 0) //allow it to destory the first tunnel.
            //{

            //this.spawned = true;

            //Invoke("Spawned", 7.0f);
            TunnelCheck(other);



            //if (!game.tunnelAdded && !this.tunnelAdSded)

            //else
           // {
                //this.tunnelAdded = false;
                //this.spawned = false;
               // Debug.Log("Spawn points collided but tunnel not spawned.");
                //other.transform.parent.gameObject.SetActive(false);
                //Invoke("Spawn", 8.0f);

           // }

            //}

        }

        //if (other.CompareTag("Tunnels"))
        //{
           // spawned = true;
           // Destroy(transform.parent.gameObject);
       // }

        //if tag of collider is "Tunnel" (middle one) then destroy the tunnel itself instead of the spawn point.

    }

    void Spawned()
    {


        //if (other.GetComponent<Tunnelspawner>().spawned == false && spawned == false)
        //{
        // Instantiate(templates.closedRoom, transform.position, Quaternion.identity);

        //Destroy(gameObject);

        Debug.Log("Spawn points collided."); //weirdly even though nothing gets shown in log these collisions are still
                                             //happening. Probably because it gets destroyed straight after. Cannot debug.

        if (game.tunnelAdded)
        {

            //spawnPs = GameObject.FindGameObjectsWithTag("SpawnPoint");

           // foreach (GameObject spawnP in spawnPs)
            //{
             //   TunnelSpawner spawnManage = GetComponent<TunnelSpawner>();
             //   spawnManage.spawned = true;
           // }

            //spawned = true; //if spawnpoints touching, spawned = true, this makes it not spawn all the tunnels sometimes.
        }


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