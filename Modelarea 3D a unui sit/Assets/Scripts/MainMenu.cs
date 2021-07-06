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
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayAction()
    {
        string m_Path = Application.dataPath;
        System.Diagnostics.Process.Start(m_Path + "/Resources/StellariumStart.bat");
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
}
