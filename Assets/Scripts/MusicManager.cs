using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource audioSource;
    public VolumeSingleton volume;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void Play() {
        this.audioSource.PlayOneShot(this.audioSource.clip, volume.getVolume());
    }

}
