using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderClap : MonoBehaviour
{
    bool canFlicker = true;
    public AudioClip clip;
    new AudioSource audio;
    new Light light;

    private void Start()
    {
        light = GetComponent<Light>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Flicker());
    }

    IEnumerator Flicker()
    {
        if (canFlicker)
        {
            canFlicker = false;
            audio.PlayOneShot(clip);
            light.enabled = true;
            yield return new WaitForSeconds(Random.Range(0.1f, 0.4f));
            light.enabled = false;
            yield return new WaitForSeconds(Random.Range(0.1f, 5));
            canFlicker = true;
        }
    }
}
