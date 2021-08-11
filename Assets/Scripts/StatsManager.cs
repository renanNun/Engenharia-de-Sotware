using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
    public GameObject minigameSelector;
    public GameObject plotDisplay;
    public Transform plotDisplayContentTransform;
    public List<GameObject> plots = new List<GameObject>();
    public GameObject plotTemplate;
    

    public void showPlots(int owner)
    {
        foreach(GameObject plot in plots)
        {
            Destroy(plot);
        }
        minigameSelector.SetActive(false);

        plotDisplay.SetActive(true);

        List<GameStat> showable = ControleSessao.instance.getEstatisticasByOwner(owner);
        foreach(GameStat stat in showable)
        {
            plotData(stat);
        }
    }

    public void plotData(GameStat data)
    {
        GameObject newPlot = (GameObject)Instantiate(plotTemplate, plotDisplayContentTransform);
        PlotManager newPlotManager = newPlot.GetComponent<PlotManager>();
        plots.Add(newPlot);
        newPlotManager.adjustPlotToData(data.data, data.name);
    }
}
