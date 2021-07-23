using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Question : MonoBehaviour
{
    public GameObject _help;
    public Button _helpButton1, _helpButton2, _helpButton3;
    public Text _countdownText;
    public Image _countdownImage;
    float _countTime = 30;
    bool _bonusTime;
    bool _startTime;

    int _talkNPC = 1;
    public GameObject _talk;
    public Text _descriptionText;
    bool _cooldown;

    public Text _questNumText;
    public Text _questionText;
    int _questNum = 1;
    int _randomNum;

    public Text _ansAText , _ansBText , _ansCText , _ansDText;
    public Button _ansAButton , _ansBButton , _ansCButton , _ansDButton;
    int _collect;

    List<int> list = new List<int>();
    int _randomRemove;

    private void Start()
    {
        GenerateRandom(1, 11);
    }
    void Update()
    {
        _questNumText.text = "คำถามที่ : " + _questNum;
        NpcTalk();
    }
    private void FixedUpdate()
    {
        StartTime();
    }
    void StartTime()
    {
        if (_startTime == true)
        {
            _countdownText.text = Mathf.Round(_countTime).ToString();
            _countdownImage.fillAmount -= Time.deltaTime;

            if (_countdownImage.fillAmount <= 0)
            {
                _countTime -= 1;
                _countdownImage.fillAmount = 1;
            }

            if (_countTime <= 0)
            {
                _countTime = 0;
                _countdownText.text = "" + _countTime;
                _countdownImage.fillAmount = 0;
            }
        }

        if (_countTime >= 30 && _bonusTime == false)
        {
            _countTime = 30;
        }
        if (_countTime <= 0)
        {
            _talkNPC = 12;
            _countTime += 30;
        }
    }
    void NpcTalk()
    {
        if (_cooldown == false)
        {
            _talk.SetActive(true);
            switch (_talkNPC)
            {
                case 1:
                    _startTime = false;
                    _descriptionText.text = "\"" + "สวัสดี" + "\"";
                    StartCoroutine(cooldownTalk(3));
                    _cooldown = true;
                    break;
                case 2:
                    _startTime = false;
                    _descriptionText.text = "\"" + "ฉันเป็นพิธีกร ดำเนินรายการ" + "\"";
                    StartCoroutine(cooldownTalk(3));
                    _cooldown = true;
                    break;
                case 3:
                    _startTime = false;
                    _descriptionText.text = "\"" + "เธอต้องตอบ คำถามให้ถูก ต้องทั้งหมด 10 ข้อ" + "\"";
                    StartCoroutine(cooldownTalk(3));
                    _cooldown = true;
                    break;
                case 4:
                    _startTime = false;
                    _descriptionText.text = "\"" + "มาเริ่มเล่นเกมกันเถอะ" + "\"";
                    StartCoroutine(cooldownTalk(3));
                    _cooldown = true;
                    break;
                case 5:
                    _help.SetActive(true);
                    _startTime = true;
                    _talk.SetActive(false);
                    numQuest();
                    break;
                case 6:
                    _startTime = false;
                    StartCoroutine(cooldownTalk(3));
                    _cooldown = true;
                    break;
                case 7:
                    _startTime = true;
                    _talk.SetActive(false);
                    numQuest();
                    break;
                case 8:
                    _startTime = false;
                    _descriptionText.text = "\"" + "ตอบถูกต้อง" + "\"";
                    StartCoroutine(cooldownTalk(3));
                    _cooldown = true;
                    break;
                case 9:
                    _startTime = true;
                    _talk.SetActive(false);
                    numQuest();
                    break;
                case 10:
                    _startTime = false;
                    _descriptionText.text = "\"" + "ตอบยังไม่ถูกต้องนะ" + "\"";
                    StartCoroutine(cooldownTalk(3));
                    _cooldown = true;
                    break;
                case 11:
                    SceneManager.LoadScene(1);
                    break;
                case 12:
                    _startTime = false;
                    _descriptionText.text = "\"" + "เวลาหมดแล้ว! ไว้มาเล่นกันใหม่นะ" + "\"";
                    StartCoroutine(cooldownTalk(3));
                    _cooldown = true;
                    break;
                case 13:
                    SceneManager.LoadScene(1);
                    break;
                case 14:
                    _startTime = false;
                    _descriptionText.text = "\"" + "เก่งจังเลย ! ตอบถูกหมดทุกข้อ" + "\"";
                    StartCoroutine(cooldownTalk(3));
                    _cooldown = true;
                    break;
                case 15:
                    SceneManager.LoadScene(1);
                    break;
            }
        }
    }
    void numQuest()
    {
        switch (_randomNum)
        {
            case 1 :
                _questionText.text = "สัตว์ชนิดใดเป็นสัตว์บก";
                _ansAText.text = "ข้อ 1: ปลา";
                _ansBText.text = "ข้อ 2: นก";
                _ansCText.text = "ข้อ 3: กุ้ง";
                _ansDText.text = "ข้อ 4: แมว";
                _collect = 4;
                break;
            case 2:
                _questionText.text = "ไก่มีกี่ขา";
                _ansAText.text = "ข้อ 1: สองขา";
                _ansBText.text = "ข้อ 2: สี่ขา";
                _ansCText.text = "ข้อ 3: หกขา";
                _ansDText.text = "ข้อ 4: แปดขา";
                _collect = 1;
                break;
            case 3:
                _questionText.text = "ทีมฟุตบอลใดอ่อนที่สุด";
                _ansAText.text = "ข้อ 1: เลสเตอร์";
                _ansBText.text = "ข้อ 2: ลิเวอร์พูล";
                _ansCText.text = "ข้อ 3: แมนยู";
                _ansDText.text = "ข้อ 4: เชลซี";
                _collect = 3;
                break;
            case 4:
                _questionText.text = "ใครเป็นพระเอกในเรื่อง DragonBall";
                _ansAText.text = "ข้อ 1: โงกุน";
                _ansBText.text = "ข้อ 2: จีจี้";
                _ansCText.text = "ข้อ 3: คุริริน";
                _ansDText.text = "ข้อ 4: พิคโกโร่";
                _collect = 1;
                break;
            case 5:
                _questionText.text = "นิทานเรื่องกระต่ายกับเต่า ใครเป็นผู้ชนะ";
                _ansAText.text = "ข้อ 1: กระต่าย";
                _ansBText.text = "ข้อ 2: เต่า";
                _ansCText.text = "ข้อ 3: กระรอก";
                _ansDText.text = "ข้อ 4: หนู";
                _collect = 2;
                break;
            case 6:
                _questionText.text = "ร้านอาหาร KFC ขายอะไร";
                _ansAText.text = "ข้อ 1: หมู";
                _ansBText.text = "ข้อ 2: เห็ด";
                _ansCText.text = "ข้อ 3: เป็ด";
                _ansDText.text = "ข้อ 4: ไก่";
                _collect = 4;
                break;
            case 7:
                _questionText.text = "ข้อใดไม่ใช่แอปพลิเคชันสั่งอาหาร";
                _ansAText.text = "ข้อ 1: LineMan";
                _ansBText.text = "ข้อ 2: Gojek";
                _ansCText.text = "ข้อ 3: Facebook";
                _ansDText.text = "ข้อ 4: GrabFood";
                _collect = 3;
                break;
            case 8:
                _questionText.text = "ข้อใดเป็นเกมแนว Battle Royale";
                _ansAText.text = "ข้อ 1: Getamped";
                _ansBText.text = "ข้อ 2: Pubg";
                _ansCText.text = "ข้อ 3: Yulgang";
                _ansDText.text = "ข้อ 4: Ragnarok";
                _collect = 2;
                break;
            case 9:
                _questionText.text = "เกมแนว Moba โดยทั่วไปเล่นฝั่งละกี่คน";
                _ansAText.text = "ข้อ 1: 3-3";
                _ansBText.text = "ข้อ 2: 5-5";
                _ansCText.text = "ข้อ 3: 7-7";
                _ansDText.text = "ข้อ 4: 10-10";
                _collect = 2;
                break;
            case 10:
                _questionText.text = "ทีมงานใน ZaiStudio เป็นอย่างไร";
                _ansAText.text = "ข้อ 1: หน้าตาดี";
                _ansBText.text = "ข้อ 2: เป็นคนเก่ง";
                _ansCText.text = "ข้อ 3: ขยันขันแข็ง";
                _ansDText.text = "ข้อ 4: ถูกทุกข้อ";
                _collect = 4;
                break;
        }
    }
    public void ansCollectButton(int collect)
    {
        if (_collect == collect)
        {
            ButtonRemove(_ansAButton, _randomRemove, 1, true);
            ButtonRemove(_ansBButton, _randomRemove, 2, true);
            ButtonRemove(_ansCButton, _randomRemove, 3, true);
            ButtonRemove(_ansDButton, _randomRemove, 4, true);
            _bonusTime = false;
            _countTime += 30;
            _questNum += 1;
            _talkNPC = 8;
            GenerateRandom(1, 11);
        }
        else
        {
            _talkNPC = 10;
        }
    }
    void GenerateRandom(int min, int max)
    {
        if (_questNum <= 10)
        {
            _randomNum = Random.Range(min, max);
            while (list.Contains(_randomNum))
            {
                _randomNum = Random.Range(min, max);
            }
            list.Add(_randomNum);
        }
        else
        {
            _talkNPC = 14;
        }
    }
 
    public void Help1()
    {
        _bonusTime = true;
        _countTime += _countTime;
        _helpButton1.gameObject.SetActive(false);
    }

    public void Help2()
    {
        List<int> list = new List<int>(new int[5]);

        for (int i = 0; i < 2; i++)
        {
            _randomRemove = Random.Range(1, 5);

            do
            {
                while (list.Contains(_randomRemove))
                {
                    _randomRemove = Random.Range(1, 5);
                }
                list[i] = _randomRemove;
            }

            while (_randomRemove == _collect);
            ButtonRemove(_ansAButton, _randomRemove, 1, false);
            ButtonRemove(_ansBButton, _randomRemove, 2, false);
            ButtonRemove(_ansCButton, _randomRemove, 3, false);
            ButtonRemove(_ansDButton, _randomRemove, 4, false);
        }
        _helpButton2.gameObject.SetActive(false);

    }
    void ButtonRemove(Button button , int random , int num , bool checkObj)
    {
        if (random == num && checkObj == false)
        {
            button.gameObject.SetActive(false);
        }
        else if (checkObj == true)
        {
            button.gameObject.SetActive(true);
        }
 
    }
    public void Help3()
    {
        _talkNPC = 6;
        float random = Random.value;

        if (random > 0.6) //%40 percent chance
        {
            _descriptionText.text = "\"" + "ก็ไม่รู้สินะ" + "\"";
        }

        else if (random < 0.4) //%40 percent chance
        {
            _descriptionText.text = "\"" + "คำตอบที่ถูกต้องคือข้อ : " + _collect + "\"";
        }
        else //%20 percent chance
        {
            int randomChance = Random.Range(1, 5);
            while (randomChance == _collect)
            {
                randomChance = Random.Range(1, 5);
                print(randomChance);
            }
            _descriptionText.text = "\"" + "คำตอบที่ถูกต้องคือข้อ : " + randomChance + "\"";
        }
        _helpButton3.gameObject.SetActive(false);
    }
    IEnumerator cooldownTalk(float time)
    {
        yield return new WaitForSeconds(time);
        _talkNPC += 1;
        _cooldown = false;
    }
}
