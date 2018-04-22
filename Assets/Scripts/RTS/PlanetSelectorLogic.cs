using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSelectorLogic : MonoBehaviour
{
    public SelectedPlanetData selectedPlanetData;
    public FleetDataEvent showSendPanelEvent;
    public ShowFleetTooltipEvent fleetTooltipEvent;
    public float scrollSpeed = 0.1f;
    public float minCameraX = -10;
    public float minCameraY = -10;
    public float maxCameraX = 10;
    public float maxCameraY = 10;

    private ShowFleetTooltipEventData fleetTooltipEventData;
    private Camera mainCamera;
    private Vector3 scrollOffset;
    private Vector3 cameraPos;

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


        // Scroll RTS pane
        if (Input.GetButtonDown("RightClick")) {
            scrollOffset = Input.mousePosition;
            cameraPos = mainCamera.transform.localPosition;
        }
        if (Input.GetButton("RightClick")) {
            Vector3 newPos = cameraPos + (scrollOffset - Input.mousePosition) * scrollSpeed;
            if (newPos.x > maxCameraX) { newPos.x = maxCameraX;}
            if (newPos.y > maxCameraY) { newPos.y = maxCameraY;}
            if (newPos.x < minCameraX) { newPos.x = minCameraX;}
            if (newPos.y < minCameraY) { newPos.y = minCameraY;}
            mainCamera.transform.localPosition = newPos;
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
