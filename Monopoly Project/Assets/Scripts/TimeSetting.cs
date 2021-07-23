using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DanielLochner.Assets.SimpleScrollSnap
{
    public class TimeSetting : MonoBehaviour
    {
        public List<InputField> _hoursFieldList;
        public List<InputField> _minuteFieldList;

        private string _hours;
        private string _minute;
        public static int _hoursNum;
        public static int _minuteNum;
        public static int _totalMinuteTime;

        private void Start()
        {
            HoursTextForm(_hoursFieldList);
            MinuteTextForm(_minuteFieldList);
        }
        void Update()
        {
            print(_hoursNum + " , " + _minuteNum);
            ProcessMinuteTime();
            LimitMinuteTime();
        }
        void ProcessMinuteTime()
        {
            int _hoursProcess = _hoursNum * 60;
            int _minuteProcess = _minuteNum;
            _totalMinuteTime = _hoursProcess + _minuteProcess;
        }
        void LimitMinuteTime()
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
        void HoursTextForm(List<InputField> list)
        {
            for (int num = 0; num < 24; num++)
            {
                list[num].text = string.Format("{0:00}", _hoursNum);
            }

        }
        void MinuteTextForm(List<InputField> list)
        {

            for (int num = 0; num < 60; num++)
            {
                list[num].text = string.Format("{0:00}", _minuteNum);
            }

        }
        void ReadHoursTimeOutput(List<InputField> list, int min, int max)
        {
            if (min >= max)
            {
                for (int num = 0; num < 24; num++)
                {
                    list[num].text = string.Format("{0:00}", max);
                }
            }
        }
        void ReadMinuteTimeOutput(List<InputField> list, int min, int max)
        {
            if (min >= max)
            {
                for (int num = 0; num < 60; num++)
                {
                    list[num].text = string.Format("{0:00}", max);
                }
            }

        }
        void NullHoursInput(List<InputField> list)
        {
            for (int num = 0; num < 24; num++)
            {
                if (list[num].text == "")
                {
                    list[num].text = string.Format("{0:00}", _hoursNum = 0);
     
                }
            }
        }
        void NullMinuteInput(List<InputField> list)
        {
            for (int num = 0; num < 60; num++)
            {
                if (list[num].text == "")
                {
                    list[num].text = string.Format("{0:00}", _minuteNum = 0);
                }
            }
        }
        public void ReadHoursInput(string h)
        {
            _hours = h;
            if (_hours != "")
            {
                _hoursNum = int.Parse(_hours);
            }
            NullHoursInput(_hoursFieldList);
            HoursTextForm(_hoursFieldList);
            ReadHoursTimeOutput(_hoursFieldList, _hoursNum, 23);
        }
        public void ReadMinuteInput(string m)
        {
            _minute = m;
            if (_minute != "")
            {
                _minuteNum = int.Parse(_minute);
            }
            NullMinuteInput(_minuteFieldList);
            MinuteTextForm(_minuteFieldList);
            ReadMinuteTimeOutput(_minuteFieldList, _minuteNum, 59);

        }
        public void PressRollHoursPanel()
        {
            ScrollSnapHoursPage(_hoursFieldList);
        }
        public void PressRollMinutePanel()
        {
            ScrollSnapMinutePage(_minuteFieldList);
        }
        void ScrollSnapHoursPage(List<InputField> list)
        {
            for (int num = 0; num < 24; num++)
            {
                list[num].text = string.Format("{0:00}", num);
            }
        }
        void ScrollSnapMinutePage(List<InputField> list)
        {
            for (int num = 0; num < 60; num++)
            {
                list[num].text = string.Format("{0:00}", num);
            }
        }
    }
}


