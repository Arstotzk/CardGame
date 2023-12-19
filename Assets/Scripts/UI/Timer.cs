using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    [SerializeField] private float time;
    public TMP_Text timerText;

    private float _timeLeft = 0f;
    public bool timerOn = false;

    private void Start()
    {

    }

    private void Update()
    {
        if (timerOn)
        {
            if (_timeLeft > 0)
            {
                _timeLeft -= Time.deltaTime;
                UpdateTimeText();
            }
            else
            {
                _timeLeft = time;
                timerOn = false;
            }
        }
    }
    public void TimerStart(float time)
    {
        _timeLeft = time;
        timerOn = true;
    }

    private void UpdateTimeText()
    {
        if (_timeLeft < 0)
            _timeLeft = 0;

        float minutes = Mathf.FloorToInt(_timeLeft / 60);
        float seconds = Mathf.FloorToInt(_timeLeft % 60);
        timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
}
