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

        GUI.enabled = Application.isPlaying;

        Editor.CreateEditor(eventData).OnInspectorGUI();

        ShowPanelEvent e = target as ShowPanelEvent;
        if (GUILayout.Button("Raise"))
        {
            e.Raise(eventData);
        }
    }
}