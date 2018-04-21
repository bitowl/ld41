using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(FleetDataEvent))]
public class ShowPanelEventEditor : Editor
{
    private FleetDataEventData eventData;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (eventData == null) {
            eventData = ScriptableObject.CreateInstance<FleetDataEventData>();
        }

        GUI.enabled = Application.isPlaying;

        Editor.CreateEditor(eventData).OnInspectorGUI();

        FleetDataEvent e = target as FleetDataEvent;
        if (GUILayout.Button("Raise"))
        {
            e.Raise(eventData);
        }
    }
}