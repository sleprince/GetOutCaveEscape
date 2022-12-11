using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoWayOut : MonoBehaviour
{

    GameflowManager game;

    // Start is called before the first frame update
    void Start()
    {
        game = GameflowManager.GetInstance();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if(game.tunnelNum >= 3)
        {
            this.gameObject.SetActive(false);


        }
        
    }
}
