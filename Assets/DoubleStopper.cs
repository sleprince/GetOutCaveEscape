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

    public bool SpawnedOnTop;

    void OnEnable()
    {

        //tunnelSpawn = TunnelSpawner.GetInstance();
        tunnelManager = GetComponent<TunnelManager>();
        game = GetComponent<GameflowManager>();


        //if (tunnelSpawn.expTime >= 12f)

            if (tunnelManager.tunnelNum == game.levelNumTunnels + 1)
            {
            //last = true;
            Invoke("Destroy", 0.1f);
            
            }






    }

   void Destroy()
    {
        Destroy(transform.parent.gameObject);

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
            //TimeHater(0.5f, other);
            Destroy(other.transform.parent.gameObject);

            //SpawnedOnTop = true;
            TunnelSpawner tunSpawn =  GetComponentInParent<TunnelSpawner>(); //get this block's TunnelSpawner
            tunSpawn.spawned = false; //spawned reverts to false if block placed on top of another.
            game.tunnelNum--; //if a tunnel placed innapropriately has destroyed the one it's
                              //spawned on top of, reduce the number of tunnels ing game counter.

        }

        //if tag of collider is "Top" (middle one) then destroy the other tunnel itself instead of the collider.

    }

    //IEnumerator TimeHater(float timer, Collider other)
   // {
    //    yield return new WaitForSeconds(timer);
        

        //spawned = true;
   // }
}
