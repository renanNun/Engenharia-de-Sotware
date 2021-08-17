using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlotManager : MonoBehaviour
{
    public List<RectTransform> bars;
    public List<Text> labels;
    public List<RectTransform> labelRects;
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
            float yScale = data[data.Count - i] / max;
            bars[bars.Count - i].localScale = new Vector3(1, yScale, 1);
            labels[bars.Count - i].text = (100*data[data.Count - i]).ToString() + "%";
            labelRects[bars.Count - i].localPosition = new Vector3(0, yScale*370, 0);
        }
        titleText.text = title;
    }
}