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
            "Uma estrutura de dados (ED), em ciência da computação, é uma coleção tanto de valores quanto de operações.",
            new List<int>() { 3 })); // Cenas do Build Settings que são desse tópico
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
