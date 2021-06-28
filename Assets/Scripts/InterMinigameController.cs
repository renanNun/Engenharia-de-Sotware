using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterMinigameController : MonoBehaviour
{
    private float startTime;
    public float pauseTime;
    public Text points;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        points.text = ControleSessao.instance.pontos.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - startTime > pauseTime)
        {
            if(ControleSessao.instance.vidas > 0)
            { 
                ControleSessao.instance.getNextMiniGame();
            }
            else
            {
                ControleSessao.instance.finalizaPartida();
            }
        }
    }
}
