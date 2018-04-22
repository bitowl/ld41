using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformationBox : MonoBehaviour
{
    public GameObject messagePrefab;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowInformationBox(string text)
    {
        GameObject message = Instantiate(messagePrefab);
        message.GetComponent<InformationBoxMessage>().message = text;
        message.transform.SetParent(transform, false);
        message.transform.SetAsFirstSibling();

    }
}
