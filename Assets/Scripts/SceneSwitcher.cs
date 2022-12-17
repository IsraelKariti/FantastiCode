using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void SwitchTo1()
    {
        Debug.Log("open scene 1");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);

    }
    public void SwitchTo2()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
    public void SwitchTo3()
    {

    }
    public void SwitchTo4()
    {

    }
    public void SwitchTo5()
    {

    }
    public void SwitchTo6()
    {

    }
    public void SwitchTo7()
    {

    }
    public void SwitchTo8()
    {

    }
    public void SwitchTo9()
    {

    }
    public void SwitchTo10()
    {

    }
}
