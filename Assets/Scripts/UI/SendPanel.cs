using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendPanel : MonoBehaviour {
	public RectTransform innerPanel;
	public RectTransform panel;
	public ShowPanelEvent sendFleedEvent;

	private ShowPanelEventData data;
	private Camera mainCamera;

	void Start()
	{
		panel.gameObject.SetActive(false);
		mainCamera = Camera.main;
	}

	public void Show(ShowPanelEventData data) {
		this.data = data;
		UIUtility.SetPanelToWorldCoordinates(data.position, mainCamera, innerPanel);
		panel.gameObject.SetActive(true);
	}

	public void OnFleetClicked() {
		sendFleedEvent.Raise(data);
		// fleetManager.SendFleet(data.from, data.to);
		OnDismiss();
	}

	public void OnHealthClicked() {
		OnDismiss();
	}

	public void OnDismiss() {
		panel.gameObject.SetActive(false);
	}
}
