using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSelector : MonoBehaviour
{
    public LineRenderer arrowLine;
    public GameObject hoveredPlanetIndicator;
    public GameObject selectedPlanetIndicator;
    public FleetManager fleetManager;
    public ShowPanelEvent showSendPanelEvent;
	public ShowFleetTooltipEvent fleetTooltipEvent;

    private Camera mainCamera;
    private Planet hoveredPlanet;
    private Planet selectedPlanet;
	private Fleet hoveredFleet;
	private ShowFleetTooltipEventData fleetTooltipEventData;

    // Use this for initialization
    void Start()
    {
        mainCamera = Camera.main;
		fleetTooltipEventData = ScriptableObject.CreateInstance<ShowFleetTooltipEventData>();
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
			ShowPanelEventData data = ScriptableObject.CreateInstance<ShowPanelEventData>();
			data.position = hoveredPlanet.transform.position;
			data.from = selectedPlanet;
			data.to = hoveredPlanet;

            showSendPanelEvent.Raise(data);
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

			if (hit.transform.gameObject.tag == "Fleet") 
			{
				Fleet newHoveredFleet = hit.transform.GetComponent<Fleet>();
				if (hoveredFleet == null || hoveredFleet != newHoveredFleet) {
					hoveredFleet = newHoveredFleet;
					fleetTooltipEventData.hoveringFleet = true;
					fleetTooltipEventData.fleet = hoveredFleet;
					fleetTooltipEvent.Raise(fleetTooltipEventData);
					Debug.Log("show"+fleetTooltipEventData);
				}
			}
			else
			{
				if (hoveredFleet != null) {
					fleetTooltipEventData.hoveringFleet = false;
					fleetTooltipEvent.Raise(fleetTooltipEventData);
					Debug.Log("hide" +fleetTooltipEventData);
				}
				hoveredFleet = null;
			}
        }
        else
        {
            hoveredPlanet = null;
			if (hoveredFleet != null) {
				fleetTooltipEventData.hoveringFleet = false;
				fleetTooltipEvent.Raise(fleetTooltipEventData);
				Debug.Log("hide" +fleetTooltipEventData);
			}
			hoveredFleet = null;
        }
    }

}
