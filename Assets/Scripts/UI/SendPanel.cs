using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendPanel : MonoBehaviour {
	public RectTransform innerPanel;
	public RectTransform panel;
	public FleetManager fleetManager;
	public PlanetSelector planetSelector;

	public Canvas canvas;
	private ShowPanelEventData data;
	private Camera mainCamera;

	void Start()
	{
		panel.gameObject.SetActive(false);
		mainCamera = Camera.main;
	}

	public void Show(ShowPanelEventData data) {
		this.data = data;
		UIUtility.SetPanelToWorldCoordinates(data.position, mainCamera, canvas, innerPanel);
		panel.gameObject.SetActive(true);
	}

	public void OnFleetClicked() {
		fleetManager.SendFleet(data.from, data.to);
		OnDismiss();
	}

	public void OnHealthClicked() {
		OnDismiss();
	}

	public void OnDismiss() {
		panel.gameObject.SetActive(false);
	}
}
