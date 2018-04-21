using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleetTooltip : MonoBehaviour {

	public RectTransform tooltipPanel;

	public Canvas canvas;
	private Camera mainCamera;
	// Use this for initialization
	void Start () {
		tooltipPanel.gameObject.SetActive(false);
		mainCamera = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnFleetTooltipChange(ShowFleetTooltipEventData data) {
		tooltipPanel.gameObject.SetActive(data.hoveringFleet);
		if (data.hoveringFleet) {
			UIUtility.SetPanelToWorldCoordinates(data.fleet.transform.position, mainCamera, canvas, tooltipPanel);
		}
		// TODO: fill data 
	}	
}
