using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// https://forum.unity.com/threads/eventtrigger-move-issue.325103/#post-2950779
public class RTSClickManager: MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
   
    public RectTransform imageTransform;
	public PlanetSelectorLogic planetSelectorLogic;

	public static Vector3 toAdd;

    // Called when the pointer enters our GUI component.
    // Start tracking the mouse
    public void OnPointerEnter( PointerEventData eventData ) {
        StartCoroutine("TrackPointer");
    }
   
    // Called when the pointer exits our GUI component.
    // Stop tracking the mouse
    public void OnPointerExit( PointerEventData eventData ) {
        StopCoroutine("TrackPointer");
    }
   
    IEnumerator TrackPointer() {
		
        //Vector3 mousePos = Vector3.zero;
        while (Application.isPlaying) {
			toAdd = -imageTransform.position - new Vector3(imageTransform.rect.position.x, imageTransform.rect.position.y, 0);
            //if (Input.mousePosition != mousePos) {
				Debug.Log("asdf" + Input.mousePosition + ": " + imageTransform.position + ", " + imageTransform.rect);
				Vector3 mousePosition = Input.mousePosition + toAdd;
				Debug.Log("Asdf: " + mousePosition);
				//mousePosition = new Vector3(mousePosition.x / imageTransform.rect.size.x * Screen.width,
				//    mousePosition.y / imageTransform.rect.size.y * Screen.height, 0);
				Debug.Log("Asdf: " + mousePosition);
				planetSelectorLogic.OnMove(mousePosition);
                // if (onMouseMove != null) onMouseMove.Invoke();
                //mousePos = Input.mousePosition;
            //}
            yield return 0;
        }
    }

 
}