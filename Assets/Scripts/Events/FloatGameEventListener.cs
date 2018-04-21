using UnityEngine;
using UnityEngine.Events;

public class FloatGameEventListener : MonoBehaviour
{
    [Tooltip("Event to register with.")]
    public FloatGameEvent Event;

    [Tooltip("Response to invoke when Event is raised.")]
    [SerializeField]
    public FloatUnityEvent Response;

    private void OnEnable()
    {
        Event.RegisterListener(this);
    }

    private void OnDisable()
    {
        Event.UnregisterListener(this);
    }

    public void OnEventRaised(float value)
    {
        Response.Invoke(value);
    }
}