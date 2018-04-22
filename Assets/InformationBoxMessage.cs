using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InformationBoxMessage : MonoBehaviour {
	public Text text;
	public string message;
	public float displayTime = 3;
	// Use this for initialization
	void Start () {
		text.text = message;
		Destroy(gameObject, displayTime);
	}
	
}
