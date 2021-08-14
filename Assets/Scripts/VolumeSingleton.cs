using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeSingleton : MonoBehaviour
{

    static public VolumeSingleton instance; 
    static private float volume = 1F;
    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }

        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void setVolume(float value) {
        volume = value;
    }

    public float getVolume() {
        return volume;
    }

}
