using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSpawner : MonoBehaviour
{
    public float minX = -20;
    public float maxX = 20;
    public float minY = -40;
    public float maxY = 40;
    public float planetCount = 20;
    public GameObject planetPrefab;
    public float minimumDistance = 5;
    public GameEvent gameWonEvent;

    private int maximumTriesPerPlanet = 100;
    private List<Planet> planets;

    // Use this for initialization
    void Start()
    {
        PlanetData initialPlanetData = ScriptableObject.CreateInstance<PlanetData>();
        initialPlanetData.belongsToYou = true;
        initialPlanetData.playerOnPlanet = true;
        Planet initialPlanet = Instantiate(planetPrefab).GetComponent<Planet>();
        initialPlanet.data = initialPlanetData;
        initialPlanet.transform.SetParent(transform, false);
        planets = new List<Planet>();
        planets.Add(initialPlanet);

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
            float scale = Random.Range(0.8f, 1.2f);
            planet.transform.localScale = new Vector3(scale, scale, scale);
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
        TestForWinCondition();
    }

    void TestForWinCondition()
    {
        foreach (Planet planet in planets) 
        {
            if (!planet.data.belongsToYou) {
                return;
            }
        }

        // WE CONQUERED THE UNIVERSE
        gameWonEvent.Raise();
    }

}
