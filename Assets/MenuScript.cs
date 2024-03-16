using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void OnStartButton(){
        SceneManager.LoadScene("SampleScene");
    }
    public void OnQuitButton ()
    {
        Application.Quit();
    }
}
