using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource audioSource;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void Play() {
        this.audioSource.Play();
    }

}
