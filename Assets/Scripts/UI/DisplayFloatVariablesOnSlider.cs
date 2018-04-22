using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayFloatVariablesOnSlider : MonoBehaviour {
	public FloatVariable variable;
	public FloatVariable max;
	public Slider slider;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		slider.value = variable.value / max.value;
	}
}
