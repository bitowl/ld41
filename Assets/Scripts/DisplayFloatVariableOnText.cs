using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayFloatVariableOnText : MonoBehaviour {
	public FloatVariable variable;
	public Text text;
	public string prefix;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		text.text = prefix + variable.value;
	}
}
