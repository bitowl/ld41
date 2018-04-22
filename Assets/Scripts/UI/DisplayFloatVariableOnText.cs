using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayFloatVariableOnText : MonoBehaviour
{
    public FloatVariable variable;
    public TextMeshProUGUI text;
    public string prefix;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        text.text = prefix + variable.value;
    }
}
