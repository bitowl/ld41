﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public PlanetData data;
    public MeshRenderer planetRenderer;
    public Material enemyPlanetMaterial;
    public Material ownPlanetMaterial;

    // Use this for initialization
    void Start()
    {
        transform.position = data.position;

        UpdateMaterial();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateMaterial()
    {
        if (data.belongsToYou)
        {
            planetRenderer.material = ownPlanetMaterial;
        }
        else
        {
            planetRenderer.material = enemyPlanetMaterial;
        }
    }
}
