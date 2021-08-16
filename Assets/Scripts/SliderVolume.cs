using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderVolume : MonoBehaviour
{
    
    public Slider slider;

    void Start()
    {
        VolumeSingleton volume = GameObject.Find("Volume").GetComponent<VolumeSingleton>();
        
        // When change the slider value update the volume with it
        slider.onValueChanged.AddListener(delegate {volume.setVolume(slider.value);});
        
        // set the slider value as the current volume
        slider.value = volume.getVolume();
    }
}
