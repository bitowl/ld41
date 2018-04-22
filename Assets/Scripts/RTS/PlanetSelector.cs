using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSelector : MonoBehaviour
{
    public SelectedPlanetData selectedPlanetData;
    public LineRenderer arrowLine;
    public GameObject hoveredPlanetIndicator;
    public GameObject selectedPlanetIndicator;

    // Use this for initialization
    void Start()
    {

    }

    void Update()
    {
        if (selectedPlanetData.selectedPlanet != null)
        {
            selectedPlanetIndicator.transform.position = selectedPlanetData.selectedPlanet.transform.position;
        }
        if (selectedPlanetData.hoveredPlanet != null)
        {
            hoveredPlanetIndicator.transform.position = selectedPlanetData.hoveredPlanet.transform.position;
        }

        arrowLine.enabled = selectedPlanetData.isArrowShown;
        if (selectedPlanetData.isArrowShown)
        {
            arrowLine.SetPosition(0, selectedPlanetData.selectedPlanet.transform.position);
            arrowLine.SetPosition(1, selectedPlanetData.hoveredPlanet.transform.position);
        }

        hoveredPlanetIndicator.SetActive(selectedPlanetData.hoveredPlanet != null);
        selectedPlanetIndicator.SetActive(selectedPlanetData.selectedPlanet != null);
    }

}
