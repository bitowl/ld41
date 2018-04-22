using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class RTSDrawer : MonoBehaviour
{
	public StringEvent audioEvent;
    private Animator animator;
    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetVisible(bool visible)
    {
		audioEvent.Raise("drawer");
        animator.SetBool("DrawerOpen", visible);
    }
}
