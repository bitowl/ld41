using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PlanetEvent))]
public class PlanetEventEditor : Editor
{
    private PlanetEventData eventData;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (eventData == null) {
            eventData = ScriptableObject.CreateInstance<PlanetEventData>();
        }

        GUI.enabled = Application.isPlaying;

        Editor.CreateEditor(eventData).OnInspectorGUI();

        PlanetEvent e = target as PlanetEvent;
        if (GUILayout.Button("Raise"))
        {
            e.Raise(eventData);
        }
    }
}