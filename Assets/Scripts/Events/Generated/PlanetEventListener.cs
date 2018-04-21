using UnityEngine;
using UnityEngine.Events;

public class PlanetEventListener : MonoBehaviour
{
    [Tooltip("Event to register with.")]
    public PlanetEvent Event;

    [Tooltip("Response to invoke when Event is raised.")]
    [SerializeField]
    public PlanetUnityEvent Response;

    private void OnEnable()
    {
        Event.RegisterListener(this);
    }

    private void OnDisable()
    {
        Event.UnregisterListener(this);
    }

    public void OnEventRaised(PlanetEventData value)
    {
        Response.Invoke(value);
    }
}