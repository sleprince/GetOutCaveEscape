using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleStopper : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Top points collided."); //weirdly even though nothing gets shown in log these collisions are still
                                             //happening. Probably because it gets destroyed straight after.


        if (other.CompareTag("Top"))
        {
        // spawned = true;
         Destroy(transform.parent.gameObject);
         }

        //if tag of collider is "Tunnel" (middle one) then destroy the tunnel itself instead of the spawn point.

    }
}
