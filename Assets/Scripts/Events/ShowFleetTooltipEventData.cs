using UnityEngine;

[System.Serializable]
public class ShowFleetTooltipEventData : ScriptableObject {
    public bool hoveringFleet;
    public Fleet fleet;
}