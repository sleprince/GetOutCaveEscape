using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameflowManager : MonoBehaviour
{
    public GameObject scale;
    private Vector3 maxScale = new Vector3(2.5f,2.5f,2.5f);
    //public bool TooBig;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public bool TooBig()
    {
        return scale.transform.localScale == maxScale;

    }


    // Update is called once per frame
    void Update()
    {
        if (scale.transform.localScale.y > 2.5f)
        {

                SceneManager.LoadScene("GameOver");
        }

    }
}
