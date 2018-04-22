using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(WaveDataListEvent))]
public class WaveDataListEventEditor : Editor
{
    private WaveDataListEventData eventData;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (eventData == null) {
            eventData = ScriptableObject.CreateInstance<WaveDataListEventData>();
        }

        GUI.enabled = Application.isPlaying;

        Editor.CreateEditor(eventData).OnInspectorGUI();

        WaveDataListEvent e = target as WaveDataListEvent;
        if (GUILayout.Button("Raise"))
        {
            e.Raise(eventData);
        }
    }
}