using UnityEngine;

public class CameraUtils
{
    public static Camera GetRTSCamera()
    {
        return GameObject.Find("RTSCamera(Clone)").GetComponent<Camera>();
    }

    public static Camera GetShmupCamera()
    {
        return GameObject.Find("ShmupCamera(Clone)").GetComponent<Camera>();
    }
}