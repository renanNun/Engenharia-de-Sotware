using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class curMinigameManager : MonoBehaviour
{

    public MusicManager sound;

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
        sound.Play();
        ControleSessao.instance.finalizaMiniGame(true);
    }
}
