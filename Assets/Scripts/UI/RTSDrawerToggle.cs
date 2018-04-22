using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTSDrawerToggle : MonoBehaviour
{
    public RTSDrawer drawer;
	public GameObject arrow;

    private bool drawerVisible;


    public void Toggle()
    {
        drawerVisible = !drawerVisible;
        drawer.SetVisible(drawerVisible);
    }

	public void OnFleetSend(FleetDataEventData data) {
		if (data.playerInFleet) {
			arrow.SetActive(false);
		}
	}

	public void OnFleetDestroyed(FleetEventData data) {
		if (data.fleet.playerInFleet) {
			arrow.SetActive(true);
		}
	}
}
