

using UnityEngine;

public class UIUtility {
    public static void SetPanelToWorldCoordinates(Vector3 worldPosition, Camera camera, RectTransform panelToDisplay)
    {
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(worldPosition);
		Vector3 canvasPosition = RectTransformUtility.PixelAdjustPoint(new Vector2(screenPosition.x, screenPosition.y), panelToDisplay, panelToDisplay.GetComponentInParent<Canvas>());
		panelToDisplay.position = canvasPosition;
    }
}