using System;
using UnityEngine;
using UnityEngine.UI;

public class TrainerGcdRecastTimer : ActionTimer
{
    private Image _cooldownSecondary;

    // Update is called once per frame
    void Update()
    {
        if (_isTiming)
        {
            _cooldownText.transform.SetAsLastSibling();
            if (_cooldownSecondary.fillAmount == 1)
            {
                Destroy(_cooldownSecondary.gameObject);
                _isTiming = false;
                _cooldownText.text = "";
                _endCallback.Invoke();
            }
            else
            {
                _elapsedTime += Time.deltaTime;
                _cooldownSecondary.fillAmount = Mathf.Clamp(_elapsedTime / _totalTime, 0f, 1f);
                _cooldownText.text = Mathf.RoundToInt(_totalTime - _elapsedTime).ToString();
            }
        }
    }

    public override void StartTiming(float totalTime, Action timerFinishedCallback)
    {
        if (!_isTiming)
        {
            _cooldownSecondary = Instantiate(TrainerController.Instance.TimerGcdWithRecastImage, transform);
            if (!_cooldownText)
            {
                _cooldownText = Instantiate(TrainerController.Instance.RecastText, transform);
            }
            base.StartTiming(totalTime, timerFinishedCallback);
        }
    }
}
