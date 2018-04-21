using UnityEngine;
using UnityEngine.Events;

public class ShowFleetTooltipEventListener : MonoBehaviour
{
    [Tooltip("Event to register with.")]
    public ShowFleetTooltipEvent Event;

    [Tooltip("Response to invoke when Event is raised.")]
    [SerializeField]
    public ShowFleetTooltipUnityEvent Response;

    private void OnEnable()
    {
        Event.RegisterListener(this);
    }

    private void OnDisable()
    {
        Event.UnregisterListener(this);
    }

    public void OnEventRaised(ShowFleetTooltipEventData value)
    {
        Response.Invoke(value);
    }
}