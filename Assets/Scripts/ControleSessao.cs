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
    public bool foundNewTopScore = false;

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
            dados.highScoreDates = new List<string>();
            dados.highScores = new List<int>();
        }

        topicos.Add(new Topico("Estrutura de Dados",
            "Uma estrutura de dados (ED), em ci�ncia da computa��o, � uma cole��o tanto de valores quanto de opera��es.",
            new List<int>() { 5, 6 })); // Cenas do Build Settings que s�o desse t�pico
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
        Boolean foundPosition = false;
        for(int i = 0;i<dados.highScores.Count; i++)
        {
            if(pontos >= dados.highScores[i])
            {
                foundPosition = true;
                dados.highScores.Insert(i, pontos);
                dados.highScoreDates.Insert(i, String.Format("{0}/{1}/{2}", DateTime.Now.Day.ToString("##"), 
                                            DateTime.Now.Month.ToString("##"), DateTime.Now.Year));
                break;
            }
        }

        if (!foundPosition)
        {
            if(dados.highScores.Count < 10)
            {
                dados.highScores.Add(pontos);
                dados.highScoreDates.Add(String.Format("{0}/{1}/{2}", DateTime.Now.Day.ToString("##"),
                                            DateTime.Now.Month.ToString("##"), DateTime.Now.Year));
            }
        }
        persisteDadosEstatistica();
        SceneManager.LoadScene(4);
    }

    public void persisteDadosEstatistica()
    {
        string jsonDados = JsonUtility.ToJson(dados);
        PlayerPrefs.SetString("dados_estatisticas", jsonDados);
    }

    public void resetaDados()
    {
        PlayerPrefs.SetString("dados_estatisticas", "");
        dados = new DadosEstatisticas();
        dados.highScoreDates = new List<string>();
        dados.highScores = new List<int>();
    }
}

[Serializable]
public class DadosEstatisticas
{
    public List<string> highScoreDates;
    public List<int> highScores;
}