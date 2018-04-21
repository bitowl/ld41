using UnityEngine;
using UnityEngine.Events;

public class ShowPanelEventListener : MonoBehaviour
{
    [Tooltip("Event to register with.")]
    public ShowPanelEvent Event;

    [Tooltip("Response to invoke when Event is raised.")]
    [SerializeField]
    public ShowPanelUnityEvent Response;

    private void OnEnable()
    {
        Event.RegisterListener(this);
    }

    private void OnDisable()
    {
        Event.UnregisterListener(this);
    }

    public void OnEventRaised(ShowPanelEventData value)
    {
        Response.Invoke(value);
    }
}