using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendPanel : MonoBehaviour {
	private Canvas canvas;
	public RectTransform panelToDisplay;
	public FleetManager fleetManager;
	public PlanetSelector planetSelector;

	void Start()
	{
		canvas = GetComponent<Canvas>();
		canvas.enabled = false;
	}

	public void Show(Vector3 worldPosition) {
		// TODO: refactor
		Vector3 screenPosition = Camera.main.WorldToScreenPoint(worldPosition);
		Vector3 canvasPosition = RectTransformUtility.PixelAdjustPoint(new Vector2(screenPosition.x, screenPosition.y), panelToDisplay, canvas);
		panelToDisplay.position = canvasPosition;
		canvas.enabled = true;
	}

	public void Show(ShowPanelEventData data) {

	}

	public void ShowX(EventData data) {
		
	}

	public void OnFleetClicked() {
		fleetManager.SendFleet();
		OnDismiss();
	}

	public void OnHealthClicked() {
		OnDismiss();
	}

	public void OnDismiss() {
		canvas.enabled = false;
	}
}
