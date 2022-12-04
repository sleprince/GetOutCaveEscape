using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enlarge : MonoBehaviour
{

    public Vector3 expTime;

    // Start is called before the first frame update
    void Start()
    {
        expTime = new Vector3(Time.fixedTime, Time.fixedTime, Time.fixedTime);

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.localScale = transform.localScale + expTime;


    }
}
