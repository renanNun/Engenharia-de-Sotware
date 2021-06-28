using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScoreManager : MonoBehaviour
{
    public Text topico;
    public Text pontos;
    // Start is called before the first frame update
    void Start()
    {
        topico.text = ControleSessao.instance.curTopico.nome;
        pontos.text = ControleSessao.instance.pontos.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
