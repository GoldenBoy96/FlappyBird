using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EventDispatcher : MonoBehaviour
{
    public static EventDispatcher Instance = null;

    Dictionary<EventID, List<Action<object>>> EventRegistered = new();

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    // Register to listen for eventID, callback will be invoke when event with eventID be raise
    public void RegisterListener(EventID eventID, Action<object> callback)
    {
        if (EventRegistered.ContainsKey(eventID))
        {
            EventRegistered[eventID].Add(callback);
        } else
        {
            EventRegistered.Add(eventID, new());
            EventRegistered[eventID].Add(callback);
        }
        
    }

    // Post event, this will notify all listener which register to listen for eventID
    public void PostEvent(EventID eventID, Component sender, object param = null) { 
        foreach(Action<object> callback in EventRegistered[eventID])
        {
            callback.Invoke(param);
        }
    }

    // Use for Unregister, not listen for an event anymore.
    public void RemoveListener(EventID eventID, Action<object> callback)
    {
        
        if (EventRegistered.ContainsKey(eventID))
        {
            EventRegistered[eventID].Remove(callback);
        }
    }
}


public enum EventID
{
    None = 0,
    OnScoreChange,
}
