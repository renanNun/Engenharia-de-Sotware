using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardManager : MonoBehaviour
{
    public List<Text> scoreTexts;

    void Start()
    {
        for(int i = 0; i<ControleSessao.instance.dados.highScores.Count; i++)
        {
            scoreTexts[i].text = string.Format("{0}° - {1} - {2} Pts", (i + 1).ToString("##"),
                                                  ControleSessao.instance.dados.highScoreDates[i],
                                                  ControleSessao.instance.dados.highScores[i]);
        }
    }
    
}
