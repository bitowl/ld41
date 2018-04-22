using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fleet : MonoBehaviour
{
    public Vector3 startPosition;
    public Vector3 endPosition;
    public Planet targetPlanet;
    public float progress = 0.0f;
    public float velocity = 2;
    public PlanetEvent capturePlanetEvent;
    public bool playerInFleet;
    public GameObject playerInGameObjectIndicator;
    public FleetEvent fleedDestroyedEvent;
    public float displayedProgress;
    [ReadOnly] public float minTravelTime;
    public GameObject fleetRepresentation;

    // Use this for initialization
    void Start()
    {
        transform.position = CalculateTargetPosition();
        playerInGameObjectIndicator.SetActive(playerInFleet);
        minTravelTime = Vector3.Distance(startPosition, endPosition) / 2;
        // Rotate the fleet
        float angle = Mathf.Rad2Deg * Mathf.Atan2(-(endPosition - startPosition).x, (endPosition - startPosition).y);
        fleetRepresentation.transform.rotation = Quaternion.Euler(0, 0, angle);//Quaternion.LookRotation(end-start, Vector3.up);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = CalculateTargetPosition();
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * velocity);


        if (progress >= 1 && Vector3.Distance(transform.position, endPosition) <= targetPlanet.radius + 0.1)
        {
            ReachedGoal();
        }
    }

    private Vector3 CalculateTargetPosition()
    {
        Vector3 dir = (endPosition - startPosition);

        float wholeLength = dir.magnitude;
        float lengthWithoutPlanets = dir.magnitude - targetPlanet.radius * 2; // TODO: Fix here if planets have different radius
        float factor = (progress * lengthWithoutPlanets + targetPlanet.radius) / wholeLength;
        Vector3 targetPosition = startPosition + factor * dir;
        return targetPosition;
    }

    void ReachedGoal()
    {
        if (playerInFleet)
        {
            targetPlanet.data.playerOnPlanet = true;
        }

        PlanetEventData data = ScriptableObject.CreateInstance<PlanetEventData>();
        data.planet = targetPlanet;
        capturePlanetEvent.Raise(data);
        FleetEventData fdata = ScriptableObject.CreateInstance<FleetEventData>();
        fdata.fleet = this;
        fleedDestroyedEvent.Raise(fdata);

        Destroy(gameObject);
    }
}
