

using UnityEngine;

public class UIUtility
{
    public static void SetPanelToWorldCoordinates(Vector3 worldPosition, Camera camera, RectTransform panelToDisplay)
    {
        Vector3 screenPosition = CameraUtils.GetRTSCamera().WorldToScreenPoint(worldPosition);
        screenPosition = screenPosition - RTSClickManager.toAdd;

        Vector3 canvasPosition = RectTransformUtility.PixelAdjustPoint(new Vector2(screenPosition.x, screenPosition.y), panelToDisplay, panelToDisplay.GetComponentInParent<Canvas>());
        panelToDisplay.position = canvasPosition;
    }
}