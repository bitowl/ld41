using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSelectorLogic : MonoBehaviour
{
    public SelectedPlanetData selectedPlanetData;
    public FleetDataEvent showSendPanelEvent;
    public ShowFleetTooltipEvent fleetTooltipEvent;


    private ShowFleetTooltipEventData fleetTooltipEventData;
    private Camera mainCamera;

    void Start()
    {

        fleetTooltipEventData = ScriptableObject.CreateInstance<ShowFleetTooltipEventData>();
    }

    public void OnMove(Vector3 mousePosition)
    {
        if (mainCamera == null)
        {
            mainCamera = CameraUtils.GetRTSCamera();
        }
        CalculateHoveringPlanet(mousePosition);

        if (Input.GetButtonDown("Click"))
        {
            if (selectedPlanetData.hoveredPlanet != null && selectedPlanetData.hoveredPlanet.data.belongsToYou)
            { // You should only be able to select planets that you own
              // selecting a planet => can send fleets (no further tests there)
                selectedPlanetData.selectedPlanet = selectedPlanetData.hoveredPlanet;
            }
            else
            {
                selectedPlanetData.selectedPlanet = null;
            }
        }

        if (Input.GetButton("Click") && selectedPlanetData.selectedPlanet != null && selectedPlanetData.hoveredPlanet != null)
        {
            selectedPlanetData.isArrowShown = true;
        }
        else
        {
            selectedPlanetData.isArrowShown = false;
        }

        if (Input.GetButtonUp("Click") && selectedPlanetData.selectedPlanet != null && selectedPlanetData.hoveredPlanet != null && selectedPlanetData.selectedPlanet != selectedPlanetData.hoveredPlanet)
        {
            FleetDataEventData data = ScriptableObject.CreateInstance<FleetDataEventData>();
            data.position = selectedPlanetData.hoveredPlanet.transform.position;
            data.from = selectedPlanetData.selectedPlanet;
            data.to = selectedPlanetData.hoveredPlanet;
            data.playerInFleet = data.from.data.playerOnPlanet;

            showSendPanelEvent.Raise(data);
        }

        if (Input.GetButtonUp("Click"))
        {
            selectedPlanetData.selectedPlanet = null;
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

            /*if (hit.transform.gameObject.tag == "Fleet") 
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
			}*/
        }
        else
        {
            selectedPlanetData.hoveredPlanet = null;
            if (selectedPlanetData.hoveredFleet != null)
            {
                fleetTooltipEventData.hoveringFleet = false;
                fleetTooltipEvent.Raise(fleetTooltipEventData);
                Debug.Log("hide" + fleetTooltipEventData);
            }
            selectedPlanetData.hoveredFleet = null;
        }
    }
}
