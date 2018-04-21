using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ShowPanelEvent))]
public class ShowPanelEventEditor : Editor
{
    private ShowPanelEventData eventData;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (eventData == null) {
            eventData = ScriptableObject.CreateInstance<ShowPanelEventData>();
        }

        // GUI.enabled = Application.isPlaying;

        Editor myEditor = Editor.CreateEditor(eventData);
        myEditor.OnInspectorGUI();

        // EditorGUILayout.ObjectField(eventData, typeof(ShowPanelEventData), false);
        //EditorGUILayout.ObjectField(eventData, typeof(ShowPanelEventData));

        ShowPanelEvent e = target as ShowPanelEvent;
        if (GUILayout.Button("Raise"))
        {
            e.Raise(eventData);
        }
    }
}