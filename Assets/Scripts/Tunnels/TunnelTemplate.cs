using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelTemplate : MonoBehaviour
{

    public GameObject[] bottomTunnels;
    public GameObject[] topTunnels;
    public GameObject[] leftTunnels;
    public GameObject[] rightTunnels;

    public GameObject closedTunnel;

    public List<GameObject> Tunnels;

    public float waitTime;
    //private bool spawnedBoss;
    //public GameObject boss;

    void Update()
    {

        if (waitTime <= 0) //&& spawnedBoss == false)
        {
            for (int i = 0; i < Tunnels.Count; i++)
            {
                if (i == Tunnels.Count - 1)
                {
                    //Instantiate(boss, Tunnels[i].transform.position, Quaternion.identity);
                    //spawnedBoss = true;
                }
            }
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }
}