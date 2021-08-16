using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ControleConfiguration : MonoBehaviour
{
    private bool muted;

    public VolumeSingleton volume;
    // Start is called before the first frame update
    void Start()
    {
        if (this.volume.getVolume() > 0.0F) {
            this.muted = false;
        } else {
            this.muted = true;
        }
    }


    public void setMuted()
    {
        this.muted = !this.muted;
        if (this.muted) {
            this.volume.setVolume(0.0F);
        } else {
            this.volume.setVolume(1.0F);
        }
    }

    public void restart()
    {
        ControleSessao.instance.resetaDados();
    }

    public void setVolume(float soundLevel)
    {
        this.volume.setVolume(soundLevel);
    }
}
