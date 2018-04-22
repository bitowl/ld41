using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RTSGameManager))]
public class FleetManager : MonoBehaviour
{
    private RTSGameManager gameManager;
    public GameObject fleetPrefab;

    void Start()
    {
        gameManager = GetComponent<RTSGameManager>();
    }

    public void SendFleet(Planet from, Planet to)
    {
        Fleet fleet = Instantiate(fleetPrefab).GetComponent<Fleet>();
        if (from.data.playerOnPlanet)
        {
            // The player embarks first
            from.data.playerOnPlanet = false;
            fleet.playerInFleet = true;
            from.UpdateMaterial();
            gameManager.playerFleet = fleet;
            gameManager.StartRound(Vector3.Distance(from.data.position, to.data.position));

        }
        fleet.startPosition = from.transform.position;
        fleet.endPosition = to.transform.position;
        fleet.targetPlanet = to;
        gameManager.fleets.Add(fleet);
    }

    public void SendFleet(FleetDataEventData data)
    {
        SendFleet(data.from, data.to);
    }
}
