using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public GameObject goodWork;
    public void SwitchTo1()
    {
        Debug.Log("open scene 1");
        goodWork.SetActive(false);
        SceneManager.LoadScene(0);

    }
    public void SwitchTo2()
    {
        goodWork.SetActive(false);
        SceneManager.LoadScene(1);

    }
    public void SwitchTo3()
    {
        goodWork.SetActive(false);
        SceneManager.LoadScene(2);
    }
    public void SwitchTo4()
    {
        goodWork.SetActive(false);
        SceneManager.LoadScene(3);
    }
    public void SwitchTo5()
    {
        goodWork.SetActive(false);
        SceneManager.LoadScene(4);
    }
    public void SwitchTo6()
    {
        goodWork.SetActive(false);
        SceneManager.LoadScene(5);

    }
    public void SwitchTo7()
    {
        goodWork.SetActive(false);
        SceneManager.LoadScene(6);

    }
    public void SwitchTo8()
    {
        goodWork.SetActive(false);
        SceneManager.LoadScene(7);
    }
    public void SwitchTo9()
    {

    }
    public void SwitchTo10()
    {

    }
}
