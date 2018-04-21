using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestCreateRenderTexture : MonoBehaviour {
	public Camera rtsCamera;
	public RawImage rawImage;
	// Use this for initialization
	void Start () {
		RenderTexture rtsTexture = new RenderTexture(Screen.width / 2, Screen.height, 24);
		rtsCamera.targetTexture = rtsTexture;
		rawImage.texture = rtsTexture;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
