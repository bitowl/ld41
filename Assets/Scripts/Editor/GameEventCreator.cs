using UnityEngine;
using UnityEditor;
using System.IO;

public class GameEventCreator {

    static string eventName = "ShowPanel";

    [MenuItem("Custom/Generate Event")]
    static void GenerateListener() {
        string eventCsTemplate = @"using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(menuName = ""Events/" +eventName+ @"Event"")]
public class " +eventName+ @"Event : ScriptableObject
{
    /// <summary>
    /// The list of listeners that this event will notify if it is raised.
    /// </summary>
    private readonly List<" +eventName+ @"EventListener> eventListeners =
        new List<" +eventName+ @"EventListener>();

    public void Raise(" +eventName+ @"EventData value)
    {
        for (int i = eventListeners.Count - 1; i >= 0; i--)
        {
            eventListeners[i].OnEventRaised(value);
        }
    }

    public void RegisterListener(" +eventName+ @"EventListener listener)
    {
        if (!eventListeners.Contains(listener))
        {
            eventListeners.Add(listener);
        }
    }

    public void UnregisterListener(" +eventName+ @"EventListener listener)
    {
        if (eventListeners.Contains(listener))
        {
            eventListeners.Remove(listener);
        }
    }
}";
        string eventListenerCsTemplate = @"using UnityEngine;
using UnityEngine.Events;

public class " +eventName+ @"EventListener : MonoBehaviour
{
    [Tooltip(""Event to register with."")]
    public " +eventName+ @"Event Event;

    [Tooltip(""Response to invoke when Event is raised."")]
    [SerializeField]
    public EventDataUnityEvent Response;

    private void OnEnable()
    {
        Event.RegisterListener(this);
    }

    private void OnDisable()
    {
        Event.UnregisterListener(this);
    }

    public void OnEventRaised(" +eventName+ @"EventData value)
    {
        Response.Invoke(value);
    }
}";
        string eventEditorCsTemplate = @"using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(" +eventName+ @"Event))]
public class " +eventName+ @"EventEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        GUI.enabled = Application.isPlaying;

        " +eventName+ @"Event e = target as " +eventName+ @"Event;
        if (GUILayout.Button(""Raise""))
        {
            e.Raise();
        }
    }
}";
        string eventDataCsTemplate = @"using UnityEngine;

[System.Serializable]
public class " +eventName+ @"EventData {
    Vector3 position;
    Planet from;
    Planet to;
}";

        WriteFile("Assets/Scripts/Events/Generated/" + eventName + "Event.cs", eventCsTemplate);
        WriteFile("Assets/Scripts/Events/Generated/" + eventName + "EventListener.cs", eventListenerCsTemplate);
        WriteFile("Assets/Scripts/Events/Generated/Editor" + eventName + "EventEditor.cs", eventEditorCsTemplate);
        WriteFile("Assets/Scripts/Events/" + eventName + "EventData.cs", eventDataCsTemplate);
    }

    static void WriteFile(string filename, string contents) {
        StreamWriter writer = new StreamWriter(filename, false);
        writer.Write(contents);
        writer.Close();
    }
}