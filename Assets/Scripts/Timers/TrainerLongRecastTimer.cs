using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrainerLongRecastTimer : ActionTimer
{
    private Image _cooldownOuter;
    private Image _cooldownInner;

    void Update()
    {
        if (_isTiming)
        {
            if (_cooldownInner.fillAmount == 0)
            {
                Destroy(_cooldownInner.gameObject);
                Destroy(_cooldownOuter.gameObject);
                _isTiming = false;
                _cooldownText.text = "";
                _endCallback.Invoke();
            }
            else
            {
                _elapsedTime += Time.deltaTime;
                _cooldownInner.fillAmount = Mathf.Clamp(1 - (_elapsedTime / _totalTime), 0f, 1f);
                _cooldownText.text = Mathf.RoundToInt(_totalTime - _elapsedTime).ToString();
            }
        }
    }

    public override void StartTiming(float totalTime, Action timerFinishedCallback)
    {
        _cooldownOuter = Instantiate(TrainerController.Instance.TimerOuterImage, transform);
        _cooldownInner = Instantiate(TrainerController.Instance.TimerInnerImage, transform);
        if (!_cooldownText)
        {
            _cooldownText = Instantiate(TrainerController.Instance.RecastText, transform);
        }
        base.StartTiming(totalTime, timerFinishedCallback);
    }
}
