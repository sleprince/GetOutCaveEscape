using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleStopper : MonoBehaviour
{

    TunnelManager tunnelManager;
    GameflowManager game;
    public GameObject[] spawnPs;
    public bool noTunnel = false;

    void Start()
    {

        tunnelManager = this.GetComponentInParent<TunnelManager>();
        game = GameflowManager.GetInstance();

        if (tunnelManager.tunnelNum == game.levelNumTunnels)
            {
                Invoke("Destroy", 5.0f);      
            }

    }

    void Destroy()
    {
        this.transform.parent.gameObject.SetActive(false);

    }
    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Top"))
        {
            Debug.Log("Top points collided."); 
            StartCoroutine(TimeHater(0.1f, other));

        }

    }

    IEnumerator TimeHater(float timer, Collider other)
     {
          yield return new WaitForSeconds(timer);
          transform.parent.gameObject.SetActive(false); //if tunnels end up spawn on top of each other still, decativate the old one,
    }
}
