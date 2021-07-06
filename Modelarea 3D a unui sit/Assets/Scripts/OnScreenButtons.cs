using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entropedia;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnScreenButtons : MonoBehaviour
{
    [SerializeField]
    Entropedia.Sun sun; 
    public GameObject player;

    public void setMorningEvent()
    {
        sun.SetTime(6, 50);
    }

    public void setSunSetEvent()
    {
        sun.SetTime(19, 50);
    }

    public void setEquinoxEvent()
    {
        DateTime date = new DateTime(2021, 1, 21);
        sun.SetDate(date);
        sun.SetTime(8, 0);
        sun.SetTimeSpeed(100);
        float x = 73;
        float y = 6;
        float z = 318;
        player.transform.Rotate(0, 0, 0);
        float xR = 0;
        float yR = 120;
        float zR = 0;
        player.transform.position = new Vector3(x, y, z);
        player.transform.Rotate(xR, yR, zR);

    }

    public void increseTimeSpeed()
    {
        if (sun.GetTimeSpeed() < 0)
            sun.SetTimeSpeed(1);
        else if (sun.GetTimeSpeed() < 500)
                sun.SetTimeSpeed(sun.GetTimeSpeed() * 500);
            else
                sun.SetTimeSpeed(sun.GetTimeSpeed() * 2);
    }

    public void decreseTimeSpeed()
    {
        if (sun.GetTimeSpeed() > 2)
            sun.SetTimeSpeed(sun.GetTimeSpeed() / 2);
        else
            sun.SetTimeSpeed(-1000);

        if (sun.GetTimeSpeed() < 0)
            sun.SetTimeSpeed(sun.GetTimeSpeed() * 2);

    }

    public void resetTimeSpeed()
    {
        sun.SetTimeSpeed(1);
    }

    public void backToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}