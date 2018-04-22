using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTSDrawerToggle : MonoBehaviour
{
    public RTSDrawer drawer;
    public Animator arrow;

    private bool drawerVisible;
	private bool playerStandsOnPlanet;

    void Start()
    {
		playerStandsOnPlanet = true;
		UpdateArrow();
    }

    public void Toggle()
    {
        drawerVisible = !drawerVisible;
        drawer.SetVisible(drawerVisible);
		UpdateArrow();
    }

    public void OnFleetSend(FleetDataEventData data)
    {
        if (data.playerInFleet)
        {
            playerStandsOnPlanet = false;
			UpdateArrow();
        }
    }

    public void OnFleetDestroyed(FleetEventData data)
    {
        if (data.fleet.playerInFleet)
        {
            playerStandsOnPlanet = true;
			UpdateArrow();
        }
    }

	void UpdateArrow() {
        arrow.SetBool("ArrowVisible", playerStandsOnPlanet && !drawerVisible);
	}
}
