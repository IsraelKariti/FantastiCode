using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// for arrow and image explanatory
public class Guidance : MonoBehaviour
{
    public GameObject[] arrows;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            foreach(GameObject arrow in arrows)
                arrow.SetActive(true); 
            Destroy(gameObject);
        }
    }
}
