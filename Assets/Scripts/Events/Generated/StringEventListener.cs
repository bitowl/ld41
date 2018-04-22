using UnityEngine;
using UnityEngine.Events;

public class StringEventListener : MonoBehaviour
{
    [Tooltip("Event to register with.")]
    public StringEvent Event;

    [Tooltip("Response to invoke when Event is raised.")]
    [SerializeField]
    public StringUnityEvent Response;

    private void OnEnable()
    {
        Event.RegisterListener(this);
    }

    private void OnDisable()
    {
        Event.UnregisterListener(this);
    }

    public void OnEventRaised(string value)
    {
        Response.Invoke(value);
    }
}