using UnityEngine;
using UnityEngine.SceneManagement;

public class GroundCollision : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("You stood on the ground.");

        if (SceneManager.GetActiveScene().buildIndex == 3)
         {
            SceneManager.LoadScene("YouWin");

         }

         else
        {
        //load the nextlevel
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }
    }
}
