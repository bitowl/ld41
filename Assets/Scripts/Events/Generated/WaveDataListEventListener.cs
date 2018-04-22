using UnityEngine;
using UnityEngine.Events;

public class WaveDataListEventListener : MonoBehaviour
{
    [Tooltip("Event to register with.")]
    public WaveDataListEvent Event;

    [Tooltip("Response to invoke when Event is raised.")]
    [SerializeField]
    public WaveDataListUnityEvent Response;

    private void OnEnable()
    {
        Event.RegisterListener(this);
    }

    private void OnDisable()
    {
        Event.UnregisterListener(this);
    }

    public void OnEventRaised(WaveDataListEventData value)
    {
        Response.Invoke(value);
    }
}