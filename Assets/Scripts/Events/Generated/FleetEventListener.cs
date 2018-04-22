using UnityEngine;
using UnityEngine.Events;

public class FleetEventListener : MonoBehaviour
{
    [Tooltip("Event to register with.")]
    public FleetEvent Event;

    [Tooltip("Response to invoke when Event is raised.")]
    [SerializeField]
    public FleetUnityEvent Response;

    private void OnEnable()
    {
        Event.RegisterListener(this);
    }

    private void OnDisable()
    {
        Event.UnregisterListener(this);
    }

    public void OnEventRaised(FleetEventData value)
    {
        Response.Invoke(value);
    }
}