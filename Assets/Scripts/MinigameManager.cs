using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameManager : MonoBehaviour
{
    public float regularMinigameTime;
    public float minimoMinigameTime;
    public GameObject minigameManager;

    private float startTime;
    private float minigameTime;
    private float porcentagemTimeRestante;

    void Start()
    {
        startTime = Time.time;
        minigameTime = calculaMinigameTime();
    }
    
    void Update()
    {
        porcentagemTimeRestante = 1 - ((Time.time - startTime) / minigameTime);
        if(porcentagemTimeRestante <= 0)
        {
            minigameManager.GetComponent<curMinigameManager>().startLoss();
        }
    }

    private float calculaMinigameTime()
    {
        // Aqui é onde futuramente calcularemos o tempo do minigame
        // Mas por enquanto vamos só retornar o tempo normal do minigame
        return regularMinigameTime;
    }
}
