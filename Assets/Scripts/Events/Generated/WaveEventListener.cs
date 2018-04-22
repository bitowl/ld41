using UnityEngine;
using UnityEngine.Events;

public class WaveEventListener : MonoBehaviour
{
    [Tooltip("Event to register with.")]
    public WaveEvent Event;

    [Tooltip("Response to invoke when Event is raised.")]
    [SerializeField]
    public WaveUnityEvent Response;

    private void OnEnable()
    {
        Event.RegisterListener(this);
    }

    private void OnDisable()
    {
        Event.UnregisterListener(this);
    }

    public void OnEventRaised(WaveEventData value)
    {
        Response.Invoke(value);
    }
}