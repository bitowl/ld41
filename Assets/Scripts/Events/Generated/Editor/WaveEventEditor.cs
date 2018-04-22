using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(WaveEvent))]
public class WaveEventEditor : Editor
{
    private WaveEventData eventData;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (eventData == null) {
            eventData = ScriptableObject.CreateInstance<WaveEventData>();
        }

        GUI.enabled = Application.isPlaying;

        Editor.CreateEditor(eventData).OnInspectorGUI();

        WaveEvent e = target as WaveEvent;
        if (GUILayout.Button("Raise"))
        {
            e.Raise(eventData);
        }
    }
}