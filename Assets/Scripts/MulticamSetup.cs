using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MulticamSetup : MonoBehaviour
{
    [ReadOnly]
    [Tooltip("Searches for \"ShmupCamera\" in all loaded scenes")]
    public Camera shmupCamera;
    [ReadOnly]
    [Tooltip("Searches for \"RTSCamera\" in all loaded scenes")]
    public Camera rtsCamera;
    public RawImage shmupImage;
    public RawImage rtsImage;
    private int screenWidth;
    private int screenHeight;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (screenWidth != Screen.width || screenHeight != Screen.height)
        {
            HandleResize();
        }
    }

    void HandleResize()
    {
        Debug.Log("Handle resize " + Screen.width + "/" +Screen.height);
        screenWidth = Screen.width;
        screenHeight = Screen.height;

        shmupCamera = CameraUtils.GetShmupCamera();
        rtsCamera = CameraUtils.GetRTSCamera();

        RenderTexture shmupTexture = new RenderTexture(Screen.width, Screen.height, 24);
        RenderTexture rtsTexture = new RenderTexture(Screen.width / 2, Screen.height, 24);
        shmupCamera.targetTexture = shmupTexture;
        shmupImage.texture = shmupTexture;
        rtsCamera.targetTexture = rtsTexture;
        rtsImage.texture = rtsTexture;
    }

}
