using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControleSessao : MonoBehaviour
{
    static ControleSessao instance;
    public List<Topico> topicos = new List<Topico>();

    private Topico curTopico;

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

    private void Start()
    {
        topicos.Add(new Topico("Estrutura de Dados",
            "Uma estrutura de dados (ED), em ci�ncia da computa��o, � uma cole��o tanto de valores quanto de opera��es.",
            new List<int>() { 3 })); // Cenas do Build Settings que s�o desse t�pico
    }

    public void iniciaPartida(int topico)
    {
        this.curTopico = topicos[topico];
    }

    public void getNextMiniGame()
    {
        SceneManager.LoadScene(curTopico.minigames[(int)(UnityEngine.Random.value * curTopico.minigames.Count)]);
    }
}
