using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[ExecuteInEditMode]
public class GoodWork : MonoBehaviour
{

    private void Start()
    {
        transform.localPosition = new Vector3(5, -3, -6);
        transform.localScale = new Vector3(1, 1, 1);
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/fantasticodeNextButton");
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            int sceneIndex = SceneManager.GetActiveScene().buildIndex;
            
            if (sceneIndex < SceneManager.sceneCountInBuildSettings-1)
            {

                gameObject.SetActive(false);
                SceneManager.LoadScene(sceneIndex + 1);
            }
        }
    }
}
