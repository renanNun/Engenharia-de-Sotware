using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeSingleton : Singleton
{
 
    static private float volume = 1F;
    
    public void setVolume(float value) {
        volume = value;
    }

    public float getVolume() {
        return volume;
    }

}
