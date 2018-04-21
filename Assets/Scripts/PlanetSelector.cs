using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSelector : MonoBehaviour
{
    public LineRenderer arrowLine;
    public GameObject hoveredPlanetIndicator;
    public GameObject selectedPlanetIndicator;
    public FleetManager fleetManager;
    public Vector3GameEvent showSendPanelEvent;

    private Camera mainCamera;
    private Planet hoveredPlanet;
    private Planet selectedPlanet;

    // Use this for initialization
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        CalculateHoveringPlanet();

        if (Input.GetButtonDown("Fire1"))
        {
            selectedPlanet = hoveredPlanet;
            if (selectedPlanet != null)
            {
                selectedPlanetIndicator.transform.position = selectedPlanet.transform.position;
            }
        }

        if (Input.GetButton("Fire1") && selectedPlanet != null && hoveredPlanet != null)
        {
            arrowLine.enabled = true;
            arrowLine.SetPosition(0, selectedPlanet.transform.position);
            arrowLine.SetPosition(1, hoveredPlanet.transform.position);
        }
        else
        {
            arrowLine.enabled = false;
        }

        if (Input.GetButtonUp("Fire1") && selectedPlanet != null && hoveredPlanet != null && selectedPlanet != hoveredPlanet)
        {

			fleetManager.PrepareFleet(selectedPlanet, hoveredPlanet);

            showSendPanelEvent.Raise(hoveredPlanet.transform.position);
            // fleetManager.SendFleet(selectedPlanet, hoveredPlanet);
        }

        hoveredPlanetIndicator.SetActive(hoveredPlanet != null);
        selectedPlanetIndicator.SetActive(selectedPlanet != null);
    }

    private void CalculateHoveringPlanet()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.gameObject.tag == "Planet")
            {
                hoveredPlanetIndicator.transform.position = hit.transform.position;
                hoveredPlanet = hit.transform.GetComponent<Planet>();
            }
            else
            {
                hoveredPlanet = null;
            }
        }
        else
        {
            hoveredPlanet = null;
        }
    }

}
