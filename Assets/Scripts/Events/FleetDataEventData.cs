using UnityEngine;

[System.Serializable]
public class FleetDataEventData : ScriptableObject {
    public Vector3 position;
    public Planet from;
    public Planet to;
}