using UnityEngine;
using UnityEngine.Events;

public class EnemyEventListener : MonoBehaviour
{
    [Tooltip("Event to register with.")]
    public EnemyEvent Event;

    [Tooltip("Response to invoke when Event is raised.")]
    [SerializeField]
    public EnemyUnityEvent Response;

    private void OnEnable()
    {
        Event.RegisterListener(this);
    }

    private void OnDisable()
    {
        Event.UnregisterListener(this);
    }

    public void OnEventRaised(EnemyEventData value)
    {
        Response.Invoke(value);
    }
}