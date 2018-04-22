using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(FleetEvent))]
public class FleetEventEditor : Editor
{
    private FleetEventData eventData;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (eventData == null) {
            eventData = ScriptableObject.CreateInstance<FleetEventData>();
        }

        GUI.enabled = Application.isPlaying;

        Editor.CreateEditor(eventData).OnInspectorGUI();

        FleetEvent e = target as FleetEvent;
        if (GUILayout.Button("Raise"))
        {
            e.Raise(eventData);
        }
    }
}