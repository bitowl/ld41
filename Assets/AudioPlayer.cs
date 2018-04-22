using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioPlayer : MonoBehaviour
{

    private AudioSource source;

    public AudioClip shootSound;
	public AudioClip bulletExplosion;
	public AudioClip smallExplosion;
	public AudioClip bigExplosion;
	public AudioClip errorSound;
	public AudioClip clickSound;
	public AudioClip drawerSound;

    // Use this for initialization
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetButtonUp("Click")) {
			source.PlayOneShot(clickSound);
		}
    }

    public void PlayAudio(string name)
    {
        switch (name)
        {
            case "shoot":
                source.PlayOneShot(shootSound);
                break;
			case "bulletExplosion":
				source.PlayOneShot(bulletExplosion);
                break;
			case "smallExplosion":
				source.PlayOneShot(smallExplosion);
                break;
			case "bigExplosion":
				source.PlayOneShot(bigExplosion);
                break;
			case "error":
				source.PlayOneShot(errorSound);
				break;
			case "click":
				source.PlayOneShot(clickSound);
				break;
			case "drawer":
				source.PlayOneShot(drawerSound);
				break;
            default:
                Debug.LogError("No sound with name " + name);
                break;
        }

    }
}
