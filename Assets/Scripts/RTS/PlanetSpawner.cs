using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSpawner : MonoBehaviour
{
    public float minX = -10;
    public float maxX = 10;
    public float minY = -10;
    public float maxY = 10;
    public float planetCount = 10;
    public GameObject planetPrefab;
    public float minimumDistance = 5;

    private int maximumTriesPerPlanet = 100;
    private List<Planet> planets;

    // Use this for initialization
    void Start()
    {
        PlanetData initialPlanetData = ScriptableObject.CreateInstance<PlanetData>();
        initialPlanetData.belongsToYou = true;
        initialPlanetData.playerOnPlanet = true;
        GameObject initialPlanet = Instantiate(planetPrefab);
        initialPlanet.GetComponent<Planet>().data = initialPlanetData;
        initialPlanet.transform.SetParent(transform, false);
        planets = new List<Planet>();

        for (int i = 0; i < planetCount; i++)
        {
            PlanetData planetData = ScriptableObject.CreateInstance<PlanetData>();
            bool foundPlace = false;
            for (int j = 0; j < maximumTriesPerPlanet; j++)
            {
                planetData.position = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0);
                if (CanPlace(planetData))
                {
                    foundPlace = true;
                    break;
                }
            }
            if (!foundPlace)
            {
                continue; // BAAAD
            }


            Planet planet = Instantiate(planetPrefab).GetComponent<Planet>();
            planet.transform.SetParent(transform, false);
            planet.data = planetData;
            planets.Add(planet);
        }
    }

    public bool CanPlace(PlanetData data)
    {
        foreach (Planet planet in planets)
        {
            if (Vector3.Distance(planet.data.position, data.position) < minimumDistance)
            {
                return false;
            }
        }
        return true;
    }

    public void OnPlanetCaptured(PlanetEventData data)
    {
        Planet planet = data.planet;
        planet.data.belongsToYou = true;
        planet.UpdateMaterial();
    }

}
