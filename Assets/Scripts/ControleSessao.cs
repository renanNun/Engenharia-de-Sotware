using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControleSessao : MonoBehaviour
{
    static public ControleSessao instance;

    public List<Topico> topicos = new List<Topico>();
    public int vidas;
    public int pontos;

    public Topico curTopico;
    public bool lastMinigameVenceu;

    public DadosEstatisticas dados;

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
        string jsonDados = PlayerPrefs.GetString("dados_estatisticas", "");
        if(jsonDados!= "")
        {
            dados = JsonUtility.FromJson<DadosEstatisticas>(jsonDados);
        } else
        {
            dados = new DadosEstatisticas();
            dados.highScorePlayers = new List<string>();
            dados.highScores = new List<int>();
        }

        topicos.Add(new Topico("Estrutura de Dados",
            "Uma estrutura de dados (ED), em ciencia da computacao, eh uma colecao tanto de valores quanto de operacoes.",
            new List<int>() { 5 })); // Cenas do Build Settings que sao desse topico
    }

    public void iniciaPartida(int topico)
    {
        this.curTopico = topicos[topico];
        this.vidas = 1;
        this.pontos = 0;
        SceneManager.LoadScene(3);
    }

    public void getNextMiniGame()
    {
        SceneManager.LoadScene(curTopico.minigames[(int)(UnityEngine.Random.value * curTopico.minigames.Count)]);
    }

    public void finalizaMiniGame(bool venceu)
    {
        if (!venceu)
        {
            vidas--;
        }
        if(vidas != 0)
        {
            pontos++;
        }

        SceneManager.LoadScene(3);
        

    }

    public void finalizaPartida()
    {
        SceneManager.LoadScene(4);
    }

    public void persisteDadosEstatistica()
    {
        string jsonDados = JsonUtility.ToJson(dados);
        PlayerPrefs.SetString("dados_estatisticas", jsonDados);
    }
}

[Serializable]
public class DadosEstatisticas
{
    public List<string> highScorePlayers;
    public List<int> highScores;
}