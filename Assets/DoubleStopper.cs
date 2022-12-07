using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleStopper : MonoBehaviour
{
    public float expTime;
    private bool last;

    TunnelSpawner tunnelSpawn;
    TunnelManager tunnelManager;

    void OnEnable()
    {

        tunnelSpawn = TunnelSpawner.GetInstance();
        tunnelManager = GetComponent<TunnelManager>();


        //if (tunnelSpawn.expTime >= 12f)

            if (tunnelManager.tunnelNum == 4)
            {
                //last = true;
                Destroy(transform.parent.gameObject);
            }






    }



    void Update()
    {
        expTime = Time.timeSinceLevelLoad;





    }


    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Top points collided."); //weirdly even though nothing gets shown in log these collisions are still
                                             //happening. Probably because it gets destroyed straight after.


        if (other.CompareTag("Top"))
        {
        // spawned = true;
         Destroy(other.transform.parent.gameObject);
         }

        //if tag of collider is "Top" (middle one) then destroy the other tunnel itself instead of the collider.

    }
}
