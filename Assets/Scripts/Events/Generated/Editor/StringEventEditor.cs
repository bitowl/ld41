using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(StringEvent))]
public class StringEventEditor : Editor
{
    private string eventData = "";

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();


        GUI.enabled = Application.isPlaying;

        eventData = EditorGUILayout.TextField(eventData);

        StringEvent e = target as StringEvent;
        if (GUILayout.Button("Raise"))
        {
            e.Raise(eventData);
        }
    }
}