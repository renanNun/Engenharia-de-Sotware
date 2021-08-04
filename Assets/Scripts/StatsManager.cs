using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
    public GameObject minigameSelector;
    public GameObject plotDisplay;
    public Transform plotDisplayContentTransform;
    public List<Object> plots = new List<Object>();
    

    public void showPlots(int owner)
    {
        minigameSelector.SetActive(false);
   
        List<GameStat> showable = ControleSessao.instance.getEstatisticasByOwner(owner);
        plotDisplay.SetActive(true);
    }

    public void plotData(GameStat data)
    {

    }
}
