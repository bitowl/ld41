using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTSDrawerToggle : MonoBehaviour {
	public RTSDrawer drawer;

	private bool drawerVisible;


	public void Toggle() {
		drawerVisible = !drawerVisible;
		drawer.gameObject.SetActive(drawerVisible);
	}
}
