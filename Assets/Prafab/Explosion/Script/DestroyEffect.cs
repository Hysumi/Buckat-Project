using UnityEngine;
using System.Collections;

public class DestroyEffect : MonoBehaviour {
    float time;
    AudioSource audio;
    void Start()
    {
        audio = GetComponent<AudioSource>();
        audio.Play();
    }
	void Update ()
	{
        time += Time.deltaTime;
        if (time > 7f)
            Destroy(this.gameObject);	
	}
}
