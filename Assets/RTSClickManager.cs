using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// https://forum.unity.com/threads/eventtrigger-move-issue.325103/#post-2950779
public class RTSClickManager : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public RectTransform imageTransform;
    public PlanetSelectorLogic planetSelectorLogic;

    public static Vector3 toAdd;

    // Called when the pointer enters our GUI component.
    // Start tracking the mouse
    public void OnPointerEnter(PointerEventData eventData)
    {
        StartCoroutine("TrackPointer");
    }

    // Called when the pointer exits our GUI component.
    // Stop tracking the mouse
    public void OnPointerExit(PointerEventData eventData)
    {
        StopCoroutine("TrackPointer");
    }

    IEnumerator TrackPointer()
    {
        while (Application.isPlaying)
        {
            toAdd = -imageTransform.position - new Vector3(imageTransform.rect.position.x, imageTransform.rect.position.y, 0);
            Vector3 mousePosition = Input.mousePosition + toAdd;
            planetSelectorLogic.OnMove(mousePosition);

            yield return 0;
        }
    }


}