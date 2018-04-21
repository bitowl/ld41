using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSelectorLogic : MonoBehaviour {
	public SelectedPlanetData selectedPlanetData;
    public FleetDataEvent showSendPanelEvent;
    public ShowFleetTooltipEvent fleetTooltipEvent;


    private ShowFleetTooltipEventData fleetTooltipEventData;
    private Camera mainCamera;

	void Start()
	{
        mainCamera = CameraUtils.GetRTSCamera();		
		fleetTooltipEventData = ScriptableObject.CreateInstance<ShowFleetTooltipEventData>();
	}

    public void OnMove(Vector3 mousePosition)
    {
        CalculateHoveringPlanet(mousePosition);

        if (Input.GetButtonDown("Fire1"))
        {
            selectedPlanetData.selectedPlanet = selectedPlanetData.hoveredPlanet;

        }

        if (Input.GetButton("Fire1") && selectedPlanetData.selectedPlanet != null && selectedPlanetData.hoveredPlanet != null)
        {
            selectedPlanetData.isArrowShown = true;
        }
        else
        {
            selectedPlanetData.isArrowShown = false;
        }

        if (Input.GetButtonUp("Fire1") && selectedPlanetData.selectedPlanet != null && selectedPlanetData.hoveredPlanet != null && selectedPlanetData.selectedPlanet != selectedPlanetData.hoveredPlanet)
        {
			FleetDataEventData data = ScriptableObject.CreateInstance<FleetDataEventData>();
			data.position = selectedPlanetData.hoveredPlanet.transform.position;
			data.from = selectedPlanetData.selectedPlanet;
			data.to = selectedPlanetData.hoveredPlanet;

            showSendPanelEvent.Raise(data);
        }


    }


    private void CalculateHoveringPlanet(Vector3 mousePosition)
    {
        Ray ray = mainCamera.ScreenPointToRay(mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.gameObject.tag == "Planet")
            {
                selectedPlanetData.hoveredPlanet = hit.transform.GetComponent<Planet>();
            }
            else
            {
                selectedPlanetData.hoveredPlanet = null;
            }

			if (hit.transform.gameObject.tag == "Fleet") 
			{
				Fleet newHoveredFleet = hit.transform.GetComponent<Fleet>();
				if (selectedPlanetData.hoveredFleet == null || selectedPlanetData.hoveredFleet != newHoveredFleet) {
					selectedPlanetData.hoveredFleet = newHoveredFleet;
					fleetTooltipEventData.hoveringFleet = true;
					fleetTooltipEventData.fleet = selectedPlanetData.hoveredFleet;
					fleetTooltipEvent.Raise(fleetTooltipEventData);
					Debug.Log("show"+fleetTooltipEventData);
				}
			}
			else
			{
				if (selectedPlanetData.hoveredFleet != null) {
					fleetTooltipEventData.hoveringFleet = false;
					fleetTooltipEvent.Raise(fleetTooltipEventData);
					Debug.Log("hide" +fleetTooltipEventData);
				}
				selectedPlanetData.hoveredFleet = null;
			}
        }
        else
        {
            selectedPlanetData.hoveredPlanet = null;
			if (selectedPlanetData.hoveredFleet != null) {
				fleetTooltipEventData.hoveringFleet = false;
				fleetTooltipEvent.Raise(fleetTooltipEventData);
				Debug.Log("hide" +fleetTooltipEventData);
			}
			selectedPlanetData.hoveredFleet = null;
        }
    }
}
