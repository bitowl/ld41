using UnityEngine;
using UnityEngine.Events;

public class EventDataGameEventListener : MonoBehaviour
{
    [Tooltip("Event to register with.")]
    public EventDataGameEvent Event;

    [Tooltip("Response to invoke when Event is raised.")]
    [SerializeField]
    public EventDataUnityEvent Response;

    private void OnEnable()
    {
        Event.RegisterListener(this);
    }

    private void OnDisable()
    {
        Event.UnregisterListener(this);
    }

    public void OnEventRaised(EventData value)
    {
        Response.Invoke(value);
    }
}