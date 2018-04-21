

using UnityEngine;

public class UIUtility {
    public static void SetPanelToWorldCoordinates(Vector3 worldPosition, Camera camera, Canvas canvas, RectTransform panelToDisplay)
    {
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(worldPosition);
		Vector3 canvasPosition = RectTransformUtility.PixelAdjustPoint(new Vector2(screenPosition.x, screenPosition.y), panelToDisplay, canvas);
		panelToDisplay.position = canvasPosition;
    }
}