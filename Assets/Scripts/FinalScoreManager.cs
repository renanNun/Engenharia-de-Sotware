using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScoreManager : MonoBehaviour
{
    public Text topicoTextbox;
    public Text pontosTextbox;

    void Start()
    {
        topicoTextbox.text = ControleSessao.instance.curTopico.nome;
        pontosTextbox.text = ControleSessao.instance.pontos.ToString();
    }
}
