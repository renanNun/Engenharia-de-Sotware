using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlotManager : MonoBehaviour
{
    public List<RectTransform> bars;
    public Text titleText;

    public void adjustPlotToData(List<float> data, string title)
    {
        float max = 0;
        int numBars = 7;
        if(data.Count < 7)
        {
            numBars = data.Count;
        }
        for(int i = numBars; i>0; i--)
        {
            if (data[i - 1] > max) max = data[i - 1];
        }
        for (int i = numBars; i > 0; i--)
        {
            bars[bars.Count - i].localScale = new Vector3(1, data[data.Count - i] / max, 1);
        }
        titleText.text = title;
    }
}
