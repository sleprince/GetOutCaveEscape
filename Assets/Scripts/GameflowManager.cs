using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameflowManager : MonoBehaviour
{
    public GameObject scale;
    public GameObject floorMesh;

    public BoxCollider ground;

    public int tunnelNum;
    public int levelNumTunnels;

    //public bool onTop;
    public bool tunnelAdded;

    public float expTime;

    //public int tunelsSpawned;

    private Vector3 maxScale = new Vector3(2.5f,2.5f,2.5f);
    //public bool TooBig;

    // Start is called before the first frame update
    void Start()
    {
        //get the mesh collider from the ground.
        ground = floorMesh.GetComponentInChildren<BoxCollider>(true) as BoxCollider;

    }

    public bool TooBig()
    {
        return scale.transform.localScale == maxScale;

    }


    // Update is called once per frame
    void Update()
    {
        if (scale.transform.localScale.y > 5f)
        {

            Completed.SoundManager.instance.efxSource.Play();

            SceneManager.LoadScene("GameOver");
        }

        expTime = Time.deltaTime;


    }

    void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene("YouWin");
    }

    public static GameflowManager instance;
    public static GameflowManager GetInstance()
    {
        return instance;
    }

    void Awake()
    {
        instance = this;
        //DontDestroyOnLoad(this.gameObject);
    }

}
