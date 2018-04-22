using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(EnemyEvent))]
public class EnemyEventEditor : Editor
{
    private EnemyEventData eventData;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (eventData == null) {
            eventData = ScriptableObject.CreateInstance<EnemyEventData>();
        }

        GUI.enabled = Application.isPlaying;

        Editor.CreateEditor(eventData).OnInspectorGUI();

        EnemyEvent e = target as EnemyEvent;
        if (GUILayout.Button("Raise"))
        {
            e.Raise(eventData);
        }
    }
}