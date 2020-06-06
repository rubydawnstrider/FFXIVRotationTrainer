using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionTimer : MonoBehaviour
{
    protected float _totalTime;
    protected float _elapsedTime;
    public float ElapsedTime { get { return _elapsedTime; } }

    protected Action _endCallback;

    protected Text _cooldownText;

    protected bool _isTiming;
    public bool IsTiming()
    {
        return _isTiming;
    }

    public virtual void StartTiming(float totalTime, Action timerFinishedCallback)
    {
        _isTiming = true;
        _endCallback = timerFinishedCallback;
        _totalTime = totalTime;
        _elapsedTime = 0;
    }

}
