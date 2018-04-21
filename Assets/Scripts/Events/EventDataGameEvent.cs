using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Custom/EventDataGameEvent")]
public class EventDataGameEvent : ScriptableObject
{
    /// <summary>
    /// The list of listeners that this event will notify if it is raised.
    /// </summary>
    private readonly List<EventDataGameEventListener> eventListeners =
        new List<EventDataGameEventListener>();

    public void Raise(EventData value)
    {
        for (int i = eventListeners.Count - 1; i >= 0; i--)
        {
            eventListeners[i].OnEventRaised(value);
        }
    }

    public void RegisterListener(EventDataGameEventListener listener)
    {
        if (!eventListeners.Contains(listener))
        {
            eventListeners.Add(listener);
        }
    }

    public void UnregisterListener(EventDataGameEventListener listener)
    {
        if (eventListeners.Contains(listener))
        {
            eventListeners.Remove(listener);
        }
    }
}