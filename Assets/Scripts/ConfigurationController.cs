using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class ControleConfiguracao : MonoBehaviour
{
    private bool muted;

    public AudioMixer audioMixer;

    public Dropdown fontDropdown;

    Font[] fontsTypes;

    void start()
    {
        fontsTypes;

        fontDropdown.clearOptions();

        List<string> options = new List<string>();

        fontDropdown.AddOptions(fontsTypes);
    }

    public void setVolume(float volume)
    {
        audioMixer.setFloat("volume",volume);
    }

    public void setFontSize(int fontSize)
    {
        
    }

    public void isMute(bool isMuted)
    {
        this->muted = isMuted;
    }

    public void deleteCache()
    {
        
    }
}