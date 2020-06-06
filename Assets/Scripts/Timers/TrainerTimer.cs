using System;
using UnityEngine;
using UnityEngine.UI;

public class TrainerTimer : ActionTimer
{
    private Image _cooldownOuter;
    private Image _cooldownInner;

    public override void StartTiming(float totalTime, Action timerFinishedCallback)
    {
        _cooldownOuter = Instantiate(TrainerController.Instance.TimerOuterImage, transform);
        _cooldownInner = Instantiate(TrainerController.Instance.TimerInnerImage, transform);

        base.StartTiming(totalTime, timerFinishedCallback);
    }

    void Update()
    {
        if (_isTiming)
        {
            if (_cooldownInner.fillAmount == 0)
            {
                Destroy(_cooldownInner.gameObject);
                Destroy(_cooldownOuter.gameObject);
                _isTiming = false;
                _endCallback.Invoke();
            }
            else
            {
                _elapsedTime += Time.deltaTime;
                _cooldownInner.fillAmount = Mathf.Clamp(1 - (_elapsedTime / _totalTime), 0f, 1f);
            }
        }
    }
}
