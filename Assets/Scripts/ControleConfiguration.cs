using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ControleConfiguration : MonoBehaviour
{
    private bool muted;

    public AudioMixer audioMixer;
    // Start is called before the first frame update
    void Start()
    {
        this.muted = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setMuted()
    {
        this.muted = !this.muted;
    }

    public void restart()
    {

    }

    public void setVolume(float soundLevel)
    {
        audioMixer.SetFloat("musicVol", soundLevel);
    }
}
