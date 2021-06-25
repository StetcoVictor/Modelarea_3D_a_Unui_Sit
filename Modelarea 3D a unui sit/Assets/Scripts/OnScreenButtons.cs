using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entropedia;

public class OnScreenButtons : MonoBehaviour
{
    [SerializeField]
    Entropedia.Sun sun;

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
        DateTime date = new DateTime(2020, 6, 21);
        sun.SetTime(8, 15);
        sun.SetDate(date);

    }

    public void increseTimeSpeed()
    {
        sun.SetTimeSpeed(sun.GetTimeSpeed() * 2);
    }

    public void decreseTimeSpeed()
    {
        if (sun.GetTimeSpeed() > 2)
            sun.SetTimeSpeed(sun.GetTimeSpeed() / 2);
        else
            sun.SetTimeSpeed(-1);

        if (sun.GetTimeSpeed() < 0)
            sun.SetTimeSpeed(sun.GetTimeSpeed() * 2);

    }

    public void resetTimeSpeed()
    {
        sun.SetTimeSpeed(1);
    }
}