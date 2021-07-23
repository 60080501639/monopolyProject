using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
namespace DanielLochner.Assets.SimpleScrollSnap
{
    public class GameManager : MonoBehaviour
    {
        public Animator _animPlay;
        public Animator _animSave;
        private void Start()
        {
            TimeSetting._hoursNum = PlayerPrefs.GetInt("_hoursNum");
            TimeSetting._minuteNum = PlayerPrefs.GetInt("_minuteNum");
        }
        public void PlayGame(int scene)
        {
            if (System.DateTime.Now >= System.DateTime.Today.AddMinutes(TimeSetting._totalMinuteTime))
            {
                SceneManager.LoadScene(scene);
            }
            else
            {
                _animPlay.gameObject.SetActive(true);
                _animPlay.Play(0);
            }
        }
        public void Exit()
        {
            Application.Quit();
        }
        public void SaveTime()
        {
            PlayerPrefs.SetInt("_hoursNum", TimeSetting._hoursNum);
            PlayerPrefs.SetInt("_minuteNum", TimeSetting._minuteNum);
            _animSave.gameObject.SetActive(true);
            _animSave.Play(0);
        }
    }
}
