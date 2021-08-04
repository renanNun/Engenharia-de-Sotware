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
    public int curMinigame = -1;

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
            dados.gameStats = new List<GameStat>();
        }

        topicos.Add(new Topico("Estrutura de Dados",
            "Uma estrutura de dados (ED), em ciencia da computacao, e uma colecao tanto de valores quanto de operadores.",
            new List<int>() { 5, 6 })); // Cenas do Build Settings que sao desse topico
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
        curMinigame = (int)(UnityEngine.Random.value * curTopico.minigames.Count);
        SceneManager.LoadScene(curTopico.minigames[curMinigame]);
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

    public void salvaEstatistica(GameStat toSave)
    {
        Boolean dataExists = false;
        for (int i = 0; i<dados.gameStats.Count; i++)
        {
            GameStat cur = dados.gameStats[i];
            if(cur.owner == toSave.owner && cur.ownerStatID == toSave.ownerStatID)
            {
                dataExists = true;
                dados.gameStats[i] = toSave;
                break;
            }
        }
        if (!dataExists)
        {
            dados.gameStats.Add(toSave);
        }
        // Nao Precisa persistir os dados aqui, pois no fim da partida, todos os dados vao ser persistidos de uma vez.
    }

    public void appendEstatistica(int owner, int statID, string name, float stat)
    {
        for (int i = 0; i < dados.gameStats.Count; i++)
        {
            GameStat cur = dados.gameStats[i];
            if (cur.owner == owner && cur.ownerStatID == statID)
            {
                dados.gameStats[i].data.Add(stat);
            }
        }

        // Caso a estatistica nao exista, o metodo cria um novo GameStat com o nome e os dados passados
        GameStat newStat = new GameStat();
        newStat.owner = owner;
        newStat.ownerStatID = statID;
        newStat.name = name;
        newStat.data = new List<float>();
        newStat.data.Add(stat);
        dados.gameStats.Add(newStat);
    }

    public GameStat getEstatistica(int owner, int statID, string name)
    {
        for (int i = 0; i < dados.gameStats.Count; i++)
        {
            GameStat cur = dados.gameStats[i];
            if (cur.owner == owner && cur.ownerStatID == statID)
            {
                return dados.gameStats[i];
            }
        }

        // Caso a estatistica nao exista, o metodo cria um novo GameStat com o nome e os dados passados
        GameStat newStat = new GameStat();
        newStat.owner = owner;
        newStat.ownerStatID = statID;
            newStat.name = name;
        newStat.data = new List<float>();
        dados.gameStats.Add(newStat);
        return newStat;
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
public class GameStat
{
    public int owner;
    public int ownerStatID; // Caso um jogo tenha multiplas estatisticas o dono vai numera-las
    public string name;
    public List<float> data;

}


[Serializable]
public class DadosEstatisticas
{
    public List<string> highScoreDates;
    public List<int> highScores;
    public List<GameStat> gameStats;
}