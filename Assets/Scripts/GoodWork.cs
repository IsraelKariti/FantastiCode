using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoodWork : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            int sceneIndex = SceneManager.GetActiveScene().buildIndex;

            if (sceneIndex < 9)
            {

                gameObject.SetActive(false);
                SceneManager.LoadScene(sceneIndex + 1);
            }
        }
    }
}
