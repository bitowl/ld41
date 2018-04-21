using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ShowFleetTooltipEvent))]
public class ShowFleetTooltipEventEditor : Editor
{
    private ShowFleetTooltipEventData eventData;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (eventData == null) {
            eventData = ScriptableObject.CreateInstance<ShowFleetTooltipEventData>();
        }

        GUI.enabled = Application.isPlaying;

        Editor.CreateEditor(eventData).OnInspectorGUI();

        ShowFleetTooltipEvent e = target as ShowFleetTooltipEvent;
        if (GUILayout.Button("Raise"))
        {
            e.Raise(eventData);
        }
    }
}