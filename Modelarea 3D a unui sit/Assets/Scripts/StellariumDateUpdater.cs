using UnityEngine;
using UnityEngine.UI;
using Stellarium;
using Stellarium.Services;
using UnityEngine.EventSystems;
using Entropedia;

public class StellariumDateUpdater : MonoBehaviour
{

    [SerializeField]
    Entropedia.Sun sun;

    [SerializeField]
    int hour, minute, second, month, day, year;

    Status status;

    void OnEnable()
    {
        MainService.OnGotStatus += OnGotStatus;
        MainService.OnSetTime += OnSetTime;
    }

    private void Update()
    {
        hour = sun.getHour();
        minute = sun.getMinutes();
        second = sun.getSeconds();
        month = sun.getMonth();
        day = sun.getDay();
        year = sun.getYear();
        UpdateDateTime();
    }

    public void GenerateSkybox()
    {
        StellariumServer.Instance.ScriptService.Run("skybox.ssc");
    }

    public void GetStatus()
    {
        StellariumServer.Instance.MainService.GetStatus(status.actionChanges.id, status.propertyChanges.id);
    }

    void Start()
    {
        Application.runInBackground = true;
        StellariumServer.Instance.MainService.GetStatus();
    }

    void OnGotStatus(Status result)
    {
        status = result;
        CustomDateTime stellariumDateTime = new CustomDateTime(result.time.jday);
        hour = sun.getHour();
        minute = sun.getMinutes();
        second = sun.getSeconds();
        month = sun.getMonth();
        day = sun.getDay();
        year = sun.getYear();
    }

    private void OnSetTime()
    {
        StellariumServer.Instance.MainService.GetStatus(status.actionChanges.id, status.propertyChanges.id);
    }

    public void UpdateDateTime()
    {
        StellariumServer.Instance.MainService.SetTime(CustomDateTime.ToJulianDay(new CustomDateTime(
            year,
            month,
            day,
            hour,
            minute,
            second,
            (CustomDateTime.Era)(year < 0 ? 0 : 1)
            )),
            0f
        );
    }

    void OnDisable()
    {
        MainService.OnGotStatus -= OnGotStatus;
        MainService.OnSetTime -= OnSetTime;
    }

}
