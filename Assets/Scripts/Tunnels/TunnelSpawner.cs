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

    private int rand;
    public bool spawned;
    public bool tunnelAdded;
    public float waitTime = 4f;
    public float expTime;
    public float tunnelNum;
    private TunnelTemplate templates;
    GameflowManager game;

    void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Tunnels").GetComponent<TunnelTemplate>();
        game = GameflowManager.GetInstance();
    }

    void FixedUpdate()
    {
        expTime = Time.timeSinceLevelLoad;
        Invoke("Spawn", 8.0f);
        //Stretch goal, invoke spawn 2 doors. pass in oD , after 3 minutes, 3 doors after 1.5mins etc.
    }

    void Spawn()
    {
        int oD = openingDirection;

        if (game.tunnelNum + 1 <= game.levelNumTunnels + 1 && spawned == false)
        {

            tunnelAdded = false;

            if (oD == 1)
            {

                //need to spawn a tunnel with a bottom door.
                rand = Random.Range(0, templates.bottomTunnels.Length);
                GameObject go = Instantiate(templates.bottomTunnels[rand], transform.position, templates.bottomTunnels[rand].transform.rotation);

                TunnelManager tunnel1 = go.GetComponent<TunnelManager>();
                tunnel1.tunnelNum = game.tunnelNum;

                //spawnSP1S as new array so can do it again further down with different sps.
                TunnelSpawner[] sp1s = new TunnelSpawner[10];

                sp1s = go.GetComponentsInChildren<TunnelSpawner>();


                foreach (TunnelSpawner sp1 in sp1s) //if od = 2 deactivate. this was important so that it didn't keep spawning endless tunnels
                {
                    if (sp1.openingDirection == 2)
                    {

                        sp1.spawned = true;

                    }

                }

                game.tunnelNum++;
                spawned = true;
                game.tunnelAdded = true;
                tunnelAdded = true;
            }
            else if (oD == 2)
            {
                //need to spawn a tunnel with a top door.
                rand = Random.Range(0, templates.topTunnels.Length);
                GameObject go2 = Instantiate(templates.topTunnels[rand], transform.position, templates.topTunnels[rand].transform.rotation);
                TunnelManager tunnel2 = go2.GetComponent<TunnelManager>();
                tunnel2.tunnelNum = game.tunnelNum;

                TunnelSpawner[] sp2s = new TunnelSpawner[10];

                sp2s = go2.GetComponentsInChildren<TunnelSpawner>();


                foreach (TunnelSpawner sp2 in sp2s) //if od = 1 deactivate.
                {
                    if (sp2.openingDirection == 1)
                    {

                        sp2.spawned = true;

                    }

                }

                game.tunnelNum++;
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

                TunnelSpawner[] sp3s = new TunnelSpawner[10];

                sp3s = go3.GetComponentsInChildren<TunnelSpawner>();


                foreach (TunnelSpawner sp3 in sp3s) //if od = 4 deactivate.
                {
                    if (sp3.openingDirection == 4)
                    {

                        sp3.spawned = true;

                    }

                }

                game.tunnelNum++;
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

                TunnelSpawner[] sp4s = new TunnelSpawner[10];

                sp4s = go4.GetComponentsInChildren<TunnelSpawner>();

                foreach (TunnelSpawner sp4 in sp4s) //if od = 3 deactivate.
                {
                    if (sp4.openingDirection == 3)
                    {

                        sp4.spawned = true;

                    }

                }

                game.tunnelNum++;
                game.tunnelAdded = true;
                spawned = true;
                tunnelAdded = true;

            }

        }

    }

} //class end.