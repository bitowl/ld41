using UnityEngine;
using UnityEngine.Events;

public class Vector3GameEventListener : MonoBehaviour
{
    [Tooltip("Event to register with.")]
    public Vector3GameEvent Event;

    [Tooltip("Response to invoke when Event is raised.")]
    [SerializeField]
    public Vector3UnityEvent Response;

    private void OnEnable()
    {
        Event.RegisterListener(this);
    }

    private void OnDisable()
    {
        Event.UnregisterListener(this);
    }

    public void OnEventRaised(Vector3 value)
    {
        Response.Invoke(value);
    }
}