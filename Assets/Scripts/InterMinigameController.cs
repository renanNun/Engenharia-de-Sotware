using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterMinigameController : MonoBehaviour
{
    private float startTime;
    public float pauseTime;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
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
