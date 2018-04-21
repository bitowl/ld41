using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Events/ShowPanelEvent")]
public class ShowPanelEvent : ScriptableObject
{
    /// <summary>
    /// The list of listeners that this event will notify if it is raised.
    /// </summary>
    private readonly List<ShowPanelEventListener> eventListeners =
        new List<ShowPanelEventListener>();

    public void Raise(ShowPanelEventData value)
    {
        for (int i = eventListeners.Count - 1; i >= 0; i--)
        {
            eventListeners[i].OnEventRaised(value);
        }
    }

    public void RegisterListener(ShowPanelEventListener listener)
    {
        if (!eventListeners.Contains(listener))
        {
            eventListeners.Add(listener);
        }
    }

    public void UnregisterListener(ShowPanelEventListener listener)
    {
        if (eventListeners.Contains(listener))
        {
            eventListeners.Remove(listener);
        }
    }
}