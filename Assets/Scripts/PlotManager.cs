using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlotManager : MonoBehaviour
{
    public List<RectTransform> bars;
    public Text titleText;

    private void Start()
    {
        foreach(RectTransform bar in bars)
        {
            bar.localScale = new Vector3(0, 0, 0);
        }
    }
    public void adjustPlotToData(List<float> data, string title)
    {
        float max = 0;
        for(int i = 6; i>=0; i--)
        {
            if (data[data.Count - i] > max) max = data[data.Count - i];
        }
        for (int i = 6; i >= 0; i--)
        {
            bars[bars.Count - i].localScale = new Vector3(1, data[data.Count - i] / max, 1);
        }
        titleText.text = title;
    }
}
