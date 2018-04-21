using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MulticamSetup : MonoBehaviour
{
    public Camera shmupCamera;
    public Camera rtsCamera;
    public RawImage shmupImage;
    public RawImage rtsImage;

    private int screenWidth;
    private int screenHeight;

    // Use this for initialization
    void Start()
    {
        shmupCamera = GameObject.Find("ShmupCamera").GetComponent<Camera>();
        rtsCamera = GameObject.Find("RTSCamera").GetComponent<Camera>();
        RemoveUnnededAudioListeners();
        HandleResize();
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
        screenWidth = Screen.width;
        screenHeight = Screen.height;
        RenderTexture shmupTexture = new RenderTexture(Screen.width, Screen.height, 24);
        RenderTexture rtsTexture = new RenderTexture(Screen.width / 2, Screen.height, 24);
        shmupCamera.targetTexture = shmupTexture;
        shmupImage.texture = shmupTexture;
        rtsCamera.targetTexture = rtsTexture;
        rtsImage.texture = rtsTexture;
    }

    void RemoveUnnededAudioListeners()
    {
        Destroy(shmupCamera.GetComponent<AudioListener>());
        Destroy(rtsCamera.GetComponent<AudioListener>());
    }
}
