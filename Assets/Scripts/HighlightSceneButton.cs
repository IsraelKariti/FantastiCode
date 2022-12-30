using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class HighlightSceneButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        GameObject buttonGO = transform.GetChild(sceneIndex).gameObject;
        Image buttonImage = buttonGO.GetComponent<Image>();
        buttonImage.color = new Color(255, 0, 0);
    }

}
