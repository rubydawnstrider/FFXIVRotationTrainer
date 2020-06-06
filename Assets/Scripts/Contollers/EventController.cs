using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventController : MonoBehaviour
{
    public class SkillEvent : UnityEvent<string> { }

    private Dictionary<string, SkillEvent> _events;

    private static EventController _instance;
    public static EventController Instance
    {
        get
        {
            if (!_instance)
            {
                _instance = FindObjectOfType<EventController>();

                if (!_instance)
                {
                    Debug.LogError("add an active EventManager to the scene!");
                }
                else
                {
                    _instance.Initialize();
                }
            }
            return _instance;
        }
    }

    private void Initialize()
    {
        if (_events == null)
        {
            _events = new Dictionary<string, SkillEvent>();
        }
    }

    public static void StartListening(string eventName, UnityAction<string> listener)
    {
        SkillEvent currentEvent;

        if (Instance._events.TryGetValue(eventName, out currentEvent))
        {
            currentEvent.AddListener(listener);
        }
        else
        {
            currentEvent = new SkillEvent();
            currentEvent.AddListener(listener);
            Instance._events.Add(eventName, currentEvent);
        }
    }

    public static void StopListening(string eventName, UnityAction<string> listener)
    {
        if (Instance == null)
        {
            return;
        }

        if (Instance._events.TryGetValue(eventName, out var currentEvent))
        {
            currentEvent.RemoveListener(listener);
            currentEvent.RemoveListener(listener);
        }
    }

    public static void TriggerEvent(string eventName, string caller)
    {
        if (Instance._events.TryGetValue(eventName, out var currentEvent))
        {
            currentEvent.Invoke(caller);
        }
    }
}
