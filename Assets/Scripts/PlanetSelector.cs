using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSelector : MonoBehaviour {
	public LineRenderer arrowLine;
	public GameObject hoveredPlanetIndicator;
	public GameObject selectedPlanetIndicator;
	private Camera mainCamera;
	private Planet hoveredPlanet;
	private Planet selectedPlanet;

	// Use this for initialization
	void Start () {
		mainCamera = Camera.main;
	}
	
	// Update is called once per frame
	void Update ()
    {
        GetHoveringPlanet();

		if (Input.GetButtonDown("Fire1")) {
			selectedPlanet = hoveredPlanet;
			if (selectedPlanet != null) {
				selectedPlanetIndicator.transform.position = selectedPlanet.transform.position;
			}
		}

		if (Input.GetButton("Fire1") && selectedPlanet != null && hoveredPlanet != null) {
			arrowLine.enabled = true;
			arrowLine.SetPosition(0, selectedPlanet.transform.position);
			arrowLine.SetPosition(1, hoveredPlanet.transform.position);
		} else {
			arrowLine.enabled = false;
		}

		hoveredPlanetIndicator.SetActive(hoveredPlanet != null);
		selectedPlanetIndicator.SetActive(selectedPlanet != null);
    }

    private void GetHoveringPlanet()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.gameObject.tag == "Planet")
            {
                hoveredPlanetIndicator.transform.position = hit.transform.position;
                hoveredPlanet = hit.transform.GetComponent<Planet>();
            }
            else
            {
                hoveredPlanet = null;
            }
        }
        else
        {
            hoveredPlanet = null;
        }
    }
}
