using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Custom/Selected Planet, etc")]
public class SelectedPlanetData : ScriptableObject
{
    public Planet hoveredPlanet;
    public Planet selectedPlanet;
    public Fleet hoveredFleet;
    public bool isArrowShown;
}
