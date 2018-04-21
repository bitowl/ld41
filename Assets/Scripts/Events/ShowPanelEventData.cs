using UnityEngine;

[System.Serializable]
public class ShowPanelEventData : ScriptableObject {
    public Vector3 position;
    public Planet from;
    public Planet to;
}