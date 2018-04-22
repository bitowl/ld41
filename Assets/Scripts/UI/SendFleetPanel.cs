using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendFleetPanel : MonoBehaviour
{
    public RectTransform innerPanel;
    public RectTransform panel;
    public FleetDataEvent sendFleedEvent;
    public FloatVariable cash;
    public FloatVariable fleetCost;

    private FleetDataEventData data;
    private Camera mainCamera;

    void Start()
    {
        panel.gameObject.SetActive(false);
        mainCamera = Camera.main;
    }

    public void Show(FleetDataEventData data)
    {
        this.data = data;
        UIUtility.SetPanelToWorldCoordinates(data.position, mainCamera, innerPanel);
        panel.gameObject.SetActive(true);
    }

    public void OnFleetClicked()
    {
        if (data.from.data.playerOnPlanet)
        {
            // Sending ourselfes is free
            sendFleedEvent.Raise(data);
        }
        else if (cash.value >= fleetCost.value)
        {
            // YEA BUY
            cash.value -= fleetCost.value;
            sendFleedEvent.Raise(data);
        }
        else
        {
            Debug.LogWarning("NOT ENOUGH MONEY");
        }

        // fleetManager.SendFleet(data.from, data.to);
        OnDismiss();
    }

    public void OnHealthClicked()
    {
        OnDismiss();
    }

    public void OnDismiss()
    {
        panel.gameObject.SetActive(false);
    }
}
