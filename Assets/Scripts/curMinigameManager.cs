using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class curMinigameManager : MonoBehaviour
{
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    public void startLoss()
    {
        ControleSessao.instance.finalizaMiniGame(false);
    }

    public void startVictory()
    {
        ControleSessao.instance.finalizaMiniGame(true);
    }
}
