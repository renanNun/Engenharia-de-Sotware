using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenLoader : MonoBehaviour
{
    public AudioSource player;
    public void LoadScene(string sceneName) {
        player.Play();
        DontDestroyOnLoad(player);
        SceneManager.LoadScene(sceneName);
    }

    public void IniciaPartida(int topico)
    {
        ControleSessao.instance.iniciaPartida(topico);
    }
}
