using UnityEngine;
using UnityEngine.Events;

public class FleetDataEventListener : MonoBehaviour
{
    [Tooltip("Event to register with.")]
    public FleetDataEvent Event;

    [Tooltip("Response to invoke when Event is raised.")]
    [SerializeField]
    public FleetDataUnityEvent Response;

    private void OnEnable()
    {
        Event.RegisterListener(this);
    }

    private void OnDisable()
    {
        Event.UnregisterListener(this);
    }

    public void OnEventRaised(FleetDataEventData value)
    {
        Response.Invoke(value);
    }
}