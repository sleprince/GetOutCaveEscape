using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleStopper : MonoBehaviour
{
    //public float expTime;
    //private bool last;

   // TunnelSpawner tunnelSpawn;
    TunnelManager tunnelManager;
    GameflowManager game;

   // Coroutine coroutine;

   // public bool SpawnedOnTop;

    void Start()
    {

        //tunnelSpawn = TunnelSpawner.GetInstance();
        tunnelManager = this.GetComponentInParent<TunnelManager>();
        game = GameflowManager.GetInstance();


        //if (tunnelSpawn.expTime >= 12f)

        if (tunnelManager.tunnelNum == game.levelNumTunnels)
            {
            //last = true;
            Invoke("Destroy", 5.0f);
            
            }


       // coroutine = TimeHater(5.0f);




    }

   void Destroy()
    {
        //Destroy(transform.parent.gameObject);
        this.transform.parent.gameObject.SetActive(false);

    }



    void Update()
    {
        //expTime = Time.timeSinceLevelLoad;





    }


    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Top points collided."); //weirdly even though nothing gets shown in log these collisions are still
                                             //happening. Probably because it gets destroyed straight after.


        if (other.CompareTag("Top"))
        {
            // spawned = true;
            StartCoroutine(TimeHater(2.0f, other));
            //Destroy(other.transform.parent.gameObject);


            //SpawnedOnTop = true;
            TunnelSpawner tunSpawn =  GetComponentInParent<TunnelSpawner>(); //get this block's TunnelSpawner
            tunSpawn.spawned = false; //spawned reverts to false if block placed on top of another.
            game.tunnelNum--; //if a tunnel placed innapropriately has destroyed the one it's
                              //spawned on top of, reduce the number of tunnels ing game counter.

        }

        //if tag of collider is "Top" (middle one) then destroy the other tunnel itself instead of the collider.

    }

    IEnumerator TimeHater(float timer, Collider other)
     {
          yield return new WaitForSeconds(timer);
          other.transform.parent.gameObject.SetActive(false);

        //spawned = true;
    }
}
