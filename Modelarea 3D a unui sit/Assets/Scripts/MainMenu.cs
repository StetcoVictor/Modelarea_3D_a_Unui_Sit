using System.Collections;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    string path;
    public GameObject imputField;
    public GameObject errorTxt;

    public void PlayAction()
    {
        //System.Diagnostics.Process.Start(m_Path + "/Resources/StellariumStart.bat");
        //System.Diagnostics.Process.Start("C:/Users/Victor/Desktop/Stellarium.bat");
        try
        {
            System.Diagnostics.Process.Start(path);
        }
        catch
        {
            errorTxt.GetComponent<Text>().text = "Something went wrong with the file path";
            errorTxt.SetActive(true);
        }
        Invoke("Action", 10.0f);
    }

    private void Action()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitAction()
    {
        Application.Quit();
    }

    public void getPath()
    {
        path = imputField.GetComponent<Text>().text;
    }
}
