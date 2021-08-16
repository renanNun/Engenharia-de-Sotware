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
        //this.audioMixer = new AudioMixer();
        this.muted = false;
    }


    public void setMuted()
    {
        this.muted = !this.muted;
    }

    public void restart()
    {
        ControleSessao.instance.resetaDados();
    }

    public void setVolume(float soundLevel)
    {
        //this.audioMixer.SetFloat("musicVol", soundLevel);
    }
}
