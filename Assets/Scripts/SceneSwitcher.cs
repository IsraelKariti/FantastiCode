using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void SwitchTo1()
    {
        Debug.Log("open scene 1");
        SceneManager.LoadScene(0);

    }
    public void SwitchTo2()
    {
        SceneManager.LoadScene(1);

    }
    public void SwitchTo3()
    {
        SceneManager.LoadScene(2);
    }
    public void SwitchTo4()
    {
        SceneManager.LoadScene(3);
    }
    public void SwitchTo5()
    {
        SceneManager.LoadScene(4);
    }
    public void SwitchTo6()
    {
        SceneManager.LoadScene(5);

    }
    public void SwitchTo7()
    {
        SceneManager.LoadScene(6);

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
