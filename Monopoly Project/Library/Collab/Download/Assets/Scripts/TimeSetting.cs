using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Notifications.Android;

public class TimeSetting : MonoBehaviour
{
    public List<int> _hoursFieldList;
    int _numList;

    public ScrollRect scrollRect;
    public RectTransform contentPanel;
    public InputField _hoursField;
    public InputField _minuteField;
    private string _hours;
    private string _minute;
    private int _hoursNum;
    private int _minuteNum;
    public static int _totalMinuteTime;

    private void Start()
    {
        _hoursNum = PlayerPrefs.GetInt("_hoursNum");
        _minuteNum = PlayerPrefs.GetInt("_minuteNum");
        _hoursField.text = "" + _hoursNum.ToString("00");
        _minuteField.text = "" + _minuteNum.ToString("00");
    }
    void Update()
    {
        LimitTime();
        ProcessMinuteTime();
        print(_hoursNum + " , " + _minuteNum);

    }
    void ScrollSnapPage(InputField input,string text,int start, int num)
    {
        if (input.text == text)
        {
            start = num;
        }
    }
    void ProcessMinuteTime()
    {
        int _hoursProcess = _hoursNum * 60;
        int _minuteProcess = _minuteNum;
        _totalMinuteTime = _hoursProcess + _minuteProcess;
    }
    void LimitTime()
    {
        if (_hoursNum >= 24)
        {
            _hoursNum = 23;
        }
        if (_minuteNum >= 60)
        {
            _minuteNum = 59;
        }

    }
    void ReadTimeOutput(InputField time, int min, int max)
    {
        if (min >= max)
        {
            time.text = "" + max;
        }
    }
    public void ReadHoursInput(string h)
    {
        if (_hoursField.text == "")
        {
            h = "0";
        }
        _hours = h;
        _hoursNum = int.Parse(_hours);
        _hoursField.text = string.Format("{0:00}", _hoursNum);
        ReadTimeOutput(_hoursField, _hoursNum, 23);
    }
    public void ReadMinuteInput(string m)
    {
        if (_minuteField.text == "")
        {
            m = "0";
        }
        _minute = m;
        _minuteNum = int.Parse(_minute);
        _minuteField.text = string.Format("{0:00}", _minuteNum);
        ReadTimeOutput(_minuteField, _minuteNum, 59);
    }
    public void PressHoldHours()
    {
        print("holdHours");
    }
    public void PressHoldMinute()
    {
        print("holdMinute");
    }
    public void SaveTime()
    {
        PlayerPrefs.SetInt("_hoursNum", _hoursNum);
        PlayerPrefs.SetInt("_minuteNum", _minuteNum);
    }
}

