using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class curMinigameManager : MonoBehaviour
{

    public MusicManager winSound;
    public MusicManager lossSound;

    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    public void startLoss()
    {
        lossSound.Play();
        ControleSessao.instance.finalizaMiniGame(false);
    }

    public void startVictory()
    {
        winSound.Play();
        ControleSessao.instance.finalizaMiniGame(true);
    }
}
